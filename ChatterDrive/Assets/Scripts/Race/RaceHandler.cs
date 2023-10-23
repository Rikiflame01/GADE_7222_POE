using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;



public class RaceHandler : MonoBehaviour
{
    [Header("Container")]
    [SerializeField] private Transform leaderBoardContainer;

    [Header("Debugging")]
    [SerializeField]
    private List<RacerData> racersList = new List<RacerData>();

    //Local
    private bool spawned = false;
    private List<RacerUI> spawnedUIElements = new List<RacerUI>();

    //Subscribing and unsubsrcibing to events
    private void OnEnable()
    {
        AIRacerHandler.OnAIReachedWaypoint += HandleRacerCheckpointTriggered;
        ChapterManager.OnCheckPointReached += HandleRacerCheckpointTriggered;
    }

    private void OnDisable()
    {
        AIRacerHandler.OnAIReachedWaypoint -= HandleRacerCheckpointTriggered;
        ChapterManager.OnCheckPointReached -= HandleRacerCheckpointTriggered;
    }

    //Get racer data by entering racer name
    private RacerData GetRacerByName(string racerName)
    {
        foreach (var racer in racersList)
        {
            if (racer.RacerName == racerName)
            {
                return racer;
            }
        }
        return null;
    }

    //handle when player has fired an event when they trigger a checkpoint
    private void HandleRacerCheckpointTriggered(int numCheckpoints)
    {
        RacerData playerData = GetRacerByName("Player");

        if (playerData != null)
        {
            playerData.Index = numCheckpoints;
            SortRacersList();
            UpdateRacerPositionsUI();
        }
    }

    //Handle event fired by AIRacerHandler to check the AI position
    private void HandleRacerCheckpointTriggered(AIRacerHandler racer, int index)
    {
        //Get racer data from AI name
        RacerData racerData = GetRacerByName(racer.name);
        if (racerData != null)
        {
            racerData.Index = index;
            SortRacersList();
            UpdateRacerPositionsUI();
        }
    }

    // Bubble sort the racers list based on their indexes
    private void SortRacersList()
    {
        for (int i = 0; i < racersList.Count - 1; i++)
        {
            for (int j = 0; j < racersList.Count - i - 1; j++)
            {
                if (racersList[j].Index < racersList[j + 1].Index)
                {
                    RacerData temp = racersList[j];
                    racersList[j] = racersList[j + 1];
                    racersList[j + 1] = temp;
                }
            }
        }
    }

    //Add racers to a list and instantiate the Racer data class from the parameters
    public void AddRacer(string racerName, int initialIndex, RacerUI uiElement)
    {
        //Check if UI element null
        if (uiElement == null)
        {
            Debug.LogError($"NUll UI element from {racerName}");
            return;
        }
        racersList.Add(new RacerData(racerName, initialIndex, uiElement));
    }

    //Showing racers position for UX
    private void UpdateRacerPositionsUI()
    {
        //If no UI elements are spawned populate spawnedUIElements, and show racers in container
        if (!spawned)
        { 
            foreach (RacerData racer in racersList)
            {
                RacerUI spawnedUI = Instantiate(racer.RacerUIElement, leaderBoardContainer);
                spawnedUIElements.Add(spawnedUI);
            }
            spawned = true;
        }
        //Change the racers postions on the leaderboard
        for (int i = 0; i < racersList.Count; i++)
        {
            spawnedUIElements[i].SetUpRacerUI((i+1).ToString(), racersList[i].RacerName);
        }
    }
}

//Class for the list to oraganise AI racers and player getting their name, index and UI element
[Serializable]
public class RacerData
{
    public string RacerName { get; set; }
    public int Index { get; set; }
    public RacerUI RacerUIElement { get; set; }

    //Constructor for setting up RacerData
    public RacerData(string racerName, int index, RacerUI racerUI)
    {
        RacerName = racerName;
        Index = index;
        RacerUIElement = racerUI;
    }
}

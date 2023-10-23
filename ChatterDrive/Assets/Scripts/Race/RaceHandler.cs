using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;



public class RaceHandler : MonoBehaviour
{
    [Header("Testing")]
    [SerializeField] private Transform leaderBoardContainer;

    [SerializeField]
    private List<RacerData> racersList = new List<RacerData>();

    //Local
    private bool spawned = false;
    private List<RacerUI> spawnedUIElements = new List<RacerUI>();

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

    private void HandleRacerCheckpointTriggered(AIRacerHandler racer, int index)
    {
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

    private void UpdateRacerPositionsUI()
    {
        if (!spawned)
        { 
            foreach (RacerData racer in racersList)
            {
                RacerUI spawnedUI = Instantiate(racer.RacerUIElement, leaderBoardContainer);
                spawnedUIElements.Add(spawnedUI);
            }
            spawned = true;
        }

        for (int i = 0; i < racersList.Count; i++)
        {
            spawnedUIElements[i].SetUpRacerUI((i+1).ToString(), racersList[i].RacerName);
        }
    }
}

[Serializable]
public class RacerData
{
    public string RacerName { get; set; }
    public int Index { get; set; }
    public RacerUI RacerUIElement { get; set; }

    public RacerData(string racerName, int index, RacerUI racerUI)
    {
        RacerName = racerName;
        Index = index;
        RacerUIElement = racerUI;
    }
}

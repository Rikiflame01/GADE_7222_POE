using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;



public class RaceHandler : MonoBehaviour
{
    [Header("Testing")]
<<<<<<< Updated upstream
    [SerializeField] private List<AIRacerHandler> racers = new List<AIRacerHandler>();

    //Local
    private int currentHighestIndex;
    private int currentHighestLapNum;
=======
    [SerializeField] private Transform leaderBoardContainer;

    [SerializeField]
    private List<RacerData> racersList = new List<RacerData>();
>>>>>>> Stashed changes

    //Local
    private bool spawned = false;
    private List<RacerUI> spawnedUIElements = new List<RacerUI>();

    private void OnEnable()
    {
        AIRacerHandler.OnAIReachedWaypoint += HandleRacerCheckpointTriggered;
    }

    private void OnDisable()
    {
        AIRacerHandler.OnAIReachedWaypoint -= HandleRacerCheckpointTriggered;
    }

<<<<<<< Updated upstream
    private void HandleRacerCheckpointTriggered(int index)
    {
        AIRacerHandler tempValue = null;

        if(index > currentHighestIndex)
=======
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

    private void HandlePlayerCheckpointTrigger(int numCheckpoints)
    {
        RacerData playerData = GetRacerByName("Player");
        if (playerData != null)
>>>>>>> Stashed changes
        {
            playerData.Index = numCheckpoints;
            SortRacersList();
            UpdateRacerPositionsUI();
        }
    }

<<<<<<< Updated upstream
        for(int i = 0; i < racers.Count-1; i++)
        {
            for(int j = i+1; j < racers.Count; j++)
            {
                if (racers[i].Index < racers[j].Index)
                {
                    tempValue = racers[i];
                    racers[i] = racers[j];
                    racers[j] = tempValue;
=======
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
>>>>>>> Stashed changes
                }
            }
        }
    }

<<<<<<< Updated upstream
    /// <summary>
    /// Add the AIRacer Handlers in AIRacer Spawner to keep track of positions
    /// </summary>
    /// <param name="handler"></param>
    public void AddRacer(AIRacerHandler handler)
    {
        racers.Add(handler);
    }

    private void Update()
    {
        if (racers.Count == 0) return;


    }

    private void CheckRacersPosition()
    {
       //Check however is closest to the last checkpoint
       
=======
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
>>>>>>> Stashed changes
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

using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceHandler : MonoBehaviour
{
    [Header("Testing")]
    [SerializeField] private List<AIRacerHandler> racers = new List<AIRacerHandler>();
    [SerializeField] private List<RacerUI> racersWithPlayerUI = new List<RacerUI>();

    [SerializeField] private RacerUI playerUICard;
    [SerializeField] private Transform leaderBoardContainer;

    //Local
    private int currentHighestIndex;
    private int playerIndex;
    private int currentHighestLapNum;

    private void Start()
    {
        currentHighestIndex = 0;
        currentHighestLapNum = 0;
    }

    private void OnEnable()
    {
        AIRacerHandler.OnAIReachedWaypoint += HandleRacerCheckpointTriggered;
        ChapterManager.OnCheckPointReached += HandlePlayerCheckpointTrigger;
    }


    private void OnDisable()
    {
        ChapterManager.OnCheckPointReached -= HandlePlayerCheckpointTrigger;
        AIRacerHandler.OnAIReachedWaypoint -= HandleRacerCheckpointTriggered;
    }

    private void HandlePlayerCheckpointTrigger(int numCheckpoints)
    {
        playerIndex = numCheckpoints;
        //Check all the other racers index:
        InsertPlayerInList();
    }

    private void InsertPlayerInList()
    {
        //racersWithPlayerUI.Remove(playerUICard);
        for (int i = 0; i < racers.Count; i++)
        {
            if (playerIndex > racers[i].Index)
            {
                racersWithPlayerUI.Add(playerUICard);
                //racersWithPlayerUI.Insert(i, playerUICard);
                //playerUICard.SetUpRacerUI("","Player", "");
            }
        }
    }

    private void HandleRacerCheckpointTriggered(int index)
    {
        AIRacerHandler tempValue = null;
        RacerUI tempVal2 = null;

        if(index > currentHighestIndex)
        {
            //This racer will be first
            currentHighestIndex = index;
        }

        //Use 
        for (int i = 0; i < racers.Count - 1; i++)
        {
            for (int j = i + 1; j < racers.Count; j++)
            {
                if (racers[i].Index < racers[j].Index)
                {
                    tempValue = racers[i];
                    tempVal2 = racersWithPlayerUI[i];
                    //
                    racers[i] = racers[j];
                    racersWithPlayerUI[i] = racersWithPlayerUI[j];
                    //
                    racers[j] = tempValue;
                    racersWithPlayerUI[j] = tempVal2;

                }
            }
        }

        InsertPlayerInList();
        ShowRacerPositions();
    }

    /// <summary>
    /// Add the AIRacer Handlers in AIRacer Spawner to keep track of positions
    /// </summary>
    /// <param name="handler"></param>
    public void AddRacer(AIRacerHandler handler, RacerUI racerUI)
    {
        racers.Add(handler);
        racersWithPlayerUI.Add(racerUI);
    }

    private void Update()
    {
        if (racers.Count == 0) return;


    }

    private void CheckRacersPosition()
    {
       //Check however is closest to the last checkpoint
       
    }

    private void ShowRacerPositions()
    {
        for(int i = 0; i < racersWithPlayerUI.Count; i++)
        {
            //Destroy(racersWithPlayerUI[i]);

            if (racersWithPlayerUI[i].RacerName != "Player")
            {
                racersWithPlayerUI[i].SetUpRacerUI("", racers[i].name, "");
            }
                

            Instantiate(racersWithPlayerUI[i], leaderBoardContainer);
        }
    }
}

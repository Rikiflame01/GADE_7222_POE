using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceHandler : MonoBehaviour
{
    [Header("Testing")]
    [SerializeField] private List<AIRacerHandler> racers = new List<AIRacerHandler>();

    //Local
    private int currentHighestIndex;
    private int currentHighestLapNum;

    private void Start()
    {
        currentHighestIndex = 0;
        currentHighestLapNum = 0;
    }

    private void OnEnable()
    {
        AIRacerHandler.OnAIReachedWaypoint += HandleRacerCheckpointTriggered;
    }

    private void OnDisable()
    {
        AIRacerHandler.OnAIReachedWaypoint -= HandleRacerCheckpointTriggered;
    }

    private void HandleRacerCheckpointTriggered(int index)
    {
        AIRacerHandler tempValue = null;

        if(index > currentHighestIndex)
        {
            //This racer will be first
            currentHighestIndex = index;
        }

        for(int i = 0; i < racers.Count-1; i++)
        {
            for(int j = i+1; j < racers.Count; j++)
            {
                if (racers[i].Index < racers[j].Index)
                {
                    tempValue = racers[i];
                    racers[i] = racers[j];
                    racers[j] = tempValue;
                }
            }
        }
    }

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
       
    }
}

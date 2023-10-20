using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceHandler : MonoBehaviour
{
    [Header("Testing")]
    [SerializeField] private List<AIRacerHandler> racers = new List<AIRacerHandler>();

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
        int maxLap = 0;
        int maxIndex = 0;

        //Check their lapNum and check their index
        foreach(AIRacerHandler handler in racers)
        {
            AIRacerPosition racerPos = handler.GetAIRacerPosition();

            if(racerPos.lapNum > maxLap)
            {
                maxLap = racerPos.lapNum;
            }

            if(racerPos.index > maxIndex)
            {
                maxIndex = racerPos.index;
            }
        }
    }
}

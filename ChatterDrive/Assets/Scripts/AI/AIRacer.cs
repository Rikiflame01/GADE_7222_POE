using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIRacer : MonoBehaviour
{
    public Waypoints waypoints;

    public int LapNum { get; private set; }

    //Local
    private NavMeshAgent racerAgent;
    private int waypointIndex = 0;

    public event Action OnAIReachedWaypoint;

    void Start()
    {
        LapNum = 0;
        racerAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        //For testing add collisions for proper after testing
        racerAgent.SetDestination(waypoints.GetNextWaypoint(waypointIndex).position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Checkpoint"))
        {
            OnAIReachedWaypoint?.Invoke();
            waypointIndex++;
            if(waypointIndex >= waypoints.GetNumWaypoints())
            {
                LapNum++;
                waypointIndex = 0;
            }
        }

    }
}

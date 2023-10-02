using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIRacer : MonoBehaviour
{
    private NavMeshAgent racerAgent;
    public Waypoints waypoints;
    public Transform test;

    private int index = 0;

    void Start()
    {
        racerAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        //For testing add collisions for proper after testing
        racerAgent.SetDestination(test.position);
        //Debug.Log(waypoints.ReachedWaypoint(index).position);

        //float distance = Vector3.Distance(transform.position, waypoints.ReachedWaypoint(index).position);

        //if(distance < racerAgent.stoppingDistance ) 
        //{
        //    index++;
        //    if(index > waypoints.GetNumWaypoints())
        //    {
        //        index = 0;
        //    }
        //}
    }
}

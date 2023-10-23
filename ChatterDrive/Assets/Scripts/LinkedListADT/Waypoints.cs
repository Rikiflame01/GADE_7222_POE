using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : Singleton<Waypoints> 
{
    [Header("NavMeshAgent Waypoints")]
    public Transform[] AIWaypoints;

    private LinkedListOne<Transform> waypoints = new LinkedListOne<Transform>();

    void Awake()
    {
        //Populate the linked list with waypoints, storing references
        for (int i = 0; i < AIWaypoints.Length; i++)
        {
            waypoints.InsertAtEnd(AIWaypoints[i]);
        }
        
    }

    //Get a reference to the last waypoint 
    public Transform GetLastWaypoint()
    {
        return waypoints.GetAtIndex(waypoints.Size() - 1);
    }


    //Get reference to the correct node in the linked list, getting the Next waypoint based on index
    public Transform GetNextWaypoint(int index)
    {
        //
        if(index == waypoints.Size())
        {
            index = 0;
        }
        
        return waypoints.GetAtIndex(index);
    }

    //Get the total number of waypoints
    public int GetNumWaypoints()
    {
        return waypoints.Size();
    }

}

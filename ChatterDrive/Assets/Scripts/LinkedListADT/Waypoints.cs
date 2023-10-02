using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    [Header("NavMeshAgent Waypoints")]
    public Transform[] AIWaypoints;

    private LinkedListOne<Transform> waypoints = new LinkedListOne<Transform>();

    void Awake()
    {
        //Populate the linked list with waypoints
        for(int i = 0; i < AIWaypoints.Length; i++)
        {
            waypoints.InsertAtEnd(AIWaypoints[i]);
        }
        
    }

    public Transform ReachedWaypoint(int index)
    {
        //
        if(index == waypoints.Size())
        {
            index = 0;
        }
        
        return waypoints.GetAtIndex(index);
    }

    public int GetNumWaypoints()
    {
        return waypoints.Size();
    }

}

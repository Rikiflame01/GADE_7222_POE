using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIRacerHandler : MonoBehaviour
{
    [Header("References: ")]
    //Cache the singleton reference on start or awake
    [SerializeField] private Waypoints waypoints;
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private NavMeshAgent racerAgent;
    [SerializeField] private AIRacerFactory racerFactory;
    [SerializeField] private RacerUI racerUI;
    [SerializeField] private ADTGraph graph;

    public int LapNum { get; private set; }
    [field: SerializeField] public int Index { get; private set; }
    [field: SerializeField] public bool advanced { get; set; }
    //Debugging
    public int waypointIndex = 0;

    public bool isReached;
    //Event for race handler to update the leaderboard
    public delegate void WaypointReached(AIRacerHandler handler, int index);
    public static event WaypointReached OnAIReachedWaypoint;

    void Start()
    {
        LapNum = 0;
        Index = 0;
        racerAgent = GetComponent<NavMeshAgent>();
        if (advanced)
        {
            graph = ADTGraph.Instance;
            SetAdvancedRacerPos();
            return;
        }
        waypoints = Waypoints.Instance;
        //SetupRacerType()
    }

    void Update()
    {
        //For testing use singleton reference
        if(advanced)
        {

        }
        else
        {
            racerAgent.SetDestination(waypoints.GetNextWaypoint(waypointIndex).position);
        }
        
    }

    private void SetAdvancedRacerPos()
    {
        racerAgent.SetDestination(graph.GetNextWaypoint(this).position);
        Debug.Log("New index: " + waypointIndex);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Handling AIracer when they reached a checkpoint
        if(other.CompareTag("Checkpoint") && !isReached)
        {
            Debug.Log($"Triggered by {gameObject.name} / {other.name}");
            StartCoroutine(DisableRacerTrigger());
            RacerReachedCheckpoint();
        }

    }

    private void RacerReachedCheckpoint()
    {
        //Increase waypoint index after reaching checkpoint
        waypointIndex++;
        Index++;
        //Fire event to let the race handler know which AIRacer reached the checkpoint
        OnAIReachedWaypoint?.Invoke(this, Index);
        isReached = true;

        if(advanced)
        {
            if (waypointIndex >= graph.GetNumNodes())
            {
                IncreaseLapCount();
            }
            SetAdvancedRacerPos();
            return;
        }

        

        if (waypointIndex >= waypoints.GetNumWaypoints())
        {//
            IncreaseLapCount();    
        }
    }

    private void IncreaseLapCount()
    {
        //Increase AIRacer lap number
        LapNum++;
        //Waypoint index set to zero so racer can loop
        waypointIndex = 0;
    }

    //Setup racers navMeshAgent based on their type using the factory types
    public void SetupRacerType(RacerType racerType)
    {
        AIRacerBase racerBase = null;

        switch (racerType)
        {
            case RacerType.Pyro:
                racerBase = racerFactory.CreatePyroRacer();
                break;
            case RacerType.Hydro:
                racerBase = racerFactory.CreateHydroRacer();
                break;
            case RacerType.Pangean:
                racerBase = racerFactory.CreatePangeaRacer();
                break;
            case RacerType.Blizzardien:
                racerBase = racerFactory.CreateBlizzardRacer();
                break;
            case RacerType.Magman:
                racerBase = racerFactory.CreateMagmaRacer();
                break;
        }

        //Set up the racer agent parameters
        racerAgent.speed = racerBase.RacerSpeed;
        meshRenderer.material.color = racerBase.RacerColor;
        racerAgent.acceleration = racerBase.RacerAcceleration;
        racerAgent.angularSpeed = racerBase.RacerAngularSpeed;

    }

    public void SetRacerMaterial(Material racerMaterial)
    {
        meshRenderer.material = racerMaterial;
    }

    //This method is for the object triggering twice when entering a checkpoint which lead to weird beaviour
    IEnumerator DisableRacerTrigger()
    {
        yield return new WaitForSeconds(1f);
        isReached = false;
    }
    //For setting up the AIRacer on the leaderboard
    public RacerUI GetRacerUI()
    {
        return racerUI;
    }

}


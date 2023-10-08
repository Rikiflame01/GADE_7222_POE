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

    //[]

    public int LapNum { get; private set; }

    //Local
    private NavMeshAgent racerAgent;
    private int waypointIndex = 0;

    public event Action OnAIReachedWaypoint;

    void Start()
    {
        LapNum = 0;
        racerAgent = GetComponent<NavMeshAgent>();
        waypoints = Waypoints.Instance;
        //SetupRacerType()
    }

    void Update()
    {
        //For testing use singleton reference
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

    public void SetupRacerType(RacerType racerType)
    {
        AIRacerBase racerBase = null;

        switch(racerType)
        {
            case RacerType.Pyro:
                racerBase = AIRacerFactory.Instance.CreatePyroRacer();
                break;
                case RacerType.Hydro:
                racerBase = AIRacerFactory.Instance.CreateHydroRacer();
                break;
                case RacerType.Pangean:
                racerBase = AIRacerFactory.Instance.CreatePangeaRacer();
                break;
            case RacerType.Blizzardien:
                racerBase = AIRacerFactory.Instance.CreateBlizzardRacer();
                break;
            case RacerType.Magman:
                racerBase = AIRacerFactory.Instance.CreateMagmaRacer();
                break;
        }

        racerAgent.speed = racerBase.RacerSpeed;
        Debug.Log(racerAgent.speed);
        meshRenderer.materials[0].color = racerBase.RacerColor;
        racerAgent.acceleration = racerBase.RacerAcceleration;
        Debug.Log(racerAgent.acceleration);
        racerAgent.angularSpeed = racerBase.RacerAngularSpeed;
        Debug.Log(racerAgent.angularSpeed);

    }
}

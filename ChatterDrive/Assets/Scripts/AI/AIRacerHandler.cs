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

    public int LapNum { get; private set; }
    [field: SerializeField] public int Index { get; private set; }
    //Debugging
    public int waypointIndex = 0;

    public bool isReached;

    public static event Action<int> OnAIReachedWaypoint;

    void Start()
    {
        LapNum = 0;
        Index = 0;
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
        if(other.CompareTag("Checkpoint") && !isReached)
        {
            //Debug.Log($"Triggered by {gameObject.name} / {other.name}");
            StartCoroutine(DisableRacerTrigger());
            RacerReachedCheckpoint();
        }

    }

    private void RacerReachedCheckpoint()
    {
        waypointIndex++;
        Index++;
        OnAIReachedWaypoint?.Invoke(Index);
        isReached = true;

        if (waypointIndex >= waypoints.GetNumWaypoints())
        {
            LapNum++;
            waypointIndex = 0;
        }

    }

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
        yield return new WaitForSeconds(0.5f);
        isReached = false;
    }

    public RacerUI GetRacerUI()
    {
        return racerUI;
    }

}

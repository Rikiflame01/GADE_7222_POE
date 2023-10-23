using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIRacerSpawner : MonoBehaviour
{
    [Header("References: ")]
    [SerializeField] private AIRacerFactory factory;
    [SerializeField] private RaceHandler raceHandler;

    [Header("Settings: ")]
    [SerializeField] private SpawnObject[] spawnObjects;

    private List<GameObject> spawnedRacers;

    void Start()
    {
        for (int i = 0; i < spawnObjects.Length; i++)
        {
            GameObject racerInstance = factory.CreateRacer(spawnObjects[i].racerType);
            racerInstance.name = spawnObjects[i].racerType.ToString();
            racerInstance.transform.position = spawnObjects[i].spawnPoint.position;
            racerInstance.GetComponent<NavMeshAgent>().enabled = true;
<<<<<<< Updated upstream
            raceHandler.AddRacer(racerInstance.GetComponent<AIRacerHandler>());
=======
            AIRacerHandler racer = racerInstance.GetComponent<AIRacerHandler>();
            raceHandler.AddRacer(racerInstance.name, racer.Index, racer.GetRacerUI());
>>>>>>> Stashed changes
        }
    }


}
[Serializable]
public struct SpawnObject
{ 
    public RacerType racerType;
    public Transform spawnPoint;
}


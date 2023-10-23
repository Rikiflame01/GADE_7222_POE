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

    void Start() // Spawn the AIRacers from the factory base prefab
    {
        for (int i = 0; i < spawnObjects.Length; i++)
        {
            GameObject racerInstance = factory.CreateRacer(spawnObjects[i].racerType);
            racerInstance.name = spawnObjects[i].racerType.ToString();
            //Set racer position
            racerInstance.transform.position = spawnObjects[i].spawnPoint.position;
            racerInstance.GetComponent<NavMeshAgent>().enabled = true;
            AIRacerHandler racer = racerInstance.GetComponent<AIRacerHandler>();
            //Addd racer to race handler for the leaderboard
            raceHandler.AddRacer(racerInstance.name, racer.Index, racer.GetRacerUI());
        }
    }


}
[Serializable] //Generate the types and spawnpoint in the inspector
public struct SpawnObject
{ 
    public RacerType racerType;
    public Transform spawnPoint;
}


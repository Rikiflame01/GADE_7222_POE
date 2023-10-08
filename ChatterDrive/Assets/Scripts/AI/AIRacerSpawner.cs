using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIRacerSpawner : MonoBehaviour
{
    [Header("Spawned Gameobject Base: ")]
    [SerializeField] private GameObject baseRacerPrefab;

    [Header("Settings: ")]
    [SerializeField] private SpawnObject[] spawnObjects;

    private List<GameObject> spawnedRacers;

    void Awake()
    {
        for(int i = 0; i < spawnObjects.Length; i++)
        {
            GameObject racerInstance = Instantiate(baseRacerPrefab, spawnObjects[i].spawnPoint.position, Quaternion.identity);
            AIRacerHandler racer = racerInstance.GetComponent<AIRacerHandler>();
            racer.SetupRacerType(spawnObjects[i].type);
        }

    }


}
[Serializable]
public struct SpawnObject
{ 
    public RacerType type;
    public Transform spawnPoint;
}


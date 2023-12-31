using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;

//Different racer types
public enum RacerType
{
    Pyro,
    Pangean,
    Hydro,
    Blizzardien,
    Magman
}

//Scriptable object instead of a singleton so we can make multiple instances of the basePrefab
[CreateAssetMenu(fileName = "New AI Factory", menuName = "AI Factory Racer")]
public class AIRacerFactory: ScriptableObject, IAIRacerFactory
{
    //Base racer with their material
    [SerializeField] private GameObject baseRacerPrefab;
    [SerializeField] private Material[] racerMaterials;

    //Create/Instantiate the different racers
    public AIRacerBlizzard CreateBlizzardRacer()
    {
        return new AIRacerBlizzard();
    }

    public AIRacerHydro CreateHydroRacer()
    {
        return new AIRacerHydro();
    }

    public AIRacerMagma CreateMagmaRacer()
    {
        return new AIRacerMagma();
    }

    public AIRacerPangea CreatePangeaRacer()
    {
        return new AIRacerPangea();
    }

    public AIRacerPyro CreatePyroRacer()
    {
        return new AIRacerPyro();
    }

    //Get the base racer prefab and setup racer in AIRaceHandler
    public GameObject CreateRacer(RacerType type)
    {
        GameObject racerInstance = Instantiate(baseRacerPrefab); 
        AIRacerHandler racerHandler = racerInstance.GetComponent<AIRacerHandler>();
        racerHandler.SetupRacerType(type);
        racerHandler.SetRacerMaterial(racerMaterials[(int)type]);
        return racerInstance;
    }
}
//Interface for creating different racers
public interface IAIRacerFactory
{
    AIRacerPyro CreatePyroRacer();
    AIRacerPangea CreatePangeaRacer();
    AIRacerHydro CreateHydroRacer();
    AIRacerBlizzard CreateBlizzardRacer();
    AIRacerMagma CreateMagmaRacer();
    GameObject CreateRacer(RacerType type);
}

[Serializable] //Racer base class
public class AIRacerBase
{
    //Racer Stats
    public RacerType RacerType {  get;private set; }
    public Color RacerColor { get; private set; }
    public float RacerSpeed { get; private set; }
    public float RacerAcceleration { get; private set; }
    public float RacerAngularSpeed { get; private set; }
    //Constructor for setting up racer stats
    public AIRacerBase(Color racerColor, float racerSpeed, float racerAcceleration, float racerAngularSpeed, RacerType racerType)
    {
        RacerColor = racerColor;
        RacerSpeed = racerSpeed;
        RacerAcceleration = racerAcceleration;
        RacerAngularSpeed = racerAngularSpeed;
        RacerType = racerType;
    }

}

//Children of AIRaceBase, constructing the children based on their affinity
public class AIRacerPyro :AIRacerBase
{
    //Fire racers fast acceleration and low top speed
    public AIRacerPyro() : base(Color.red, 10, 10, 1800, RacerType.Pyro)
    {
        // 
    }
}

public class AIRacerHydro : AIRacerBase
{
    //Water racers slow acceleration and high top speed
    public AIRacerHydro() : base(Color.blue, 9, 7, 1500, RacerType.Hydro)
    {
        // 
    }
}

public class AIRacerPangea : AIRacerBase
{
    //earth racers gradual acceleration and medium top speed
    public AIRacerPangea() : base(Color.green, 8, 12, 1200, RacerType.Pangean)
    {
        // 
    
    }
}

public class AIRacerBlizzard : AIRacerBase
{
    //earth racers gradual acceleration and medium top speed
    public AIRacerBlizzard() : base(Color.magenta, 7, 12, 1000, RacerType.Blizzardien)
    {
        // 

    }
}

public class AIRacerMagma : AIRacerBase
{
    //earth racers gradual acceleration and medium top speed
    public AIRacerMagma() : base(Color.yellow, 8, 9, 1000, RacerType.Magman)
    {
        // 

    }
}






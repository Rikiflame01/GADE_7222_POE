using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public enum RacerType
{
    Pyro,
    Pangean,
    Hydro,
    Blizzardien,
    Magman
}

public class Factory : MonoBehaviour
{

}

[Serializable]
public class AIRacerFactory: Singleton<AIRacerFactory>, IAIRacerFactory
{
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
}

public interface IAIRacerFactory
{
    AIRacerPyro CreatePyroRacer();
    AIRacerPangea CreatePangeaRacer();
    AIRacerHydro CreateHydroRacer();
    AIRacerBlizzard CreateBlizzardRacer();
    AIRacerMagma CreateMagmaRacer();
}

[Serializable]
public class AIRacerBase
{
    //Racer Stats
    public RacerType RacerType {  get;private set; }
    public Color RacerColor { get; private set; }
    public float RacerSpeed { get; private set; }
    public float RacerAcceleration { get; private set; }
    public float RacerAngularSpeed { get; private set; }

    public AIRacerBase(Color racerColor, float racerSpeed, float racerAcceleration, float racerAngularSpeed, RacerType racerType)
    {
        RacerColor = racerColor;
        RacerSpeed = racerSpeed;
        RacerAcceleration = racerAcceleration;
        RacerAngularSpeed = racerAngularSpeed;
        RacerType = racerType;
    }

}

public class AIRacerPyro :AIRacerBase
{
    //Fire racers fast acceleration and low top speed
    public AIRacerPyro() : base(Color.red, 7, 10, 360, RacerType.Pyro)
    {
        // 
    }
}

public class AIRacerHydro : AIRacerBase
{
    //Water racers slow acceleration and high top speed
    public AIRacerHydro() : base(Color.blue, 10, 6, 200, RacerType.Hydro)
    {
        // 
    }
}

public class AIRacerPangea : AIRacerBase
{
    //earth racers gradual acceleration and medium top speed
    public AIRacerPangea() : base(Color.green, 8, 8, 100, RacerType.Pangean)
    {
        // 
    
    }
}

public class AIRacerBlizzard : AIRacerBase
{
    //earth racers gradual acceleration and medium top speed
    public AIRacerBlizzard() : base(Color.magenta, 7, 12, 420, RacerType.Blizzardien)
    {
        // 

    }
}

public class AIRacerMagma : AIRacerBase
{
    //earth racers gradual acceleration and medium top speed
    public AIRacerMagma() : base(Color.yellow, 12, 7, 270, RacerType.Magman)
    {
        // 

    }
}






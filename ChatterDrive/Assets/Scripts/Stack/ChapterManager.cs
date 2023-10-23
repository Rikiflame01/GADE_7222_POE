using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChapterManager : MonoBehaviour
{
    //Different checkpoints easier for level design
    [Header("References: ")]
    public Transform[] checkPoints;
    public RaceHandler raceHandler;
    public RacerUI playerUI;
    public TMP_Text lapText;

    private ChapterStack<Transform> chapterStack = new ChapterStack<Transform>();

    //Events
    public delegate void CheckPointComplete(int numCheckpoints);
    public static event CheckPointComplete OnCheckPointReached;
    public static event CheckPointComplete OnStageComplete;

    //public static event Action 

    private void Awake()
    {
        //Add the checkpoints to the chapterStack
<<<<<<< Updated upstream
        for(int i = 0; i < checkPoints.Length; i++)
        {
            chapterStack.Push(checkPoints[i]);
        }
=======
        LoadStack();
        PlayerLapNum = 0;
>>>>>>> Stashed changes
        Debug.Log(chapterStack.ToString());
        Debug.Log(chapterStack.Count);
    }

    private void Start()
    {
        raceHandler.AddRacer("Player", Index, playerUI);
    }

    public void CheckpointReached() //If a checkpoint has been reached delete it from stack and fire a event
    {                               //If the stack is empty fire a stage complete event
<<<<<<< Updated upstream
        chapterStack.Pop();
        OnCheckPointReached?.Invoke(chapterStack.Count);

        if (chapterStack.IsEmpty) 
        {
            Debug.Log("Player has completed scene");
            OnStageComplete?.Invoke(chapterStack.Count);
=======
        if (chapterStack.IsEmpty) return;
        Debug.Log("Player has reached a CP");
        chapterStack.Pop();
        //Check after last pop is the Stack is empty
        if(chapterStack.IsEmpty)
        {
            if (PlayerLapNum >= 3)
            {
                OnStageComplete?.Invoke(chapterStack.Count);
                return;
            }
            Debug.Log("Player has completed a lap");
            Debug.Log("Player Lap: " + PlayerLapNum);
            PlayerLapNum++;
            lapText.text = $"Lap {PlayerLapNum}/3";
            LoadStack();
>>>>>>> Stashed changes
        }
        Index++;
        OnCheckPointReached?.Invoke(Index);


        //if (chapterStack.IsEmpty) 
        //{
        //    if(PlayerLapNum > 3)
        //    {
        //        OnStageComplete?.Invoke(chapterStack.Count);
        //        return;
        //    }
        //    Debug.Log("Player has completed a lap");
        //    Debug.Log("Player Lap: " + PlayerLapNum);
        //    PlayerLapNum++;
        //    lapText.text = $"Lap {PlayerLapNum}/3";
        //    LoadStack();    
        //}
        //else
        //{
        //    Debug.Log("Player has reached a CP");
        //    chapterStack.Pop();
        //    Index++;
        //    OnCheckPointReached?.Invoke(Index);
        //}
    }

    public  int GetNumCheckpoints()
    {
        return chapterStack.Count;
    }

    //Check the top transform of the stack by using Peek for the arrow.
    public Transform GetNextCheckpoint()
    {
        if(chapterStack.IsEmpty)
        {
            return null;
        }
        Debug.Log("Chapter Last value: " + chapterStack.Peek().name);
        return chapterStack.Peek();
    }
}




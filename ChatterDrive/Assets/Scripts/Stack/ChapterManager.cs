using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterManager : MonoBehaviour
{
    //Different checkpoints easier for level design
    public Transform[] checkPoints;

    private ChapterStack<Transform> chapterStack = new ChapterStack<Transform>();

    //Events
    public delegate void CheckPointComplete(int numCheckpoints);
    public static event CheckPointComplete OnCheckPointReached;
    public static event CheckPointComplete OnStageComplete;

    public int PlayerLapNum { get; private set; }
    [field: SerializeField] public int Index { get; private set; } = 0;

    private void Awake()
    {
        //Add the checkpoints to the chapterStack
        LoadStack();
        PlayerLapNum = 1;
        Debug.Log(chapterStack.ToString());
        Debug.Log(chapterStack.Count);
    }

    public void CheckpointReached() //If a checkpoint has been reached delete it from stack and fire a event
    {                               //If the stack is empty fire a stage complete event
        Debug.Log("Player has reached a CP");
        chapterStack.Pop();
        Index++;
        OnCheckPointReached?.Invoke(Index);

        if (chapterStack.IsEmpty) 
        {
            if(PlayerLapNum >= 3)
            {
                OnStageComplete?.Invoke(chapterStack.Count);
                return;
            }
            Debug.Log("Player has completed a lap");
            Debug.Log("Player Lap: " + PlayerLapNum);
            PlayerLapNum++;
            LoadStack();
            
        }
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

    private void LoadStack()
    {
        //Add the checkpoints to the chapterStack
        for (int i = 0; i < checkPoints.Length; i++)
        {
            chapterStack.Push(checkPoints[i]);
        }
    }
}




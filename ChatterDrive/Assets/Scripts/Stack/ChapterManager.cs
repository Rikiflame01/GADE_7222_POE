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

    //public static event Action 

    private void Awake()
    {
        //Add the checkpoints to the chapterStack
        for(int i = 0; i < checkPoints.Length; i++)
        {
            chapterStack.Push(checkPoints[i]);
        }
        Debug.Log(chapterStack.ToString());
        Debug.Log(chapterStack.Count);
    }

    public void CheckpointReached() //If a checkpoint has been reached delete it from stack and fire a event
    {                               //If the stack is empty fire a stage complete event
        chapterStack.Pop();
        OnCheckPointReached?.Invoke(chapterStack.Count);

        if (chapterStack.IsEmpty) 
        {
            Debug.Log("Player has completed scene");
            OnStageComplete?.Invoke(chapterStack.Count);
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
}




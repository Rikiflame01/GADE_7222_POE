using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterManager : MonoBehaviour
{
    public Transform[] checkPoints;

    private ChapterStack<Transform> chapterStack = new ChapterStack<Transform>();

    //Events
    public delegate void CheckPointComplete(int numCheckpoints);
    public static event CheckPointComplete OnCheckPointReached;
    public static event CheckPointComplete OnStageComplete;

    private void Awake()
    {
        for(int i = 0; i < checkPoints.Length; i++)
        {
            chapterStack.Push(checkPoints[i]);
        }
        Debug.Log(chapterStack.ToString());
        Debug.Log(chapterStack.Count);
        //int poppedInt = chapterStack.Pop();
        //Debug.Log("Last int: " + poppedInt);
        //Debug.Log(chapterStack.ToString());
    }

    public void CheckpointReached()
    {
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




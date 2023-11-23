using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChapterManager : MonoBehaviour
{
    //Different checkpoints easier for level design
    public Transform[] checkPoints;
    public RaceHandler raceHandler;
    public RacerUI playerUI;
    public TMP_Text lapText;
    public bool checkPointRace = false;

    private ChapterStack<Transform> chapterStack = new ChapterStack<Transform>();

    //Events
    public delegate void CheckPointComplete(int numCheckpoints);
    public static event CheckPointComplete OnCheckPointReached;
    public static event CheckPointComplete OnStageComplete;

    public int PlayerLapNum { get; private set; }
    public int Index { get; private set; }

    private void Awake()
    {
        //Add the checkpoints to the chapterStack
        LoadStack();
        Debug.Log(chapterStack.ToString());
        Debug.Log(chapterStack.Count);
    }

    private void Start()
    {
        PlayerLapNum = 0;
        //Add player for leaderboard
        if (raceHandler == null) return;
        raceHandler.AddRacer("Player", Index, playerUI);
    }

    public void CheckpointReached() //If a checkpoint has been reached delete it from stack and fire a event
    {                               //If the stack is empty fire a stage complete event
        if (chapterStack.IsEmpty) return;

        Debug.Log("Player has reached a CP");
        chapterStack.Pop();

        //Check after last pop is the Stack is empty
        if (chapterStack.IsEmpty)
        {
            if(checkPointRace)
            {
                OnStageComplete?.Invoke(chapterStack.Count);
                SFXManager.Instance.PlaySound("success");
                return;
            }


            if (PlayerLapNum >= 3)
            {
                OnStageComplete?.Invoke(chapterStack.Count);
                SFXManager.Instance.PlaySound("success");
                return;
            }
            Debug.Log("Player has completed a lap");
            Debug.Log("Player Lap: " + PlayerLapNum);
            PlayerLapNum++;
            if(lapText) lapText.text = $"Lap {PlayerLapNum}/3";
            LoadStack();
        }
        //Increase total index
        Index++;
        OnCheckPointReached?.Invoke(Index);
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
        //Load the stack for player after linked list is empty
        for (int i = 0; i < checkPoints.Length; i++)
        {
            chapterStack.Push(checkPoints[i]);
        }
    }
}




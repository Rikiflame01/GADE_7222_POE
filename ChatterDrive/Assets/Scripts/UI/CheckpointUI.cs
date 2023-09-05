using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CheckpointUI : MonoBehaviour
{
    public TextMeshProUGUI chaptersText;
    public TextMeshProUGUI timerText;
    public ChapterManager chapterManager;
    public float timePerCheckpoint = 10f;

    private float timer;

    private void Start()
    {
        timer = timePerCheckpoint;
        chaptersText.text = "Chapters Left: " + chapterManager.GetNumCheckpoints();
    }

    private void OnEnable()
    {
        ChapterManager.OnCheckPointReached += OnCheckPointReached;
    }

    private void OnDisable()
    {
        ChapterManager.OnCheckPointReached -= OnCheckPointReached;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        timerText.text = "Time left: " + Mathf.Ceil(timer).ToString();
        if(timer <= 0.01)
        {
            Debug.Log("Time is up, player is dead");
            timer = 0;
        }
    }

    private void OnCheckPointReached(int numCheckpoints)
    {
        chaptersText.text = "Chapters Left: " + numCheckpoints;
        timer += timePerCheckpoint;
    }

    
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckpointUI : MonoBehaviour
{
    // Properties for changing in game UI
    [Header("Checkpoint UI")]
    public TextMeshProUGUI chaptersText;
    public TextMeshProUGUI timerText;
    public ChapterManager chapterManager;
    public float timePerCheckpoint = 10f;
    public bool showCheckpointUI = false;

    //References for changing UI screen
    [Header("StopGameScreens")]
    public GameObject loseScreen;
    public GameObject winScreen;

    private float timer;
    private int numCheckpoints;

    private void Start()
    {
        if (!showCheckpointUI) return;
        timer = timePerCheckpoint;
        numCheckpoints = chapterManager.GetNumCheckpoints();
        chaptersText.text = "Chapters Left: " + numCheckpoints;
    }

    //Event subscription and unsubscription
    private void OnEnable()
    {
        ChapterManager.OnCheckPointReached += OnCheckPointReached;
        ChapterManager.OnStageComplete += OnStageComplete;
    }



    private void OnDisable()
    {
        ChapterManager.OnCheckPointReached -= OnCheckPointReached;
        ChapterManager.OnStageComplete -= OnStageComplete;
    }

    private void Update()
    {
        //Show the player time left and round up 
        if(!showCheckpointUI) return;
        timer -= Time.deltaTime;
        timerText.text = "Time left: " + Mathf.Ceil(timer).ToString();

        if (timer <= 0.01) //If time runs out show lose screen
        {
            Debug.Log("Time is up, player is dead");
            ShowLoseScreen(true);

            timer = 0;
        }
    }

    private void OnCheckPointReached(int numCheckpoints)
    {
        if(!showCheckpointUI) return;

        //Update Checkpoint UI
        Debug.Log($"Num Checkpoints: {numCheckpoints}");
        chaptersText.text = "Checkpoints Left: " + (this.numCheckpoints - numCheckpoints);
        timer += timePerCheckpoint;
    }

    private void OnStageComplete(int numCheckpoints)
    {
        //Show won UI
        ShowWinScreen(true);
        SetTimeScale(0);
    }

    public void ShowLoseScreen(bool show)
    {
        //Show lost UI
        loseScreen.SetActive(show);
        SetTimeScale(0);
    }

    private void ShowWinScreen(bool show)
    {
        winScreen.SetActive(show);
    }

    //Change game speed
    private void SetTimeScale(float timeScale)
    {
        Time.timeScale = timeScale;
    }

    public void RestartGame()
    {
        //timer = timePerCheckpoint;
        SetTimeScale(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}

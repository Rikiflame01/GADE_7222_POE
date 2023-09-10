using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckpointUI : MonoBehaviour
{
    [Header("Checkpoint UI")]
    public TextMeshProUGUI chaptersText;
    public TextMeshProUGUI timerText;
    public ChapterManager chapterManager;
    public float timePerCheckpoint = 10f;

    [Header("StopGameScreens")]
    public GameObject loseScreen;
    public GameObject winScreen;

    private float timer;

    private void Start()
    {
        timer = timePerCheckpoint;
        chaptersText.text = "Chapters Left: " + chapterManager.GetNumCheckpoints();
    }

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
        timer -= Time.deltaTime;
        timerText.text = "Time left: " + Mathf.Ceil(timer).ToString();
        if(timer <= 0.01)
        {
            Debug.Log("Time is up, player is dead");
            ShowLoseScreen(true);
            
            timer = 0;
        }
    }

    private void OnCheckPointReached(int numCheckpoints)
    {
        chaptersText.text = "Checkpoints Left: " + numCheckpoints;
        timer += timePerCheckpoint;
    }

    private void OnStageComplete(int numCheckpoints)
    {
        
        ShowWinScreen(true);
        SetTimeScale(0);
    }

    public void ShowLoseScreen(bool show)
    {
        loseScreen.SetActive(show);
        SetTimeScale(0);
    }

    private void ShowWinScreen(bool show)
    {
        winScreen.SetActive(show);
    }

    private void SetTimeScale(float timeScale)
    {
        Time.timeScale = timeScale;
    }

    public void RestartGame()
    {
        timer = timePerCheckpoint;
        SetTimeScale(1);
        SceneManager.LoadScene("CheckpointRace");
    }
    
}

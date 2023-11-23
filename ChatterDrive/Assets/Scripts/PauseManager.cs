using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class PauseManager : MonoBehaviour
{
    public static event Action<bool> PauseCanvasTrigger; 
    SFXManager SFXManager;

    private SceneName[] pausableScenes = new SceneName[]
    {
        SceneName.BeginnerRace,
        SceneName.CheckpointRace,
        SceneName.AdvancedRace
    };

    private bool isPaused = false;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SFXManager.Instance.PlaySound("Pause");
            TogglePause();
        }
    }

    private void TogglePause()
    {
        if (IsCurrentScenePausable())
        {
            isPaused = !isPaused;
            Time.timeScale = isPaused ? 0 : 1;

            // Trigger the PauseCanvasTrigger event
            PauseCanvasTrigger?.Invoke(isPaused);
        }
    }

    private bool IsCurrentScenePausable()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        foreach (var scene in pausableScenes)
        {
            if (currentSceneName == scene.ToString())
            {
                return true;
            }
        }

        return false;
    }
}

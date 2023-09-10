using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneName
{ 
    MainMenu,
    CheckpointRace,
    CheckpointRaceDialogue,
    BeginnerRaceDialogue,
    AdvancedRaceDialogue
}


public class SceneLoader : MonoBehaviour
{
    private SceneName scene;

    //Basic implementation of a scene loader

    public void LoadScene(SceneName sceneName) // Load a scene using enums
    {
        Time.timeScale = 1f;
        scene = sceneName;
        SceneManager.LoadScene(scene.ToString());
    }

    //Functions for loading various scenes 
    public void LoadMainMenu()
    {  
        LoadScene(SceneName.MainMenu);
    }

    public void LoadRaceScene()
    {
        LoadScene(SceneName.CheckpointRace);
    }

    public void LoadCheckDialogueScene()
    {
        LoadScene(SceneName.CheckpointRaceDialogue);
    }

    public void LoadBeginDialogueScene()
    {
        LoadScene(SceneName.BeginnerRaceDialogue);
    }

    public void LoadAdvancedDialogueScene()
    {
        LoadScene(SceneName.AdvancedRaceDialogue);
    }

    public void QuitGame()
    {
        //Function for quitting the game
        Application.Quit();
    }
}

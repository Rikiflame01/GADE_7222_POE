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

    public void LoadScene(SceneName sceneName)
    {
        scene = sceneName;
        SceneManager.LoadScene(scene.ToString());
    }

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
        Application.Quit();
    }
}

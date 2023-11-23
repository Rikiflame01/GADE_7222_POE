using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public FadeManager fadeManager;

    private void Awake()
    {
        fadeManager = FindObjectOfType<FadeManager>();
    }
    public void LoadScene(SceneName sceneName)
    {
        StartCoroutine(LoadSceneAfterFade(sceneName));
    }

    private IEnumerator LoadSceneAfterFade(SceneName sceneName)
    {
        fadeManager.FadeOut();

        yield return new WaitForSeconds(fadeManager.fadeDuration);

        SceneManager.LoadScene(sceneName.ToString());
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

    public void LoadAdvancedScene()
    {
        LoadScene(SceneName.AdvancedRace);
    }

    public void LoadAdvancedDialogueScene()
    {
        LoadScene(SceneName.AdvancedRaceDialogue);
    }

    public void LoadBeginnerRace()
    {
        LoadScene(SceneName.BeginnerRace);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}


using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFadeSubscriber : MonoBehaviour
{
    public FadeManager fadeManager;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject); 
    }

    private void OnEnable()
    {
        SceneChangeNotifier.OnSceneChanged += HandleSceneChanged;
    }

    private void OnDisable()
    {
        SceneChangeNotifier.OnSceneChanged -= HandleSceneChanged;
    }

    private void HandleSceneChanged(Scene newScene)
    {
       
        fadeManager.FadeIn();
    }
}

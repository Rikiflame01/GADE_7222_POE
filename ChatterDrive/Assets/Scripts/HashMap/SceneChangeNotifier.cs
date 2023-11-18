using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeNotifier : MonoBehaviour
{
    public delegate void SceneChanged(Scene newScene);
    public static event SceneChanged OnSceneChanged;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject); 
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        OnSceneChanged?.Invoke(scene);
    }
}

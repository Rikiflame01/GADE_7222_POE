using UnityEngine;

public class PauseCanvasController : MonoBehaviour
{
    public GameObject pauseCanvas; 

    void OnEnable()
    {
        PauseManager.PauseCanvasTrigger += TogglePauseCanvas;
    }

    void OnDisable()
    {
        PauseManager.PauseCanvasTrigger -= TogglePauseCanvas;
    }

    private void TogglePauseCanvas(bool isPaused)
    {
        pauseCanvas.SetActive(isPaused);
    }
}

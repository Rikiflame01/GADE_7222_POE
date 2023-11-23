using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeManager : MonoBehaviour
{
    public CanvasGroup fadeCanvasGroup;
    public float fadeDuration = 1f;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void FadeOut()
    {
        Time.timeScale = 1;
        StartCoroutine(DoFade(1)); // Fade to black
    }

    public void FadeIn()
    {
        Time.timeScale = 1;
        StartCoroutine(DoFade(0)); // Fade from black
    }

    private IEnumerator DoFade(float targetAlpha)
    {
        float alpha = fadeCanvasGroup.alpha;
        for (float t = 0f; t < 1f; t += Time.deltaTime / fadeDuration)
        {
            fadeCanvasGroup.alpha = Mathf.Lerp(alpha, targetAlpha, t);
            yield return null;
        }
        fadeCanvasGroup.alpha = targetAlpha;
    }
}

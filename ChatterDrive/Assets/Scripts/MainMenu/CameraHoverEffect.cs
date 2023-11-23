using UnityEngine;

public class CameraHoverEffect : MonoBehaviour
{
    public float hoverAmplitude = 0.5f;
    public float hoverFrequency = 1f;

    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        float hover = hoverAmplitude * Mathf.Sin(Time.time * hoverFrequency);
        transform.position = originalPosition + new Vector3(0, hover, 0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Attributes: ")]
    [SerializeField] private float playerSpeed = 5f;
    [SerializeField] private float playerSpeedInc = 5f;
    [SerializeField] private float acceleration = 2f;
    [SerializeField] private float deceleration = 0.5f; // Adjusted for gradual deceleration
    public float playerRotateSpeed = 150f;
    public float rotationSmoothness = 10f;
    public float rotationMomentum = 0.9f;

    private float currentSpeed = 0f;
    private float currentRotation = 0f;

    PlayerInputActions playerInput;

    private void Awake()
    {
        playerInput = new PlayerInputActions();
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    private void Update()
    {
        GetPlayerMovement();
    }

    private void GetPlayerMovement()
    {
        Vector2 playerInputNormalized = playerInput.Player.Move.ReadValue<Vector2>().normalized;

        // Acceleration and Deceleration
        if (playerInputNormalized.y > 0)
        {
            currentSpeed += acceleration * Time.deltaTime;
        }
        else if (playerInputNormalized.y < 0)
        {
            currentSpeed -= acceleration * Time.deltaTime;
        }
        else
        {
            // Gradual deceleration for momentum
            if (currentSpeed > 0)
            {
                currentSpeed -= deceleration * Time.deltaTime;
            }
            else if (currentSpeed < 0)
            {
                currentSpeed += deceleration * Time.deltaTime;
            }
        }

        currentSpeed = Mathf.Clamp(currentSpeed, -playerSpeed, playerSpeed);

        // Smooth Rotation with Momentum
        float targetRotation = playerInputNormalized.x * playerRotateSpeed;
        if (Mathf.Abs(playerInputNormalized.x) > 0.1f) // If there's significant input
        {
            currentRotation = Mathf.Lerp(currentRotation, targetRotation, Time.deltaTime * rotationSmoothness);
        }
        else
        {
            currentRotation *= rotationMomentum;
        }

        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up * currentRotation * Time.deltaTime);
    }

    public void IncreasePlayerSpeed(float time)
    {
        StartCoroutine(IncreaseSpeedTimer(time));
    }

    IEnumerator IncreaseSpeedTimer(float time)
    {
        playerSpeed += playerSpeedInc;
        playerRotateSpeed += playerSpeedInc * 10;
        yield return new WaitForSeconds(time);
        playerSpeed -= playerSpeedInc;
        playerRotateSpeed -= playerSpeedInc * 10;
    }
}

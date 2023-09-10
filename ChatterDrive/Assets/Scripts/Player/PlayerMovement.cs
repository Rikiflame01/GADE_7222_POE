using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Varaibles for controlling player movement
    [Header("Movement Attributes: ")]
    [SerializeField] private float playerSpeed = 5f;
    [SerializeField] private float playerSpeedInc = 5f;
    public float playerRotateSpeed = 150f;

    PlayerInputActions playerInput;

    private void Awake()
    {
        //Set player Input
        playerInput = new PlayerInputActions();
    }

    //Enable and Disable input actions
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

        //Forwards and backwards input
        Vector3 zMovement = new Vector3(0, 0, playerInputNormalized.y);
        //Left and right rotation
        Vector3 yRotation = new Vector3(0, playerInputNormalized.x, 0);

        if(playerInputNormalized.magnitude > 0 )
        {
            //Move player forwards and backwards
            transform.Translate(zMovement * playerSpeed * Time.deltaTime);
            //Rotate player in the y plane
            transform.Rotate(yRotation * playerRotateSpeed * Time.deltaTime);
        }
    }

    public void IncreasePlayerSpeed(float time)
    {
        StartCoroutine(IncreaseSpeedTimer(time));
    }

    //Increase player speed after speed boost for time(s)
    IEnumerator IncreaseSpeedTimer(float time)
    {
        playerSpeed += playerSpeedInc;
        playerRotateSpeed += playerSpeedInc * 10;
        yield return new WaitForSeconds(time);
        playerSpeed -= playerSpeedInc;
        playerRotateSpeed -= playerSpeedInc * 10;
    }
}

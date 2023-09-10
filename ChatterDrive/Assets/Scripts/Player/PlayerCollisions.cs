using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public ChapterManager chapterManager;

    private void OnCollisionEnter(Collision collision)
    {


        if(collision.collider.CompareTag("Ground"))
        {
            

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Checkpoint"))
        {
            GameObject obj = other.gameObject;
            chapterManager.CheckpointReached();
            Debug.Log("Checkpoints Trigger");

        }

        if(other.CompareTag("SpeedBoost"))
        {
            playerMovement.IncreasePlayerSpeed(3f);
            other.gameObject.SetActive(false);
        }

        
    }
}

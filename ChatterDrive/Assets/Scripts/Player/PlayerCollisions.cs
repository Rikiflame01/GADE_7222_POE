using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86;

public class PlayerCollisions : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public CheckpointUI checkpointUI;
    public ChapterManager chapterManager;

    private void OnCollisionEnter(Collision collision)
    {
        //Check to see if player went out of bounds
        if(collision.collider.CompareTag("Ground"))
        {
            checkpointUI.ShowLoseScreen(true);
        }
        if (!collision.gameObject.CompareTag("RaceTrack"))
        {
            // This is a crash. Handle accordingly.
            HandleCrash();
        }

        void HandleCrash()
        {
            // Whatever you want to happen when the player crashes.
            Debug.Log("Player Crashed!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Check to see if player reached checkpoint and then fire an event
        if (other.CompareTag("Checkpoint"))
        {
            GameObject obj = other.gameObject;
            chapterManager.CheckpointReached();
            Debug.Log("Checkpoints Trigger");
            //other.gameObject.SetActive(false);

        }
        //Check to see if player triggered speed boost
        if (other.CompareTag("SpeedBoost"))
        {
            playerMovement.IncreasePlayerSpeed(3f);
            other.gameObject.SetActive(false);
        }

    }
}

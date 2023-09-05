using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    public ChapterManager chapterManager;

    private void OnCollisionEnter(Collision collision)
    {


        if(collision.collider.CompareTag("Checkpoint"))
        {
            GameObject obj = collision.collider.gameObject;
            chapterManager.CheckpointReached();
            Debug.Log("Checkpoints Collision");

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
    }
}

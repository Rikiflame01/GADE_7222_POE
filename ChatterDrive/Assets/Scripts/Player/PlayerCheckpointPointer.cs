using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckpointPointer : MonoBehaviour
{
    public ChapterManager chapterManager;
    public Transform target;
    public Vector3 targetOffset = new Vector3(2, 3, 1);
   
    void Update()
    {
        Transform chapterTransform = chapterManager.GetNextCheckpoint();

        if(chapterTransform != null )
        {
            Vector3 direction = transform.position - chapterTransform.position;

            transform.forward = -direction;
        }
        
    }

    private void LateUpdate()
    {
        transform.position = target.position + targetOffset;
    }
}

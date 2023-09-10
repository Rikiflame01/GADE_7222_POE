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
        //Use the chapter Manager to direct the arrow
        Transform chapterTransform = chapterManager.GetNextCheckpoint();

        if(chapterTransform != null )
        {
            Vector3 direction = transform.position - chapterTransform.position;

            transform.forward = -direction; // changes the arrows forward direction towards the direction of the Check point
        }
        
    }

    private void LateUpdate()
    {
        //Arrow follows player smoothly
        transform.position = target.position + targetOffset;
    }
}

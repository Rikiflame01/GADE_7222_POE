using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManagerTest : MonoBehaviour
{
    ADTQueue<int> test = new ADTQueue<int>();

    private void Start()
    {
        for(int i = 0; i < 5; i++)
        {
            test.Enqueue(i);
        }
        Debug.Log(test.ToString());
        test.Dequeue();
        Debug.Log(test.ToString());
        test.Enqueue(1);
        test.Enqueue(99);
        test.Dequeue();
        Debug.Log(test.ToString());
    }
}

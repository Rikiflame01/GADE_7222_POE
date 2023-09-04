using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterManager : MonoBehaviour
{
    ChapterStack<int> chapterStack = new ChapterStack<int>();

    private void Start()
    {
        for(int i = 0; i < 5; i++)
        {
            chapterStack.Push(i);
        }
        Debug.Log(chapterStack.ToString());
        //int poppedInt = chapterStack.Pop();
        //Debug.Log("Last int: " + poppedInt);
        //Debug.Log(chapterStack.ToString());
    }
}

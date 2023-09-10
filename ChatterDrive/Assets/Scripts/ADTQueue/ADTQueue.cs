using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class ADTQueue<T>
{
    LinkedListOne<T> list = new LinkedListOne<T>();

    public void Enqueue(T item)
    {
        list.InsertAtEnd(item);
    }

    public T Dequeue()
    {
        if(list.Size() == 0)
        {
            throw new InvalidOperationException("Queue is empty");
        }
        else
        {
            T item = list.Start.Data;
            list.DeleteFromStart();
            return item;
            
        }
    }

    public T Peek()
    {
        if (list.Size() == 0)
        {
            string currentSceneName = SceneManager.GetActiveScene().name;

            if (currentSceneName == "CheckpointRaceDialogue")
            {
                SceneManager.LoadScene("CheckpointRace");
                return default(T);
            }
            else if (currentSceneName == "Beginner Race Dialogue")
            {
                throw new InvalidOperationException("Not Implemented");
            }
            else if (currentSceneName == "Advanced Race Dialogue")
            {
                throw new InvalidOperationException("Not Implemented");
            }
            else
            {
                throw new InvalidOperationException("Queue is empty");
            }
        }
        else
        {
            return list.Start.Data;
        }
    }

    public override string ToString()
    {

        if (list.Size() == 0)
        {
            return string.Empty;
        }

        if (list.Size() == 1 && list.Start != null)
        {
            return list.Start.Data.ToString();
        }    
                           
        NodeOne<T> current = list.Start;
        string concatenate = "";
        while (current != null)
        {
            concatenate += $"{current.Data.ToString()} -> ";
            current = current.Next;
        }

        return concatenate.ToString();
    }

    public int Count => list.Size();
}

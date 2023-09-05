using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LinkedListOne<T>
{
    public NodeOne<T> Start { get; set; }
    public NodeOne<T> End { get; set; }
    private int size;

    public int Size()
    {
        return size;
    }

    public bool IsEmpty()
    {
        return size == 0;
    }

    //Stack
    public void InsertAtStart(T data)
    {
        NodeOne<T> node = new NodeOne<T>(data);
        if (Start == null)
        {
            Start = node;
            End = node;
        }
        else
        {
            node.Next = Start;
            Start = node;
        }
        size++;
    }

    //Queue
    public void DeleteFromStart()
    {
        if(Start != null)
        {
            Start = Start.Next;
            size--;
            if(Start == null)
            {
                End = null;
            }
        }
    }

    public void InsertAtEnd(T data)
    {
        NodeOne<T> node = new NodeOne<T>(data);
        if (Start == null)
        {
            Start = node;
            End = node;
        }
        else
        {
            End.Next = node;
            End = node;
           //end = node
        }
        size++;
    }

    public void DeleteFromEnd()
    {
        if(size == 0)
        {
            return;
        }

        if(size == 1)
        {
            Start = End = null;
            size = 0;
            return;
        }

        NodeOne<T> currentNode = Start;
        //Get the node before the last node
        for(int i = 1; i < size -1; i++)
        {
            //Check to see if the next node is not null
            if(currentNode.Next != null)
            {
                currentNode = currentNode.Next;
            }
                       
        }
        
        //Set the next node = null as current node is = second last node
        //Set the end node = current node
        if(currentNode.Next != null)
        {
            currentNode.Next = null;
            End = currentNode;
        }
        
        size--;
        if(size == 0)
        {
            Start = End = null;
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        NodeOne<T> currentNode = Start;
        for(int i = 0; i < size; i++)
        {
            currentNode = currentNode.Next;
            
        }
        size--;
        currentNode.Next = null;
        End = currentNode;
      
    }
}

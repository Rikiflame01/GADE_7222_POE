using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkedListOne<T>
{
    public NodeOne<T> Start { get; set; }
    private NodeOne<T> end;
    private int size;

    public int Size()
    {
        return size;
    }

    public bool IsEmpty()
    {
        return size == 0;
    }

    //public void InsertAtStart(T data)
    //{
    //    NodeOne<T> node = new NodeOne<T>(data);
    //    if(Start == null)
    //    {
    //        Start = node;
    //        end = node;
    //    }
    //    else
    //    {
    //        node.Next = Start;
    //        Start = node;
    //    }
    //    size++;
    //}

    public void DeleteFromStart()
    {
        if(Start != null)
        {
            Start = Start.Next;
            size--;
            if(Start == null)
            {
                end = null;
            }
        }
    }

    public void InsertAtEnd(T data)
    {
        NodeOne<T> node = new NodeOne<T>(data);
        if (Start == null)
        {
            Start = node;
            end = node;
        }
        else
        {
            end.Next = node;
            end = node;
           //end = node
        }
        size++;
    }
}

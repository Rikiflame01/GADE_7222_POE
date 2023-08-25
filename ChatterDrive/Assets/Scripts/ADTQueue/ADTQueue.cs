using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if(list.Size() == 0)
        {
            throw new InvalidOperationException("Queue is empty");
        }
        else
        {
            return list.Start.Data;
        }
    }

    public int Count => list.Size();
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListQueue<T>
{
    private List<T> list;
    private int front = 0;
    private int end;

    public ListQueue()
    {
        front = 0;
        end = -1;
    }

    public void Enqueue(T item)
    {
        if(end == list.Count -1)
        {
            throw new InvalidOperationException("Queue is empty");
        }
        else
        {
            list.Add(item);

        }
    }

    public T Dequeue()
    {
        if (front > end)
            throw new InvalidOperationException("Queue is empty.");
        T item = list[front];
        list.RemoveAt(front);
        return item;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterStack<T>
{
    LinkedListOne<T> list = new LinkedListOne<T>();
    public int Count => list.Size();
    public bool IsEmpty => list.IsEmpty();

    public void Push(T item)
    {
        list.InsertAtEnd(item);
    }

    public T Pop()
    {
        if(list.Size() == 0)
        {
            throw new InvalidOperationException("Stack is empty");
        }
        T item = list.End.Data;
        list.DeleteFromEnd();
        return item;
    }

    public T Peek()
    {
        if (list.Size() == 0)
        {
            throw new InvalidOperationException("Stack is empty");
        }
        return list.End.Data;
    }

    
}

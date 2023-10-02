using System;

[System.Serializable]
public class ChapterStack<T>
{
    //Get reference to LinkedListOne
    LinkedListOne<T> list = new LinkedListOne<T>();
    public int Count => list.Size();
    public bool IsEmpty => list.IsEmpty();

    //Push node to end of list
    public void Push(T item)
    {
        list.InsertAtEnd(item);
        //InsertAtHead
    }

    //Pop last node in list and delete from list
    public T Pop()
    {
        if(list.Size() == 0) //Exception for empty stack
        {
            throw new InvalidOperationException("Stack is empty");
        }
        T item = list.End.Data;
        list.DeleteFromEnd();
        return item;
    }

    //Peek the top of the list/ plates
    public T Peek()
    {
        if (list.Size() == 0)//Exception for empty stack
        {
            throw new InvalidOperationException("Stack is empty");
        }
        return list.End.Data;
    }

    //Function for printing out the stack list
    public override string ToString()
    {

        if (list.Size() == 0)
        {
            return string.Empty;
        }

        if (list.Size() == 1 && list.Start != null)
        {
            //print the first and only nodes data
            return list.Start.Data.ToString();
        }

        NodeOne<T> current = list.Start;
        //Get first node in list
        string concatenate = "";
        while (current != null)
        {
            //print out all the nodes data/value in the list
            concatenate += $"{current.Data.ToString()} -> ";
            current = current.Next;
        }

        //return the concatented string of all the nodes data in the list
        return concatenate.ToString();
    }


}

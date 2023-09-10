using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LinkedListOne<T>
{
    //Head and Tail Node using Start and End Node
    public NodeOne<T> Start { get; set; }
    public NodeOne<T> End { get; set; }
    private int size;

    public int Size()
    {
        //Return the size of the linked list
        return size;
    }

    public bool IsEmpty()
    {
        return size == 0;
    }

    //Queue
    public void DeleteFromStart()
    {
        //Check if empty
        if(IsEmpty())
        {
            return;
        }

        if(Start != null)
        {
            //Replace start node with the next node and decrease size of linked list
            Start = Start.Next;
            size--;
            if(Start == null)
            {
                End = null;
            }
        }
    }

    //Stack and Queue
    public void InsertAtEnd(T data)
    {
        NodeOne<T> node = new NodeOne<T>(data);
        //If first node then Start and End = node
        if (Start == null)
        {
            Start = node;
            End = node;
        }
        else //Link the new node to the end node, end node is now node
        {
            End.Next = node;
            End = node;
           //end = node
        }
        size++;
        //Increase size of linked list
    }

    //Stack
    public void DeleteFromEnd()
    {
        if(IsEmpty())
        {
            return;
        }

        //If list contains 1 node then set Start and End to null as list is now empty
        if(size == 1)
        {
            Start = null;
            End = null;
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
        //Set the end node = current node as it is 2 before end so last gets deleted
        if(currentNode.Next != null)
        {
            currentNode.Next = null;
            End = currentNode;
        }
        
        size--; //Decrease the size of list

    }
}

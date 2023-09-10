using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NodeOne<T>
{
    //Set up Node class
    public T Data { get; set; }
    public NodeOne<T> Next { get; set; }

    //Node One Constructor set this.Data to data
    public NodeOne(T data)
    {
        Data = data;
        Next = null;
    }

}

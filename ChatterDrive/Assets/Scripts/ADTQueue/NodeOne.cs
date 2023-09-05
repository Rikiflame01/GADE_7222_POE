using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NodeOne<T>
{
    public T Data { get; set; }
    public NodeOne<T> Next { get; set; }

    public NodeOne(T data)
    {
        Data = data;
        Next = null;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

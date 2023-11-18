using System;
using UnityEngine;

[System.Serializable]
public class CustomHashmap<TKey, TValue>
{
    private LinkedListOne<KeyValue<TKey, TValue>>[] buckets;
    private int size;

    public CustomHashmap(int size)
    {
        this.size = size;
        buckets = new LinkedListOne<KeyValue<TKey, TValue>>[size];
        for (int i = 0; i < size; i++)
        {
            buckets[i] = new LinkedListOne<KeyValue<TKey, TValue>>();
        }
    }

    private int GetBucketIndex(TKey key)
    {
        int hashCode = key.GetHashCode();
        int index = hashCode % size;
        return Math.Abs(index);
    }

    public void Add(TKey key, TValue value)
    {
        int index = GetBucketIndex(key);
        var keyValue = new KeyValue<TKey, TValue>(key, value); // Create KeyValue pair
        buckets[index].InsertAtEnd(keyValue); // Pass KeyValue pair directly
        // Note: This does not handle collisions by checking existing keys. But it should be fine for the sake of this project.
    }

    public TValue Get(TKey key)
    {
        int index = GetBucketIndex(key);
        var currentNode = buckets[index].Start;
        while (currentNode != null)
        {
            if (currentNode.Data.Key.Equals(key))
            {
                return currentNode.Data.Value;
            }
            currentNode = currentNode.Next;
        }
        return default(TValue); // Return default value if key not found
    }
}
// This is not the most advanced implementation, as if for some reason
// there is a large amount of elements, the hash function will not be very efficient.
// in the future, resizing of the buckets should be implemented. (For efficiency)

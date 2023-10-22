using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SortingAlgorithms
{
    public static int[] MergeSort(int[] unsorted)
    {
        if(unsorted.Length == 0) return unsorted;

        int middle = unsorted.Length / 2;
        int upper = unsorted.Length -  middle;

        //Divided arrays
        int[] left = new int[middle];
        int[] right = new int[upper];

        for(int i = 0; i < middle; i++)
        {
            left[i] = unsorted[i];
        }
        for(int i = middle; i < unsorted.Length; i++)
        {
            right[i] = unsorted[i];
        }

        left = MergeSort(left);
        right = MergeSort(right);
        return Merge(left, right);
    }

    private static int[] Merge(int[] left, int[] right)
    {
        int[] result = new int[left.Length + right.Length];

        int leftSide = 0;
        int rightSide = 0;
        int combined = 0;

        while (leftSide < left.Length && rightSide < right.Length)
        {
            if (left[leftSide] <= right[rightSide])
            {
                result[combined++] = left[leftSide++];
            }
            else
            {
                result[combined++] = right[rightSide++];
            }
        }

        while (leftSide < left.Length)
        {
            result[combined++] = left[leftSide++];
        }

        while (rightSide < right.Length)
        {
            result[combined++] = right[rightSide++];
        }

        return result;
    }

}


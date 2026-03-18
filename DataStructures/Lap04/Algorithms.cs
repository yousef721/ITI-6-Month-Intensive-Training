using System;

namespace Lap04;

public class Algorithms
{
    public static void BubbleSort(Employee[] arr)
    {
        for(int i = 0; i < arr.Length - 1; i++)
        {
            for(int j = 0; j < arr.Length - i - 1; j++)
            {
                if(arr[j].CompareTo(arr[j+1]) > 0)
                {
                    Employee temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }

    public static int BinarySearch(Employee[] arr, DateTime target)
    {
        int left = 0;
        int right = arr.Length - 1;

        while(left <= right)
        {
            int mid = (left + right) / 2;

            if(arr[mid].HireDate == target)
                return mid;

            if(arr[mid].HireDate < target)
                left = mid + 1;
            else
                right = mid - 1;
        }

        return -1;
    }

    public static int BinarySearchRec(Employee[] arr, int left, int right, DateTime target)
    {
        if (left > right)
            return -1;

        int mid = (left + right) / 2;

        if (arr[mid].HireDate == target)
            return mid;

        if (arr[mid].HireDate < target)
            return BinarySearchRec(arr, mid + 1, right, target);

        return BinarySearchRec(arr, left, mid - 1, target);
    }
}

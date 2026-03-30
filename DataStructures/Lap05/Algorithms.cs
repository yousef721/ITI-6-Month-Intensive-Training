using System;

namespace Lap05;

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

    public static void SelectionSort(Employee[] arr)
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < arr.Length; j++)
            {
                if (arr[minIndex].CompareTo(arr[j]) > 0)
                {
                    minIndex = j;
                }
            }
            // swap 
            (arr[minIndex], arr[i]) = (arr[i], arr[minIndex]);
        }
    }

    public static void Merge(Employee[] arr, int low, int middle, int high)
    {
        Employee[] temp = new Employee[high - low + 1];
        int list1 = low;
        int list2 = middle + 1;
        int i = 0;
        while (list1 <= middle && list2 <= high)
        {
            if (arr[list1].CompareTo(arr[list2]) > 0)
            {
                temp[i] = arr[list2];
                list2++;
                i++;
            } else
            {
                temp[i] = arr[list1];
                list1++;
                i++;
            }
        }
        while (list1 <= middle)
        {
            temp[i] = arr[list1];
            list1++;
            i++;
        }
        while (list2 <= high)
        {
            temp[i] = arr[list2];
            list2++;
            i++;
        }
        for (int j = 0; j < temp.Length; j++)
        {
            arr[low + j] = temp[j];
        }
    }

    public static void MergeSort(Employee[] arr, int left, int right)
    {
        if (left >= right) return;
        int middle = (left + right) / 2;
        MergeSort(arr, left, middle);
        MergeSort(arr, middle + 1, right);
        Merge(arr, left, middle, right);
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

namespace Lap05;

public class Queue : DataStructure
{
    int front; // remove
    int end; // add
    int count; // Number of items in the queue

    public Queue() : base()
    {
        front = 0;
        end = 0;
    }

    public Queue(int _size) : base(_size)
    {
        front = 0;
        end = 0;
    }

    public void Enqueue(int number)
    {
        if (!IsFull())
        {
            arr[end] = number;
            end = (end + 1) % size; // Circle Cycle // 0 + 1 % 3 = 1, 1 + 1 % 3 = 2, 2 + 1 % 3 = 0; if end == size repeat
            count++;
        }
    }

    public int Dequeue()
    {
        if (!IsEmpty())
        {
            int temp = arr[front];
            front = (front + 1) % size; // Circle Cycle // 0 + 1 % 3 = 1, 1 + 1 % 3 = 2, 1 + 1 % 3 = 3; end == size repeat
            count--;
            return temp;
        }
        return -1;
    }

    public bool IsFull()
    {
        return count == size;
    }

    public bool IsEmpty()
    {
        return count == 0;
    }

    public string Display()
    {
        string str = "Queue => {";

        for (int i = 0; i < count; i++)
        {
            // from first item to until count of items
            int index = (front + i) % size; // {0,0,0,( 1 is front),2,3} => first + 0 % 6 = 3 + 0 % 6 = 3; // 3
            str += arr[index];

            if (i != count - 1)
                str += ",";
        }

        str += "}";
        return str;
    }

}

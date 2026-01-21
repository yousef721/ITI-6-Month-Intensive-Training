namespace Lap05;

public class Stack : DataStructure
{
    int top;

    public Stack() : base()
    {
        top = 0;
    }
    public Stack(int _size) : base(_size)
    {
        top = 0;
    }

    public void Push(int number)
    {
        if (!IsFull())
        {
            arr[top++] = number; // postfix
        }
    }
    public int Pop()
    {
        if (!IsEmpty())
        {
            return arr[--top];
        } else
        {
            return int.MinValue; // -2147483648;
        }
    }

    public bool IsFull()
    {
        return top == size;
    }
    public bool IsEmpty()
    {
        return top == 0;
    }

    public string Display()
    {
        string str;
        str = "Stack => {";
        for (int i = 0; i < top; i++)
        {
            str += arr[i];
            if(i != top - 1) // last number in stack
            {
                str += ',';
            }
        }
        str += '}';
        return str;
    }

    public static Stack operator+(Stack left, Stack right)
    {
        Stack result = new Stack(left.size + right.size);

        // left
        for (int i = 0; i < left.top; i++)
        {
            result.Push(left.arr[i]);
        }

        // right
        for (int i = 0; i < right.top; i++)
        {
            result.Push(right.arr[i]);
        }

        return result;
    }
}


using System;

namespace Lap03;

class Program
{
    static void Main(string[] args)
    {
        #region Task 1
            Console.WriteLine("===== Stack =====");

            Stack stack = new Stack(5);

            stack.Push(10);
            stack.Push(20);
            stack.Push(30);

            Console.WriteLine("Top Element: " + stack.Peek());

            Console.WriteLine("Pop: " + stack.Pop());
            Console.WriteLine("Pop: " + stack.Pop());

            Console.WriteLine("Top Element After Pop: " + stack.Peek());
        #endregion

        #region Task 2
            // Console.WriteLine("\n===== Queue =====");

            // Queue queue = new Queue(5);

            // queue.Enqueue(100);
            // queue.Enqueue(200);
            // queue.Enqueue(300);

            // Console.WriteLine("Front Element: " + queue.Front());

            // Console.WriteLine("Dequeue: " + queue.Dequeue());
            // Console.WriteLine("Dequeue: " + queue.Dequeue());

            // Console.WriteLine("Front Element After Dequeue: " + queue.Front());
        #endregion

        #region Task 3
            // Console.WriteLine("\n===== Reverse a String using a Stack =====");

            // string str;
            // Console.WriteLine("Enter Your String");

            // str =  Console.ReadLine();

            // int length = str.Length;

            // int[] arr = new int[length];
            
            // for (int i = 0; i < length; i++)
            // {
            //     arr[i] = str[i];
            // }

            // Stack stack = new Stack(length, arr);

            // char[] reversed = new char[length];

            // for (int i = 0; i < length; i++)
            // {
            //     reversed[i] = (char)stack.Pop();
            // }
            // string result = new string(reversed);

            // Console.WriteLine(result);
        #endregion

        #region Task 4
            // Console.WriteLine("\n===== Check Balanced Parentheses using Stack =====");

            // Console.WriteLine("Enter Your String:");
            // string str = Console.ReadLine();

            // Stack stack = new Stack(str.Length);

            // bool isBalanced = true;

            // for (int i = 0; i < str.Length; i++) //str = '(())' stack = '' // str = ')(()' stack = ''
            // {
            //     if (str[i] == '(')
            //     {
            //         stack.Push(str[i]);
            //     }
            //     else if (str[i] == ')')
            //     {
            //         if (stack.IsEmpty())
            //         {
            //             isBalanced = false;
            //             break;
            //         }

            //         stack.Pop();
            //     }
            // }

            // if (!stack.IsEmpty()) // ((()
            // {
            //     isBalanced = false;
            // }

            // Console.WriteLine(isBalanced ? "Balanced" : "Not Balanced");
        #endregion

        #region Task 5 (Bouns)
            // Console.WriteLine("===== Queue Using Two Stacks =====");

            // QueueTwoStacks queue = new QueueTwoStacks(5);

            // queue.Enqueue(10);
            // queue.Enqueue(20);
            // queue.Enqueue(30);

            // Console.WriteLine("Front element: " + queue.Front());

            // Console.WriteLine("Dequeue: " + queue.Dequeue());

            // Console.WriteLine("Front element after Dequeue: " + queue.Front());

            // queue.Enqueue(40);
            // queue.Enqueue(50);
            // queue.Enqueue(60);

            // Console.WriteLine("After Queue Is Full : " + queue.Enqueue(70));

            // while (!queue.IsEmpty())
            // {
            //     Console.WriteLine("Dequeue: " + queue.Dequeue());
            // }

            // Console.WriteLine("Queue is empty? " + queue.IsEmpty());
        #endregion
    }
}
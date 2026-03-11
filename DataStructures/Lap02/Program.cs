using Lap01;

namespace Lap02;

class Program
{
    static void Main(string[] args)
    {
        // ================= STACK =================
        Console.WriteLine("===== STACK =====\n");

        Stack stack = new Stack();

        Employee e1 = new Employee(1, 25, 5000, "HR");
        Employee e2 = new Employee(2, 30, 7000, "IT");
        Employee e3 = new Employee(3, 28, 6000, "IT");

        // Push
        stack.Push(e1);
        stack.Push(e2);
        stack.Push(e3);

        Console.WriteLine("Stack after pushing 3 employees:");
        stack.Display();

        // Peek
        Console.WriteLine("\nPeek top of stack:");
        Console.WriteLine(stack.Peek());

        // Pop
        Console.WriteLine("\nPop top of stack:");
        stack.Pop();
        stack.Display();

        // IsEmpty
        Console.WriteLine("\nIs stack empty? " + stack.IsEmpty());

        // Pop remaining
        stack.Pop();
        stack.Pop();
        Console.WriteLine("\nStack after popping all elements:");
        stack.Display();
        Console.WriteLine("Is stack empty? " + stack.IsEmpty());

        // ================= QUEUE =================
        Console.WriteLine("\n===== QUEUE =====\n");

        Queue queue = new Queue();

        Employee q1 = new Employee(4, 35, 9000, "HR");
        Employee q2 = new Employee(5, 29, 8000, "IT");
        Employee q3 = new Employee(6, 32, 7500, "IT");

        // Enqueue
        queue.Enqueue(q1);
        queue.Enqueue(q2);
        queue.Enqueue(q3);

        Console.WriteLine("Queue after enqueuing 3 employees:");
        queue.Display();

        // Peek
        Console.WriteLine("\nPeek front of queue:");
        Console.WriteLine(queue.Peek());

        // Dequeue
        Console.WriteLine("\nDequeue front of queue:");
        queue.Dequeue();
        queue.Display();

        // IsEmpty
        Console.WriteLine("\nIs queue empty? " + queue.IsEmpty());

        // Dequeue remaining
        queue.Dequeue();
        queue.Dequeue();
        Console.WriteLine("\nQueue after dequeuing all elements:");
        queue.Display();
        Console.WriteLine("Is queue empty? " + queue.IsEmpty());
    }
}

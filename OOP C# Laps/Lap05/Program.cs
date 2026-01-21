using System.Drawing;
using Lap03;

namespace Lap05;

class Program
{
    static void Main()
    {

            #region Dynamic Stack
                // //1-dynamic Stack
                // int size = 0;
                // do
                // {
                //     Console.Write("Enter Size Of Stack : ");
                //     size = int.Parse(Console.ReadLine());
                // } while (size <= 0);
 

                // Stack stack = new Stack(size);
                
                // char isWant = 'y'; // check user what you need?
                // int i = 1; // count item only
                // int number; // item set by user
                // // add
                // while (isWant == 'y')
                // {
                //     if (!stack.IsFull())
                //     {
                //         Console.Write($"Enter Number {i++} To Stack : ");
                //         number = int.Parse(Console.ReadLine());
                //         stack.Push(number);

                //         Console.WriteLine($"Do you want to add a new number? y - n");
                //         isWant = char.Parse(Console.ReadLine());         
                //     } else 
                //     {
                //         Console.WriteLine("Stack Is Full");
                //         isWant = 'n';
                //     }
                // }

                // // Edit After Add
                // while(isWant != 'e')
                // {
                //     Console.WriteLine("Do you want to (Display press => d), (Pop press => r), (Push press => a), (Exit press => e)");
                //     isWant = char.Parse(Console.ReadLine());

                //     switch (isWant)
                //     {
                //         case 'd':
                //             Console.WriteLine(stack.Display());
                //             break;
                //         case 'r':
                //             if(!stack.IsEmpty())
                //             {
                //                 stack.Pop();
                //                 Console.WriteLine("Success");                                
                //             }else
                //             {
                //                 Console.WriteLine("Stack Is Empty");                                
                //             }
                //             break;
                //         case 'a':
                //             if(!stack.IsFull())
                //             {
                //                 Console.Write("Enter Number : ");
                //                 number = int.Parse(Console.ReadLine());
                //                 stack.Push(number);
                //                 Console.WriteLine("Success");
                //                 break;
                //             }
                //             Console.WriteLine("Stack Is Full");
                //             break;
                //         default:
                //             isWant = 'e';
                //             break;
                //     }
                // }

            #endregion
            
            #region Queue
                // 2- queue
                // int size = 0;
                // do
                // {
                //     Console.Write("Enter Size Of Queue : ");
                //     size = int.Parse(Console.ReadLine());
                // } while (size <= 0);


                // Queue queue = new Queue(size);
                
                // char isWant = 'y';
                // int i = 1;
                // int number;
                // // Add
                // while (isWant == 'y')
                // {
                //     if (!queue.IsFull())
                //     {
                //         Console.Write($"Enter Number {i++} To queue : ");
                //         number = int.Parse(Console.ReadLine());
                //         queue.Enqueue(number);

                //         Console.WriteLine($"Do you want to add a new number? y - n");
                //         isWant = char.Parse(Console.ReadLine());         
                //     } else 
                //     {
                //         Console.WriteLine("Queue Is Full");
                //         isWant = 'n';
                //     }
                // }

                // // Edit After Add
                // while(isWant != 'e')
                // {
                //     Console.WriteLine("Do you want to (Display press => d), (Dequeue press => r), (Enqueue press => a), (Exit press => e)");
                //     isWant = char.Parse(Console.ReadLine());

                //     switch (isWant)
                //     {
                //         case 'd':
                //             Console.WriteLine(queue.Display());
                //             break;
                //         case 'r':
                //             if(!queue.IsEmpty())
                //             {
                //                 queue.Dequeue();
                //                 Console.WriteLine("Success");                                
                //             }else
                //             {
                //                 Console.WriteLine("Queue Is Empty");                                
                //             }
                //             break;
                //         case 'a':
                //             if(!queue.IsFull())
                //             {
                //                 Console.Write("Enter Number : ");
                //                 number = int.Parse(Console.ReadLine());
                //                 queue.Enqueue(number);
                //                 Console.WriteLine("Success");
                //                 break;
                //             }
                //             Console.WriteLine("Queue Is Full");
                //             break;
                //         default:
                //             isWant = 'e';
                //             break;
                //     }
                // }
            #endregion
            
            #region Complex Operator Overloading
                // 3- Complex c1+c2,c1+10,10+c1 ,c1==c2,c1!=c2

                // Complex complex1 = new Complex(2,3);
                // Complex complex2 = new Complex(2,3);
                // Complex complex3 = new Complex(6,7);
                
                // // c1+c2
                // Console.WriteLine(complex1.Print());
                // Console.WriteLine(complex2.Print());
                // complex3 = complex1 + complex2;
                // Console.WriteLine(complex3.Print());
                
                // Console.WriteLine("===============================");


                // // c1+10
                // Console.WriteLine(complex1.Print());
                // Console.WriteLine("10");
                // complex3 = complex1 + 10;
                // Console.WriteLine(complex3.Print());

                // Console.WriteLine("===============================");
                
                // // 10+c1
                // Console.WriteLine(complex2.Print());
                // Console.WriteLine("10");
                // complex3 = 10 + complex2;
                // Console.WriteLine(complex3.Print());
                
                // Console.WriteLine("===============================");

                // Console.WriteLine(complex1 == complex2);
                // Console.WriteLine(complex1 != complex2);
            #endregion 

            #region Concatenation Between Two Stacks
                // 4- Concatenation Between Two Stacks
                Stack s1 = new Stack(10);
                Stack s2 = new Stack();
                Stack s3 = new Stack(15);

                // Stack 1
                s1.Push(10);
                s1.Push(20);
                s1.Push(30);

                // Stack 2
                s2.Push(40);
                s2.Push(50);

            
                s3 = s1 + s2;   // concatenation

                // Display
                Console.WriteLine(s3.Display());


                Console.WriteLine(s3.Pop()); // 50
                Console.WriteLine(s3.Pop()); // 40
                Console.WriteLine(s3.Pop()); // 30
                Console.WriteLine(s3.Pop()); // 20
                Console.WriteLine(s3.Pop()); // 10

            #endregion

    }
}

namespace Lap02;

class Program
{

    static void Main(string[] args)
    {
        /*
            lab assignments
                - READ ALL DATA FROM USER AT RUNTIME
                - DON`T USE BUILT IN FNs
                - Each assignment in separate region
        */

        #region Tasks 1D array
            // 1- array of 10 integers and get min and max value   |5|4|2|-1|-33|55|66|77|88|100|
            #region Task01

                // int[] array = [5,4,2,-1,-33,55,66,77,88,100];
                // int max = -2147483648;
                // int min = 2147483647;
                // for (int i = 0; i < 10; i++)
                // {
                //     if(array[i] > max)
                //     {
                //         max = array[i];
                //     }
                //     if(array[i] < min)
                //     {
                //         min = array[i];
                //     }
                // }
                // Console.WriteLine($"Max is {max}");
                // Console.WriteLine($"Min is {min}");
            #endregion
            
            // 2- array of 10 integers and sort it ascending without any built in function
            #region Task02

            // int[] array = [5,4,2,-1,-33,55,66,77,88,100];
            // for (int i = 0; i < 10; i++)
            // {
            //     for (int j = 0; j < 10 - i - 1; j++)
            //     {
            //         if(array[j] > array[j + 1])
            //         {
            //             int temp = array[j + 1];
            //             array[j + 1] = array[j];
            //             array[j] = temp;
            //         }
            //     }
            // }
            // for (int i = 0; i < 10; i++)
            // {
            //     Console.WriteLine(array[i]);
            // }
            #endregion
            
            //3- array of 10 integers and search number and get index
            #region Task03

            // int[] array = [5,4,2,-1,-33,55,66,77,88,100];
            // bool isFound = false;
            // while (!isFound) // isFound == false
            // {
            //     Console.WriteLine("Enter number to search");
            //     int numSearch = int.Parse(Console.ReadLine());
            //     for (int i = 0; i < 10; i++)
            //     {
            //         if (numSearch == array[i])
            //         {
            //             Console.WriteLine($"Found at index {i}");
            //             isFound = true;
            //         }
            //     }
            //     if (!isFound) // isFound == false
            //     {
            //         Console.WriteLine("Not found");
            //     }
            // }
            #endregion
            
        #endregion

        #region Task 2D array
            //4- array of 3 rows,4 cols read and write

            int row, column;
            
            Console.WriteLine("Enter number of rows");
            row = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter number of column");
            column = int.Parse(Console.ReadLine());

            int[,] array = new int[row,column];

            // Read
            for (int i = 0; i < row; i++) 
            {
                for (int j = 0; j < column; j++)
                {
                    Console.WriteLine($"Row {i + 1}, Column {j + 1}");
                    array[i,j] = int.Parse(Console.ReadLine());
                }
            }
            // Write
            for (int i = 0; i < row; i++) 
            {
                for (int j = 0; j < column; j++)
                {
                    Console.Write($"|{array[i,j]}|\t");
                }
                Console.WriteLine();
            }
        #endregion
    
        #region Calculate your birth date
            
        #endregion
    }
}

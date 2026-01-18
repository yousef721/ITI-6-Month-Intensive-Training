namespace Lap02;

struct Employee
{
    public int id;
    public string name;
    public int age;
    public float salary;
}

class Program
{
    static void Main()
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
                // int max = array[0];
                // int min = array[0];
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

            // int[] array = [5,4,2,-1,-33,55,66,77,88,100]; // Bubble sort
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
            //     for (int i = 0; i < 10; i++) // linear search
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

        #region 2D array
            //4- array of 3 rows,4 cols read and write

            // int row, column;
            
            // Console.WriteLine("Enter number of rows");
            // row = int.Parse(Console.ReadLine());
            // Console.WriteLine("Enter number of column");
            // column = int.Parse(Console.ReadLine());

            // int[,] array = new int[row,column];

            // // Read
            // for (int i = 0; i < row; i++) 
            // {
            //     for (int j = 0; j < column; j++)
            //     {
            //         Console.WriteLine($"Row {i + 1}, Column {j + 1}");
            //         array[i,j] = int.Parse(Console.ReadLine());
            //     }
            // }
            // // Write
            // for (int i = 0; i < row; i++) 
            // {
            //     for (int j = 0; j < column; j++)
            //     {
            //         Console.Write($"|{array[i,j]}|\t");
            //     }
            //     Console.WriteLine();
            // }
        #endregion

        #region Calculate your birth date (My Code)

            //5- calculate your birth date
            
            //1,3,5,7,8,10,12     31days
            //4,6,9,11           30 days
            //2      28,29 leap year    2000,2004,2008,2020

            /////plz enter your year from 1980->2025
            //1900
            /////plz enter your year from 1980->2025
            //2001
            /////plz enter your month 1-12
            //22
            /////plz enter your month 1-12
            ///2
            /////plz enter your day
            //32
            /////plz enter your day
            //29
            /////plz enter your day
            //28

            // // Get current date
            // DateTime today = DateTime.Now;

            // // Variables for birth date
            // int year, month, day;

            // // ================= YEAR INPUT =================
            // // Ask user to enter a valid birth year
            // do
            // {
            //     Console.WriteLine("plz enter your year from 1980 -> 2026");
            //     year = int.Parse(Console.ReadLine());

            // } while (year < 1980 || year > 2026);

            // // Check if birth year is a leap year
            // bool isLeapYear = year % 4 == 0;

            // // Days in each month (February depends on leap year)
            // int[] monthsArr = [31, isLeapYear ? 29 : 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];

            // // ================= MONTH INPUT =================
            // // Ask user to enter a valid month
            // do
            // {
            //     Console.WriteLine("plz enter your month 1 -> 12");
            //     month = int.Parse(Console.ReadLine());

            // } while (month < 1 || month > 12);

            // // ================= DAY INPUT =================
            // // Ask user to enter a valid day based on the selected month
            // do
            // {
            //     Console.WriteLine($"plz enter your day 1 -> {monthsArr[month - 1]}");
            //     day = int.Parse(Console.ReadLine());

            // } while (day < 1 || day > monthsArr[month - 1]);

            // // Variables for calculated age
            // float years;
            // int months = 0;
            // int days;

            // // ================= AGE CALCULATION =================

            // // Case 1: Birthday has NOT occurred yet this year
            // // if birthMonth 7 and current month 1 or month is same month but my birth day not occurred
            // if (month > today.Month || (month == today.Month && day > today.Day))
            // {
            //     // Calculate full years excluding the current year
            //     float daysCompleteYears = (today.Year - year - 1) * 365.25f;

            //     // Remaining days in the birth year after birthday
            //     int remindDaysOfLastYear = 0;

            //     // Days passed in the current year before today
            //     int daysPassedFromCurrentYear = 0;

            //     // Sum days from birth month to end of birth year
            //     for (int i = month - 1; i < 12; i++)
            //     {
            //         remindDaysOfLastYear += monthsArr[i];
            //     }

            //     // Sum days from beginning of current year to current month
            //     for (int i = 0; i < today.Month - 1; i++)
            //     {
            //         daysPassedFromCurrentYear += monthsArr[i];
            //     }

            //     // Total days lived
            //     float totalDays =
            //         daysCompleteYears +
            //         (remindDaysOfLastYear - day) + // start from my birth day
            //         daysPassedFromCurrentYear +
            //         today.Day;

            //     // Convert days to years
            //     years = totalDays / 365.25f;
            //     totalDays %= 365.25f;

            //     // Calculate remaining months
            //     if (month == today.Month) // if birth day occurred in same current month
            //     {
            //         for (int i = month; i < 12; i++)  // if my birthMonth = 1 => 11 month and minus days from total day
            //         {
            //             months++;
            //             totalDays -= monthsArr[i];
            //         }
            //     }
            //     else
            //     {
            //         for (int i = month - 1; i < 12; i++) // increase 1 month and minus days from total day 
            //         {
            //             months++;
            //             totalDays -= monthsArr[i];
            //         }
            //     }

            //     // Remaining days after months calculation
            //     days = (int)totalDays;
            // }
            // else
            // {
            //     // Case 2: Birthday has already occurred this year
            //     years = today.Year - year; 
            //     months = today.Month - month;

            //     // Adjust days calculation
            //     if (day > today.Day) // if day will occur in this month
            //     {
            //         days = day - today.Day - 1; // 20 - 16 = 4 days
            //     }
            //     else 
            //     {
            //         if (month == 1) // if birthday in month Jun 
            //         {
            //             days = today.Day - day - 1;// day is -> 17 - birth day -> 10 - minus 1 day -> because today isn't over yet
            //         }
            //         else
            //         {
            //             days = monthsArr[month - 2] - day + today.Day;
            //         }
            //     }
            // }

            // // ================= OUTPUT =================
            // Console.WriteLine($"You're {(int)years} years, {months} months, {days} days");

        #endregion
        
        #region Calculate your birth date (GPT after enhance my code)

            // DateTime today = DateTime.Now;

            // int year, month, day;

            // // YEAR
            // do
            // {
            //     Console.WriteLine("Enter birth year (1980 - 2026):");
            //     year = int.Parse(Console.ReadLine());
            // } while (year < 1980 || year > 2026);

            // // Leap year check
            // bool isLeapYear = year % 4 == 0;

            // // Days in months
            // int[] monthsArr = [31, isLeapYear ? 29 : 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];

            // // MONTH 
            // do
            // {
            //     Console.WriteLine("Enter birth month (1 - 12):");
            //     month = int.Parse(Console.ReadLine());
            // } while (month < 1 || month > 12);

            // // DAY
            // do
            // {
            //     Console.WriteLine($"Enter birth day (1 - {monthsArr[month - 1]}):");
            //     day = int.Parse(Console.ReadLine());
            // } while (day < 1 || day > monthsArr[month - 1]);

            // // AGE CALCULATION

            // // Start with direct difference
            // int years = today.Year - year;      // Difference between years
            // int months = today.Month - month;   // Difference between months
            // int days = today.Day - day;         // Difference between days

            // /*
            // Example:
            //     today = 17 1 2026
            //     birth = 20 2 2000

            //     years  = 2026 - 2000 = 26
            //     months = 1 - 2 = -1    (negative because birthday month not reached)
            //     days   = 16 - 20 = -5   (negative because birthday day not reached)
            // */

            // // ---------- ADJUST DAYS IF NEGATIVE ----------
            // if (days < 0)
            // {
            //     months--;  // Subtract one month because we "Give" days from previous month // -2

            //     // Calculate index of the previous month in months array
            //     int previousMonthIndex = today.Month - 2;  // For January: 1-2 = -1
            //     if (previousMonthIndex < 0)               // If negative, use December (index 11)
            //         previousMonthIndex = 11;

            //     days += monthsArr[previousMonthIndex];    // Add days of previous month // -5 + 31 = 26
            // }

            // // MONTHS IF NEGATIVE
            // if (months < 0)
            // {
            //     years--;       // Subtract one year because months are negative // 25
            //     months += 12;  // Convert negative months to positive // -2 + 12 = 10
            // }


            // // RESULT
            // Console.WriteLine($"You're {years} years, {months} months, {days} days");

        #endregion
    
        #region Calculate
            //6-simple calculator
                //enter #1
                //5
                //enter #2
                //6
                //enter operator
                //+
                //5+6=11
                //continue y or n?
                //y
                //enter #1
                //1
                //enter #2
                //10
                //enter operator
                //*
                //1*10=10
                //continue y or n?
                //no

            // char isContinue = 'y';
            // while(isContinue == 'y')
            // {
            //     char operandType;
            //     int num1,num2;
            //     Console.WriteLine("Enter #1");
            //     num1 = int.Parse(Console.ReadLine());

            //     Console.WriteLine("Enter #2");
            //     num2 = int.Parse(Console.ReadLine());

            //     Console.WriteLine("Choose operator => (+, -, /, *, %, ^ -> (Power) )");
            //     operandType = char.Parse(Console.ReadLine());

            //     switch (operandType)
            //     {
            //         case '+':
            //             Console.WriteLine($"{num1} + {num2} = {num1 + num2}");
            //             break;
            //         case '-':
            //             Console.WriteLine($"{num1} - {num2} = {num1 - num2}");
            //             break;
            //         case '*':
            //             Console.WriteLine($"{num1} * {num2} = {num1 * num2}");
            //             break;
            //         case '/':
            //             Console.WriteLine($"{num1} / {num2} = {num1 / num2}");
            //             break;
            //         case '%':
            //             Console.WriteLine($"{num1} % {num2} = {num1 % num2}");
            //             break;
            //         case '^':
            //             int equ = num1;
            //             int pow = num1;
            //             for (int i = 0; i < num2 - 1; i++)
            //             {
            //                 equ *= pow;
            //             }
            //             Console.WriteLine($"{num1} ^ {num2} = {equ}");
            //             break;
            //         default:
            //             Console.WriteLine($"Choose valid operator => (+, -, /, *, %, ^ -> (Power) )");
            //             break;
            //     }
            //     Console.WriteLine("continue y or n ?");
            //     isContinue = char.Parse(Console.ReadLine());
            // }

        #endregion
    
        #region Revision [struct]
            // 7- 10 Employees [struct] & choose index

            // Ask for number of employees
            // int count;
            // do
            // {
            //     Console.WriteLine("Choose number of employees (1 - 9):");
            //     count = int.Parse(Console.ReadLine());
            // } while (count < 1 || count > 9);

            // Employee[] employees = new Employee[count];

            // // Input employee details
            // for (int i = 0; i < count; i++)
            // {
            //     Console.WriteLine($"\nEnter details for employee #{i + 1}");

            //     // ID with duplicate check
            //     int id;
            //     bool isDuplicate;
            //     do
            //     {
            //         isDuplicate = false;
            //         Console.Write($"Enter ID for employee #{i + 1}: ");
            //         id = int.Parse(Console.ReadLine());

            //         // Check duplicates only in previous employees
            //         for (int j = 0; j < i; j++)
            //         {
            //             if (employees[j].id == id)
            //             {
            //                 Console.WriteLine("This ID already exists. Try again.");
            //                 isDuplicate = true;
            //                 break;
            //             }
            //         }

            //     } while (isDuplicate);
                
            //     // Id
            //     employees[i].id = id;

            //     // Name
            //     Console.Write($"Enter name for employee #{i + 1}: ");
            //     employees[i].name = Console.ReadLine();

            //     // Age
            //     Console.Write($"Enter age for employee #{i + 1}: ");
            //     employees[i].age = int.Parse(Console.ReadLine());

            //     // Salary
            //     Console.Write($"Enter salary for employee #{i + 1}: ");
            //     employees[i].salary = int.Parse(Console.ReadLine());
            // }

            // // Display all employees
            // Console.WriteLine("\nAll Employees:");
            // for (int i = 0; i < count; i++)
            // {
            //     Console.WriteLine($"Employee #{i + 1}: ID={employees[i].id}, Name={employees[i].name}, Age={employees[i].age}, Salary={employees[i].salary}");
            // }
        #endregion
    }
}
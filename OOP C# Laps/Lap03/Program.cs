namespace Lap03;



class Program
{
    static void Main()
    {
            //Each class -> data + setter ang getters + print

            #region Complex Class
                // 1-class Complex
                // real,img ,ss,gg,print,Add

                //print()
                //real   img   print()
                //3      4     3+4i
                //3     -4     3-4i
                //3     1      3+i
                //3    -1      3-i
                //0     1      i
                //0    -1      -i
                //0    -3      -3i
                //1    0       1
                //0    0       0

                // Complex complex1 = new Complex();
                // Complex complex2 = new Complex();

                // Console.WriteLine("This program Calc two Complex Number");

                // Console.Write("Set Real Of Complex Number #1: ");
                // int real1 = int.Parse(Console.ReadLine());
                // complex1.SetReal(real1);

                // Console.Write("Set Imaginary Of Complex Number #1 : ");
                // int imaginary1 = int.Parse(Console.ReadLine());
                // complex1.SetImaginary(imaginary1);

                // Console.Write("Set Real Of Complex Number #2: ");
                // int real2 = int.Parse(Console.ReadLine());
                // complex2.SetReal(real2);

                // Console.Write("Set Imaginary Of Complex Number #2 : ");
                // int imaginary2 = int.Parse(Console.ReadLine());
                // complex2.SetImaginary(imaginary2);

                // Console.WriteLine(complex1.Print());
                // Console.WriteLine(complex2.Print());

                // Complex result = complex1.Add(complex2);

                // Console.WriteLine(result.Print());
            #endregion
    
            #region Array Of Employee [Class]
                // 2- class Employee  id,name,age,salary

                #region one employee  read then write
                    // -> one employee  read then write 
                    
                    // Employee employee = new Employee();
                    // Console.WriteLine("Add Employee");

                    // Console.Write("Employee Id:");
                    // employee.setId(int.Parse(Console.ReadLine()));

                    // Console.Write("Employee Name:");
                    // employee.setName(Console.ReadLine());

                    // Console.Write("Employee Age:");
                    // employee.setAge(int.Parse(Console.ReadLine()));

                    // Console.Write("Employee Salary:");
                    // employee.setSalary(float.Parse(Console.ReadLine()));

                    // Console.WriteLine(employee.Print());

                #endregion 
            
                #region 3 employee3  read then write 
                    // -> 3 employee3  read then write 
                    
                    // Console.Write("Enter the number of employees you want to add: ");
                    // int count = int.Parse(Console.ReadLine());
                    
                    // Employee[] employee = new Employee[count];

                    // for (int i = 0; i < count; i++)
                    // {
                    //     employee[i] = new Employee(); // Object reference not set to an instance of an object.
                    //     // new + class => allocation + initialization

                    //     Console.WriteLine($"Add Employee #{i + 1}");

                    //     Console.Write($"Employee #{i + 1} Id :");
                    //     employee[i].setId(int.Parse(Console.ReadLine()));

                    //     Console.Write($"Employee#{i + 1} Name:");
                    //     employee[i].setName(Console.ReadLine());

                    //     Console.Write($"Employee #{i + 1} Age:");
                    //     employee[i].setAge(int.Parse(Console.ReadLine()));

                    //     Console.Write($"Employee #{i + 1} Salary:");
                    //     employee[i].setSalary(float.Parse(Console.ReadLine()));
                    // }

                    // for (int i = 0; i < count; i++)
                    // {
                    //     Console.WriteLine($"{i + 1}# {employee[i].Print()}");
                    // }

                #endregion 

            #endregion

    }
}

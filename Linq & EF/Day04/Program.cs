using Day04;
using Day04.Repositories;

namespace Day04;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("===== University Management =====");
            Console.WriteLine("1  - Add Department");
            Console.WriteLine("2  - Add Instructor");
            Console.WriteLine("3  - Add Course");
            Console.WriteLine("4  - Add Student");
            Console.WriteLine("5  - Assign Head Instructor");
            Console.WriteLine("6  - Assign Course Instructor");
            Console.WriteLine("7  - Enroll Student");

            Console.WriteLine("8  - Show Departments");
            Console.WriteLine("9  - Show Instructors");
            Console.WriteLine("10 - Show Courses");
            Console.WriteLine("11 - Show Students");

            Console.WriteLine("12 - Update Department");
            Console.WriteLine("13 - Update Instructor");
            Console.WriteLine("14 - Update Course");
            Console.WriteLine("15 - Update Student");

            Console.WriteLine("16 - Delete Department");
            Console.WriteLine("17 - Delete Instructor");
            Console.WriteLine("18 - Delete Course");
            Console.WriteLine("19 - Delete Student");

            Console.WriteLine("20 - Department Details (Eager)");
            Console.WriteLine("21 - Course Details (Lazy)");
            Console.WriteLine("22 - Student Details (Explicit)");

            Console.WriteLine("0  - Exit");

            Console.Write("Choose option: ");

            if (!int.TryParse(Console.ReadLine(), out var choice))
            {
                Console.WriteLine("Invalid input.");
                continue;
            }

            switch (choice)
            {
                // Add
                case 1: Helper.AddDepartment(); break;
                case 2: Helper.AddInstructor(); break;
                case 3: Helper.AddCourse(); break;
                case 4: Helper.AddStudent(); break;
                case 5: Helper.AssignHeadInstructor(); break;
                case 6: Helper.AssignCourseInstructor(); break;
                case 7: Helper.EnrollStudent(); break;

                // Show
                case 8: Helper.ShowDepartments(); break;
                case 9: Helper.ShowInstructors(); break;
                case 10: Helper.ShowCourses(); break;
                case 11: Helper.ShowStudents(); break;

                // Update
                case 12: Helper.UpdateDepartment(); break;
                case 13: Helper.UpdateInstructor(); break;
                case 14: Helper.UpdateCourse(); break;
                case 15: Helper.UpdateStudent(); break;

                // Delete
                case 16: Helper.DeleteDepartment(); break;
                case 17: Helper.DeleteInstructor(); break;
                case 18: Helper.DeleteCourse(); break;
                case 19: Helper.DeleteStudent(); break;

                // Details (Loading Strategies)
                case 20: Helper.DepartmentDetailsEager(); break;
                case 21: Helper.CourseDetailsLazy(); break;
                case 22: Helper.StudentDetailsExplicit(); break;

                case 0:
                    return;

                default:
                    Console.WriteLine("Unknown option.");
                    break;
            }
        }
    }
}
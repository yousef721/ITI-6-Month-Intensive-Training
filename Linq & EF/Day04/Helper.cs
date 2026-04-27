using Day04.Repositories;

namespace Day04;

public static class Helper
{
    // ================= REPOS =================
    static UniversityContext context = new UniversityContext();

    static StudentRepository studentRepo = new(context);
    static CourseRepository courseRepo = new(context);
    static DepartmentRepository deptRepo = new(context);
    static InstructorRepository instructorRepo = new(context);
    static EnrollmentRepository enrollRepo = new(context);

    // ================  ADD  ================
    public static void AddDepartment()
    {
        string name = ReadInput<string>("Department Name");

        deptRepo.Add(new Department { Name = name });

        Success("Department Added");
    }
    public static void AddInstructor()
    {
        string name = ReadInput<string>("Instructor Name");
        decimal salary = ReadInput<decimal>("Salary");

        var dept = SelectEntity(
            deptRepo.GetAll(),
            x => x.Id,
            x => x.Name,
            "Department");

        instructorRepo.Add(new Instructor
        {
            Name = name,
            Salary = salary,
            DepartmentId = dept.Id
        });

        Success("Instructor Added");
    }
    public static void AddCourse()
    {
        string title = ReadInput<string>("Course Title");
        int credits = ReadInput<int>("Credits");

        var instructor = SelectEntity(
            instructorRepo.GetAll(),
            x => x.Id,
            x => x.Name,
            "Instructor");

        courseRepo.Add(new Course
        {
            Title = title,
            Credits = credits,
            InstructorId = instructor.Id
        });

        Success("Course Added");
    }
    public static void AddStudent()
    {
        string name = ReadInput<string>("Student Name");
        int age = ReadInput<int>("Age");
        string email = ReadInput<string>("Email");

        var dept = SelectEntity(
            deptRepo.GetAll(),
            x => x.Id,
            x => x.Name,
            "Department");

        studentRepo.Add(new Student
        {
            Name = name,
            Age = age,
            Email = email,
            DepartmentId = dept.Id
        });

        Success("Student Added");
    }
    public static void AssignHeadInstructor()
    {
        var instr = SelectEntity(
            instructorRepo.GetAll(),
            x => x.Id,
            x => x.Name,
            "Instructor");

        var dept = SelectEntity(
            deptRepo.GetAll(),
            x => x.Id,
            x => x.Name,
            "Department");

        deptRepo.AssignHeadInstructor(dept.Id, instr.Id);

        Success("Head Instructor Assigned");
    }
    public static void AssignCourseInstructor()
    {
        var instructor = SelectEntity(
            instructorRepo.GetAll(),
            x => x.Id,
            x => x.Name,
            "Instructor");

        var course = SelectEntity(
            courseRepo.GetAll(),
            x => x.Id,
            x => x.Title,
            "Course");

        courseRepo.AssignCourseInstructor(course.Id, instructor.Id);

        Success("Instructor Assigned To Course");
    }   
    public static void EnrollStudent()
    {
        var student = SelectEntity(
            studentRepo.GetAll(),
            x => x.Id,
            x => x.Name,
            "Student");

        var course = SelectEntity(
            courseRepo.GetAll(),
            x => x.Id,
            x => x.Title,
            "Course");

        string grade = ReadInput<string>("Grade");

        enrollRepo.Add(new Enrollment
        {
            StudentId = student.Id,
            CourseId = course.Id,
            Grade = grade
        });

        Success("Student Enrolled");
    }

    // ================= UPDATE =================
    public static void UpdateDepartment()
    {
        var department = SelectEntity(
            deptRepo.GetAll(),
            x => x.Id,
            x => x.Name,
            "Department");

        string newName = ReadInput<string>("New Department Name");

        department.Name = newName;

        deptRepo.Update(department);

        Success("Department Updated");
    }
    public static void UpdateInstructor()
    {
        var instructor = SelectEntity(
            instructorRepo.GetAll(),
            x => x.Id,
            x => x.Name,
            "Instructor");

        string newName = ReadInput<string>("New Instructor Name");
        decimal newSalary = ReadInput<decimal>("New Salary");

        var department = SelectEntity(
            deptRepo.GetAll(),
            x => x.Id,
            x => x.Name,
            "Department");

        instructor.Name = newName;
        instructor.Salary = newSalary;
        instructor.DepartmentId = department.Id;

        instructorRepo.Update(instructor);

        Success("Instructor Updated");
    }
    public static void UpdateCourse()
    {
        var course = SelectEntity(
            courseRepo.GetAll(),
            x => x.Id,
            x => x.Title,
            "Course");

        string title = ReadInput<string>("New Course Title");
        int credits = ReadInput<int>("New Credits");

        var instructor = SelectEntity(
            instructorRepo.GetAll(),
            x => x.Id,
            x => x.Name,
            "Instructor");

        course.Title = title;
        course.Credits = credits;
        course.InstructorId = instructor.Id;

        courseRepo.Update(course);

        Success("Course Updated");
    }
    public static void UpdateStudent()
    {
        var student = SelectEntity(
            studentRepo.GetAll(),
            x => x.Id,
            x => x.Name,
            "Student");

        string newName = ReadInput<string>("New Student Name");
        int newAge = ReadInput<int>("New Age");
        string newEmail = ReadInput<string>("New Email");

        var department = SelectEntity(
            deptRepo.GetAll(),
            x => x.Id,
            x => x.Name,
            "Department");

        student.Name = newName;
        student.Age = newAge;
        student.Email = newEmail;
        student.DepartmentId = department.Id;

        studentRepo.Update(student);

        Success("Student Updated");
    }

    // ================= DELETE =================
    public static void DeleteDepartment()
    {
        var department = SelectEntity(
            deptRepo.GetAll(),
            x => x.Id,
            x => x.Name,
            "Department");

        deptRepo.Delete(department);

        Success("Department Deleted");
    }
    public static void DeleteInstructor()
    {
        var instructor = SelectEntity(
            instructorRepo.GetAll(),
            x => x.Id,
            x => x.Name,
            "Instructor");

        instructorRepo.Delete(instructor);

        Success("Instructor Deleted");
    }
    public static void DeleteCourse()
    {
        var course = SelectEntity(
            courseRepo.GetAll(),
            x => x.Id,
            x => x.Title,
            "Course");

        courseRepo.Delete(course);

        Success("Course Deleted");
    }   
    public static void DeleteStudent()
    {
        var student = SelectEntity(
            studentRepo.GetAll(),
            x => x.Id,
            x => x.Name,
            "Student");

        studentRepo.Delete(student);

        Success("Student Deleted");
    }
    
    // =================  SHOW  =================
    public static void ShowStudents()
    {
        var students = studentRepo.GetAll();

        foreach (var s in students)
            Console.WriteLine($"{s.Id} - {s.Name}");
    }
    public static void ShowCourses()
    {
        var courses = courseRepo.GetAll();

        foreach (var c in courses)
            Console.WriteLine($"{c.Id} - {c.Title}");
    }
    public static void ShowDepartments()
    {
        var depts = deptRepo.GetAll();

        foreach (var d in depts)
            Console.WriteLine($"{d.Id} - {d.Name}");
    }
    public static void ShowInstructors()
    {
        var instructors = instructorRepo.GetAll();

        foreach (var i in instructors)
            Console.WriteLine($"{i.Id} - {i.Name}");
    }

    // ================= BONUS =================

    public static void DepartmentDetailsEager()
    {
        var department = SelectEntity(
            deptRepo.GetAll(),
            x => x.Id,
            x => x.Name,
            "Department");

        var data = deptRepo.GetDepartmentEager(department.Id);

        Console.WriteLine($"\nDepartment: {data.Name}");

        Console.WriteLine($"Head Instructor: {data.HeadInstructor?.Name ?? "None"}");

        Console.WriteLine("Students:");
        foreach (var student in data.Students)
        {
            Console.WriteLine($"- {student.Name}");
        }
    }
    public static void CourseDetailsLazy()
    {
        var course = SelectEntity(
            courseRepo.GetAll(),
            x => x.Id,
            x => x.Title,
            "Course");

        var data = courseRepo.GetCourseLazy(course.Id);

        Console.WriteLine($"\nCourse: {data.Title}");

        Console.WriteLine($"Instructor: {data.Instructor?.Name ?? "None"}");

        Console.WriteLine("Students:");

        foreach (var item in data.Enrollments)
        {
            Console.WriteLine($"- {item.Student.Name} | Grade: {item.Grade}");
        }
    }
    public static void StudentDetailsExplicit()
    {
        var student = SelectEntity(
            studentRepo.GetAll(),
            x => x.Id,
            x => x.Name,
            "Student");

        var data = studentRepo.GetStudentExplicit(student.Id);

        if (data == null)
        {
            Console.WriteLine("Student not found.");
            return;
        }

        Console.WriteLine($"\nStudent: {data.Name}");

        Console.WriteLine($"Department: {data.Department?.Name}");

        Console.WriteLine("Courses:");

        foreach (var item in data.Enrollments)
        {
            Console.WriteLine($"- {item.Course.Title} | Grade: {item.Grade}");
        }
    }
    
    // ================= GENERIC =================
    private static T ReadInput<T>(string prompt)
    {
        while (true)
        {
            Console.Write($"{prompt}: ");
            string? input = Console.ReadLine();

            try
            {
                return (T)Convert.ChangeType(input, typeof(T));
            }
            catch
            {
                Error("Invalid Input");
            }
        }
    }
    private static T SelectEntity<T>(List<T> list, Func<T, int> getId, Func<T, string> getName, string name)
    {
        if (!list.Any())
            throw new Exception($"No {name}s Found");

        Console.WriteLine($"\n{name}s:");

        foreach (var item in list)
            Console.WriteLine($"{getId(item)} - {getName(item)}");

        while (true)
        {
            int id = ReadInput<int>($"{name} Id");

            var entity = list.FirstOrDefault(x => getId(x) == id);

            if (entity != null)
                return entity;

            Error("Not Found");
        }
    }

    // ================= UI =================
    private static void Success(string msg)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(msg);
        Console.ResetColor();
    }
    private static void Error(string msg)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(msg);
        Console.ResetColor();
    }

}
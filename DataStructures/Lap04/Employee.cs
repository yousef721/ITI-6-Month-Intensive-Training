namespace Lap04;

public class Employee : IComparableInterface
{
    int Id;
    int Age;
    int Salary;
    string DepartmentName;
    public DateTime HireDate;

    static int Counter = 0;

    public Employee()
    {
        Id = ++Counter;
        Age = 0;
        Salary = 0;
        DepartmentName = "";
        HireDate = DateTime.Now;
    }

    public Employee(int _age, int _salary, string _departmentName, DateTime _hireDate)
    {
        Id = ++Counter;
        Age = _age;
        Salary = _salary;
        DepartmentName = _departmentName;
        HireDate = _hireDate;
    }

    public int CompareTo(Employee other)
    {
        if (this.HireDate > other.HireDate)
            return 1;

        if (this.HireDate < other.HireDate)
            return -1;

        return 0;
    }

    public override string ToString()
    {
        return $"ID: {Id}, Age: {Age}, Salary: {Salary}, Department: {DepartmentName}, HireDate: {HireDate}";
    }
}

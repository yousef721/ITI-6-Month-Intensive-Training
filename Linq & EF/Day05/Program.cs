using Dapper;
using Day05.Model;
using Microsoft.Data.SqlClient;

namespace Day05;

class Program
{
    static void Main(string[] args)
    {
        string ConnectionString = "Server=localhost;Database=EmployeeManagementSystem;User Id=SA;Password=reallyStrong123;Encrypt=False;";
        using SqlConnection con = new(ConnectionString);

        #region 2. Data Retrieval (Query)
        // // Retrieve all employees & Display their basic information
        // var employees = con.Query<Employee>("SELECT * FROM Employee");
        // foreach (var item in employees)
        // {
        //     Console.WriteLine($"Employee Id: {item.Id}, Name: {item.Name}, Department Id: {item.Dno}");
        // }

        // Console.WriteLine("============================================================================");

        // // Retrieve a single employee by ID & Handle case when employee does not exist
        // try
        // {
        //     var employee = con.QueryFirst<Employee>("SELECT * FROM Employee WHERE Id = @id", new {id = 4});
        //     Console.WriteLine($"Employee Id: {employee.Id}, Name: {employee.Name}, Department Id: {employee.Id}");
            
        // } catch (Exception ex)
        // {
        //     Console.WriteLine(ex.Message);
        // }
        #endregion

        #region 3. Scalar Query 
        // // Get total number of employees
        // var totalNoOfEmployee = con.ExecuteScalar("SELECT COUNT(*) FROM Employee");
        // Console.WriteLine($"Total Number Of Employee: {totalNoOfEmployee}");
        // // Get highest salary
        // var highestSalary = con.ExecuteScalar("SELECT Max(Salary) FROM Employee");
        // Console.WriteLine($"Highest Salary: {totalNoOfEmployee}");
        // // Get average salary
        // var averageSalary = con.ExecuteScalar("SELECT AVG(Salary) FROM Employee");
        // Console.WriteLine($"Average Salary: {totalNoOfEmployee}");
        #endregion
    
        #region 4. Data Manipulation
        // // Insert a new employee
        // var insert = con.Execute("INSERT INTO Employee (Name, Salary, Dno) VALUES (@name, @salary, @dno)",
        //                 new { name = "Kareem", salary = 20000, dno = 4 });        
        // if(insert > 0)
        // {
        // Console.WriteLine($"{insert} row effected");
        // }
        // else
        // {
        // Console.WriteLine($"{insert} row effected");
        // }
        // // Update employee salary
        // var update = con.Execute("UPDATE Employee SET Name = @name, Salary = @salary WHERE Id = @id", new { name = "Amr", salary = 23000, id = 4 });
        // if (update > 0)
        // {
        //     Console.WriteLine($"{update} row affected.");
        // }
        // else
        // {
        //     Console.WriteLine("Employee not found for update.");
        // }
        // // Delete employee
        // var delete = con.Execute("DELETE FROM Employee WHERE Id = @id", new { id = 4 });
        // if (delete > 0)
        // {
        //     Console.WriteLine($"{delete} row affected.");
        // }
        // else
        // {
        //     Console.WriteLine("Employee not found.");
        // }
        #endregion
    
        #region 5. Relationship Handling (Multi-Mapping)
        // // Retrieve employees along with their department data
        // // Display employee name + department name
        // // Ensure correct mapping between both entities
        // string command = "SELECT e.Id, e.Name, e.Salary, d.Id, d.Dname FROM Employee e JOIN Department d ON e.Dno = d.Id";
        // var displayEmployeeAndDepartment = con.Query<Employee, Department, Employee>(command, (emp, dept) =>
        // {
        //     emp.Department = dept;
        //     return emp;
        // }, splitOn: "Id");

        // foreach (var item in displayEmployeeAndDepartment)
        // {
        //     Console.WriteLine(
        //         $"Employee Id: {item.Id}, Name: {item.Name}, Department: {item.Department.Dname}"
        //     );
        // }
        #endregion

        #region 6. Stored Procedures
        // // Insert employee
        // var rows = con.Execute("sp_InsertEmployee",
        //     new
        //     {
        //         Name = "Kareem",
        //         Salary = 20000,
        //         Dno = 4
        //     }, commandType: System.Data.CommandType.StoredProcedure);

        // Console.WriteLine($"{rows} row affected.");
        // // Retrieve all employees
        // var employees = con.Query<Employee>("sp_GetAllEmployees", commandType: System.Data.CommandType.StoredProcedure);

        // foreach (var emp in employees)
        // {
        //     Console.WriteLine(
        //         $"Id: {emp.Id}, Name: {emp.Name}, Salary: {emp.Salary}"
        //     );
        // }
        #endregion
    }
}

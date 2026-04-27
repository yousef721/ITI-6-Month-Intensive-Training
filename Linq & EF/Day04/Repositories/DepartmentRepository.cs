using System;
using Day04.Data;
using Microsoft.EntityFrameworkCore;

namespace Day04.Repositories;

public class DepartmentRepository : Repository<Department>
{
    private readonly UniversityContext _context;

    public DepartmentRepository(UniversityContext context) : base(context)
    {
        _context = context;
    }

    public Department GetDepartmentEager(int id)
    {
        return _context.Departments
            .Include(d => d.HeadInstructor)
            .Include(d => d.Students)
            .FirstOrDefault(d => d.Id == id)!;
    }

    public void AssignHeadInstructor(int deptId, int instId)
    {
        var department = _context.Departments.Find(deptId);

        if (department == null)
            throw new Exception("Department not found");

        var instructor = _context.Instructors.Find(instId);

        if (instructor == null)
            throw new Exception("Instructor not found");

        department.HeadInstructorId = instId;

        _context.SaveChanges();
    }
}
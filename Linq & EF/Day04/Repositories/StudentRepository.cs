using System;
using Day04.Data;
using Microsoft.EntityFrameworkCore;

namespace Day04.Repositories;

public class StudentRepository : Repository<Student>
{
    private readonly UniversityContext _context;

    public StudentRepository(UniversityContext context) : base(context)
    {
        _context = context;
    }

    public Student GetStudentExplicit(int id)
    {
        var student = _context.Students.FirstOrDefault(s => s.Id == id);

        if (student == null)
            return null;

        _context.Entry(student)
            .Reference(s => s.Department)
            .Load();

        _context.Entry(student)
            .Collection(s => s.Enrollments)
            .Query()
            .Include(e => e.Course)
            .Load();

        return student;
    }
}

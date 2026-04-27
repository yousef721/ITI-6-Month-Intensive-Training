using System;
using Day04.Data;
using Microsoft.EntityFrameworkCore;

namespace Day04.Repositories;

public class InstructorRepository : Repository<Instructor>
{
    private readonly UniversityContext _context;
    public InstructorRepository(UniversityContext context) : base(context)
    {
        _context = context;
    }

    public Instructor GetDetails(int id)
    {
        return _context.Instructors
            .Include(i => i.Courses)
            .Include(i => i.Department)
            .FirstOrDefault(i => i.Id == id)!;
    }

}
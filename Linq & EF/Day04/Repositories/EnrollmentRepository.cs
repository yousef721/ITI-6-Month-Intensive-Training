using System;
using Day04.Data;
using Microsoft.EntityFrameworkCore;

namespace Day04.Repositories;

public class EnrollmentRepository : Repository<Enrollment>
{
    private readonly UniversityContext _context;

    public EnrollmentRepository(UniversityContext context) : base(context)
    {
        _context = context;
    }

    public List<Enrollment> GetStudentEnrollments(int studentId)
    {
        return [.. _context.Enrollments
            .Include(e => e.Course)
            .Where(e => e.StudentId == studentId)];
    }

    public List<Enrollment> GetCourseEnrollments(int courseId)
    {
        return _context.Enrollments
            .Include(e => e.Student)
            .Where(e => e.CourseId == courseId)
            .ToList();
    }
}
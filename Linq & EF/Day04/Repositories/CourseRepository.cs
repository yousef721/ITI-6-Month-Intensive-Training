using System;
using Day04.Data;

namespace Day04.Repositories;

public class CourseRepository : Repository<Course>
{
    private readonly UniversityContext _context;

    public CourseRepository(UniversityContext context) : base(context)
    {
        _context = context;
    }

    public Course GetCourseLazy(int id)
    {
        return _context.Courses.FirstOrDefault(c => c.Id == id)!;
    }

    public void AssignCourseInstructor(int corId, int instId)
    {
        var course = _context.Courses.Find(corId);

        if (course == null)
            throw new Exception("Course not found");

        var instructor = _context.Instructors.Find(instId);

        if (instructor == null)
            throw new Exception("Instructor not found");

        course.InstructorId = instId;

        _context.SaveChanges();
    }
}
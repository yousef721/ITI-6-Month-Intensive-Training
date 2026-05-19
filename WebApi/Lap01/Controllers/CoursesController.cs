using Lap01.Database;
using Lap01.Model;
using Microsoft.AspNetCore.Mvc;

namespace Lap01.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoursesController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public CoursesController(ApplicationDbContext context)
    {
        _context = context;
    }


    [HttpGet]
    public IActionResult Get()
    {
        var courses = _context.Courses.ToList();
        if (courses.Count == 0)
            return NotFound();
        return Ok(courses);
    }
    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var course = _context.Courses.Find(id);

        if (course == null)
            return NotFound();

        return Ok(course);
    }

    [HttpGet("name/{name}")]
    public IActionResult CourseByName(string name)
    {
        var course = _context.Courses.FirstOrDefault(c =>
            c.Name!.ToLower() == name.ToLower());

        if (course == null)
            return NotFound();

        return Ok(course);
    }

    [HttpPost]
    public IActionResult Post(Course course)
    {
        if (course == null)
            return BadRequest();

        _context.Courses.Add(course);
        _context.SaveChanges();

        return StatusCode(201);
    }

    [HttpPut("{id:int}")]
    public IActionResult Put(int id, Course course)
    {
        if (id != course.Id)
            return BadRequest();

        var oldCourse = _context.Courses.FirstOrDefault(c => c.Id == id);

        if (oldCourse == null)
            return NotFound();

        oldCourse.Name = course.Name;
        oldCourse.Desc = course.Desc;
        oldCourse.Duration = course.Duration;
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteCourse(int id)
    {
        var course = _context.Courses.FirstOrDefault(c => c.Id == id);

        if (course == null)
            return NotFound();

        _context.Courses.Remove(course);
        _context.SaveChanges();

        return Ok(course);
    }
}

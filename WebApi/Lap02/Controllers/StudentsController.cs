using AutoMapper;
using Lap02.Database;
using Lap02.DTOs.Student;
using Lap02.Models;
using Lap02.Shared.Pagination;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lap02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class StudentsController : ControllerBase
    {
        private readonly ITIDbContext _context;
        private readonly IMapper _mapper;

        public StudentsController(ITIDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAll([FromQuery] PaginationParams pagination)
        {
            if (pagination.PageSize <= 0){
                pagination.PageSize = 10;
            }
            if (pagination.Page <= 0)
            {
                pagination.Page = 1;
            }

            var query = _context.Students
                            .Include(s => s.Department)
                            .Include(s => s.Supervisor).AsQueryable();
            // Search
            if (!string.IsNullOrWhiteSpace(pagination.Search))
            {
                query = query.Where(p => p.Name.Contains(pagination.Search));
            }

            // Count after filtering
            var count = query.Count();

            var totalPages = (int)Math.Ceiling((double)count / pagination.PageSize); // 100 / 10 = 10 total pages

            // Pagination
            var students = query.Skip((pagination.Page - 1) * pagination.PageSize).Take(pagination.PageSize).ToList(); // (3 - 1) * 10 = 20 , 10

            // Mapping
            var studentsDto = _mapper.Map<List<StudentReadDto>>(students);

            // Response
            var response = new PaginationResponse<StudentReadDto>()
            {
                Page = pagination.Page,
                PageSize = pagination.PageSize,
                TotalPages = totalPages,
                TotalCount = count,
                Data = studentsDto
            };

            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var student = _context.Students
                .Include(s => s.Department)
                .Include(s => s.Supervisor)
                .FirstOrDefault(s => s.Id == id);

            if (student == null)
                return NotFound();

            var studentDto = _mapper.Map<StudentReadDto>(student);

            return Ok(studentDto);
        }

        [HttpPost]
        public IActionResult Post(StudentCreateDto studentDto)
        {
            if (studentDto == null)
                return BadRequest();

            var departmentExists = _context.Departments.Any(d => d.Id == studentDto.DepartmentId);
            if (!departmentExists)
                return BadRequest("Department not found.");

            if (studentDto.SupervisorId != null)
            {
                var supervisorExists = _context.Students.Any(s => s.Id == studentDto.SupervisorId);
                if (!supervisorExists)
                    return BadRequest("Supervisor not found.");
            }

            var student = _mapper.Map<Student>(studentDto);

            _context.Students.Add(student);
            _context.SaveChanges();

            var createdStudent = _context.Students
                .Include(s => s.Department)
                .Include(s => s.Supervisor)
                .First(s => s.Id == student.Id);
            var createdStudentDto = _mapper.Map<StudentReadDto>(createdStudent);

            return CreatedAtAction(nameof(GetById), new { id = student.Id }, createdStudentDto);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, StudentUpdateDto studentDto)
        {
            if (studentDto == null)
                return BadRequest();

            var student = _context.Students.FirstOrDefault(s => s.Id == id);

            if (student == null)
                return NotFound();

            var departmentExists = _context.Departments.Any(d => d.Id == studentDto.DepartmentId);
            if (!departmentExists)
                return BadRequest("Department not found.");

            if (studentDto.SupervisorId != null)
            {
                if (studentDto.SupervisorId == id)
                    return BadRequest("Student cannot be their own supervisor.");

                var supervisorExists = _context.Students.Any(s => s.Id == studentDto.SupervisorId);
                if (!supervisorExists)
                    return BadRequest("Supervisor not found.");
            }

            _mapper.Map(studentDto, student);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == id);

            if (student == null)
                return NotFound();

            _context.Students.Remove(student);
            _context.SaveChanges();

            var studentDto = _mapper.Map<StudentReadDto>(student);

            return Ok(studentDto);
        }
    }
}

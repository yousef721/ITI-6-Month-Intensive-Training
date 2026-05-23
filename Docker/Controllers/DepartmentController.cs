using AutoMapper;
using Lap02.Database;
using Lap02.DTOs.Department;
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
    public class DepartmentController : ControllerBase
    {
        private readonly ITIDbContext _context;
        private readonly IMapper _mapper;

        public DepartmentController(ITIDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery] PaginationParams pagination)
        {
            if (pagination.PageSize <= 0)
            {
                pagination.PageSize = 10;
            }
            if (pagination.Page <= 0)
            {
                pagination.Page = 1;
            }

            var query = _context.Departments
                .Include(d => d.Students)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Search))
            {
                query = query.Where(d => d.Name.Contains(pagination.Search));
            }

            var count = query.Count();

            var totalPages = (int)Math.Ceiling((double)count / pagination.PageSize);

            var departments = query.Skip((pagination.Page - 1) * pagination.PageSize).Take(pagination.PageSize).ToList();

            var departmentsDto = _mapper.Map<List<DepartmentReadDto>>(departments);

            var response = new PaginationResponse<DepartmentReadDto>()
            {
                Page = pagination.Page,
                PageSize = pagination.PageSize,
                TotalPages = totalPages,
                TotalCount = count,
                Data = departmentsDto
            };

            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var department = _context.Departments
                .Include(d => d.Students)
                .FirstOrDefault(d => d.Id == id);

            if (department == null)
                return NotFound();

            var departmentDto = _mapper.Map<DepartmentReadDto>(department);

            return Ok(departmentDto);
        }

        [HttpPost]
        public IActionResult Post(DepartmentCreateDto departmentDto)
        {
            if (departmentDto == null)
                return BadRequest();

            var department = _mapper.Map<Department>(departmentDto);

            _context.Departments.Add(department);

            _context.SaveChanges();

            var createdDepartmentDto = _mapper.Map<DepartmentReadDto>(department);

            return Ok(createdDepartmentDto);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, DepartmentUpdateDto departmentDto)
        {
            if (departmentDto == null)
                return BadRequest();

            var department = _context.Departments.FirstOrDefault(d => d.Id == id);

            if (department == null)
                return NotFound();

            _mapper.Map(departmentDto, department);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var department = _context.Departments
                .Include(d => d.Students)
                .FirstOrDefault(d => d.Id == id);

            if (department == null)
                return NotFound();

            _context.Departments.Remove(department);
            _context.SaveChanges();

            var departmentDto = _mapper.Map<DepartmentReadDto>(department);

            return Ok(departmentDto);
        }
    }
}

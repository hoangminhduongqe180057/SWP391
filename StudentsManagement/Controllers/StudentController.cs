using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentsManagement.Client.Repository;
using StudentsManagement.Data;
using StudentsManagement.Shared.Models;
using StudentsManagement.Shared.StudentRepository;

namespace StudentsManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public StudentController(ApplicationDbContext context)
        {
            this._context = context;
        }


        [HttpGet("All-Students")]
        public async Task<ActionResult<List<Student>>> GetAllStudentsAsync()
        {
            var students = await _context.Students.ToListAsync();
            return Ok(students);
        }


        [HttpGet("Single-Student/{id}")]
        public async Task<ActionResult<Student>> GetSingleStudentAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);

            return Ok(student);
        }

        [HttpPost("Add-Student")]
        public async Task<ActionResult<Student>> AddNewStudentAsync(Student student)
        {
            var newStudent = await _context.Students.AddAsync(student);
            return Ok(newStudent);
        }


        [HttpDelete("DeleteStudent/{id}")]
        public async Task<ActionResult<Student>> DeleteStudentAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpPut("Update-Student")]
        public async Task<IActionResult> UpdateSingleStudent(int id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }

            _context.Entry(student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.Id == id);
        }

    }
}

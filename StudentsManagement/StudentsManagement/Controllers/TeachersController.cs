using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentsManagement.Client.Repository;
using StudentsManagement.Data;
using StudentsManagement.Shared.Models;

namespace StudentsManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TeachersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Teachers
        [HttpGet("All-Teachers")]
        public async Task<ActionResult<List<Teacher>>> GetAllTeachersAsyncs()
        {
            var teachers = await _context.Teachers.ToListAsync();
            return Ok(teachers);
        }

        // GET: api/Teachers/5
        [HttpGet("Single-Teacher/{id}")]
        public async Task<ActionResult<Teacher>> GetTeacherByIdAsync(int id)
        {
            var student = await _context.Teachers.FindAsync(id);

            return Ok(student);
        }

        // PUT: api/Teachers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("Update-Teacher")]
        public async Task<IActionResult> AddNewTeacherAsync(Teacher teacher)
        {
            var updateTeacher = await _context.Teachers.AddAsync(teacher);

            return Ok(updateTeacher);
        }

        // POST: api/Teachers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("Add-Teacher")]
        public async Task<IActionResult> UpdateSingleTeacher(int id, Teacher teacher)
        {
            if (id != teacher.Id)
            {
                return BadRequest();
            }

            _context.Entry(teacher).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeacherExists(id))
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

        // DELETE: api/Teachers/5
        [HttpDelete("DeleteTeacher/{id}")]
        public async Task<ActionResult<Student>> DeleteTeacherAsync(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }

            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TeacherExists(int id)
        {
            return _context.Teachers.Any(e => e.Id == id);
        }
    }
}

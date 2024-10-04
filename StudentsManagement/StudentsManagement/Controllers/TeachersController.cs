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
        private readonly ITeacherRepository _teacherRepository;

        public TeachersController(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        // GET: api/Teachers
        [HttpGet("All-Teachers")]
        public async Task<ActionResult<List<Teacher>>> GetAllTeachersAsyncs()
        {
            var teachers = await _teacherRepository.GetAllAsync();
            return Ok(teachers);
        }

        // GET: api/Teachers/5
        [HttpGet("Single-Teacher/{id}")]
        public async Task<ActionResult<Teacher>> GetTeacherByIdAsync(int id)
        {
            var student = await _teacherRepository.GetByIdAsync(id);

            return Ok(student);
        }

        // PUT: api/Teachers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("Update-Teacher")]
        public async Task<IActionResult> AddNewTeacherAsync(Teacher teacher)
        {
            var updateTeacher = await _teacherRepository.UpdateAsync(teacher);

            return Ok(updateTeacher);
        }

        // POST: api/Teachers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Add-Teacher")]
        public async Task<ActionResult<Teacher>> PostTeacher(Teacher teacher)
        {
            var newTeacher = await _teacherRepository.AddAsync(teacher);
            return Ok(newTeacher);
        }

        // DELETE: api/Teachers/5
        [HttpDelete("DeleteTeacher/{id}")]
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            var deleteTeacher = await _teacherRepository.DeleteAsync(id);
            return Ok(deleteTeacher);
        }
    }
}

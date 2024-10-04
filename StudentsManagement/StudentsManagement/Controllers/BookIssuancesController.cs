using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentsManagement.Data;
using StudentsManagement.Shared.Models;

namespace StudentsManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookIssuancesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BookIssuancesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/BookIssuances
        [HttpGet("All-BookIssuances")]
        public async Task<ActionResult<IEnumerable<BookIssuance>>> GetAllBookIssuances()
        {
            return await _context.BookIssuances.ToListAsync();
        }

        // GET: api/BookIssuances/5
        [HttpGet("Single-BookIssuance/{id}")]
        public async Task<ActionResult<BookIssuance>> GetSingleBookIssuance(int id)
        {
            var bookIssuance = await _context.BookIssuances.FindAsync(id);

            if (bookIssuance == null)
            {
                return NotFound();
            }

            return bookIssuance;
        }

        // PUT: api/BookIssuances/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("Update-BookIssuance")]
        public async Task<IActionResult> UpdateSingleBookIssuance(int id, BookIssuance bookIssuance)
        {
            if (id != bookIssuance.Id)
            {
                return BadRequest();
            }

            _context.Entry(bookIssuance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookIssuanceExists(id))
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

        // POST: api/BookIssuances
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Add-BookInssuance")]
        public async Task<ActionResult<BookIssuance>> AddNewBookIssuance(BookIssuance bookIssuance)
        {
            _context.BookIssuances.Add(bookIssuance);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookIssuance", new { id = bookIssuance.Id }, bookIssuance);
        }

        // DELETE: api/BookIssuances/5
        [HttpDelete("Delete-BookIssuance/{id}")]
        public async Task<IActionResult> DeleteBookIssuance(int id)
        {
            var bookIssuance = await _context.BookIssuances.FindAsync(id);
            if (bookIssuance == null)
            {
                return NotFound();
            }

            _context.BookIssuances.Remove(bookIssuance);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookIssuanceExists(int id)
        {
            return _context.BookIssuances.Any(e => e.Id == id);
        }
    }
}

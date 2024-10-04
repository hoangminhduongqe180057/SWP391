using Microsoft.EntityFrameworkCore;
using StudentsManagement.Client.Repository;
using StudentsManagement.Data;
using StudentsManagement.Shared.Models;

namespace StudentsManagement.Services
{
    public class BookIssuanceRepository : IBookIssuanceRepository
    {
        private readonly ApplicationDbContext _context;
        public BookIssuanceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<BookIssuance> AddAsync(BookIssuance bookIssuance)
        {
            bookIssuance.CreatedOn = DateTime.Now;
            if (bookIssuance == null) return null;
            var data = _context.BookIssuances.Add(bookIssuance).Entity;
            await _context.SaveChangesAsync();
            return data;
        }

        public async Task<BookIssuance> DeleteAsync(int bookIssuanceId)
        {
            var data = await _context.BookIssuances.Where(x => x.Id == bookIssuanceId).FirstOrDefaultAsync();
            if (data == null) return null;
            _context.BookIssuances.Remove(data);
            await _context.SaveChangesAsync();
            return data;

        }

        public async Task<List<BookIssuance>> GetAllAsync()
        {
            var data = await _context.BookIssuances.Include(s => s.Student).Include(c => c.Class).Include(b => b.Book).ToListAsync();
            return data;
        }

        public async Task<BookIssuance> GetByIdAsync(int bookIssuanceId)
        {
            var data = await _context.BookIssuances.Include(s => s.Student).Include(c => c.Class).Include(b => b.Book).FirstOrDefaultAsync(x => x.Id == bookIssuanceId);
            return data;
        }

        public async Task<BookIssuance> UpdateAsync(BookIssuance bookIssuance)
        {
            if (bookIssuance == null) return null;
            var data = _context.BookIssuances.Update(bookIssuance).Entity;
            await _context.SaveChangesAsync();
            return data;
        }
    }
}

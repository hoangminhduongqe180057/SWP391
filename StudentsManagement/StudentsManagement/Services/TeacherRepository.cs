using Microsoft.EntityFrameworkCore;
using StudentsManagement.Client.Repository;
using StudentsManagement.Data;
using StudentsManagement.Shared.Models;

namespace StudentsManagement.Services
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly ApplicationDbContext _context;

        public TeacherRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Teacher> AddAsync(Teacher teacher)
        {
            if (teacher == null) return null;
            var data = _context.Teachers.Add(teacher).Entity;
            await _context.SaveChangesAsync();
            return data;
        }

        public async Task<Teacher> DeleteAsync(int teacherId)
        {
            var data = await _context.Teachers.Where(x => x.Id == teacherId).FirstOrDefaultAsync();
            if (data == null) return null;
            _context.Teachers.Remove(data);
            await _context.SaveChangesAsync();
            return data;    

        }

        public async Task<List<Teacher>> GetAllAsync()
        {
            var data = await _context.Teachers.Include(s => s.Gender).Include(x => x.MaritalStatus).ToListAsync();
            return data;
        }

        public async Task<Teacher> GetByIdAsync(int teacherId)
        {
            var data = await _context.Teachers.Include(s => s.Gender).Include(x => x.MaritalStatus).Include(z => z.Designation).Where(x => x.Id == teacherId).FirstOrDefaultAsync();
            if (data == null) return null;
            return data;
        }

        public async Task<Teacher> UpdateAsync(Teacher teacher)
        {
            if (teacher == null) return null;

            var data = _context.Teachers.Update(teacher).Entity;
            await _context.SaveChangesAsync();

            return data;
        }
    }
}

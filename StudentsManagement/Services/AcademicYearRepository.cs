using Microsoft.EntityFrameworkCore;
using StudentsManagement.Client.Repository;
using StudentsManagement.Data;
using StudentsManagement.Shared.Models;

namespace StudentsManagement.Services
{
    public class AcademicYearRepository : IAcademicYearRepository
    {
        private readonly ApplicationDbContext _context;
        public AcademicYearRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AcademicYears> AddAsync(AcademicYears academicYears)
        {
            var activeStatus = await _context.SystemCodeDetails
                .Include(x => x.SystemCode)
                .Where(x => x.SystemCode.Code == "AcademicYearStatus" && x.Code == "Active")
                .FirstOrDefaultAsync();
            academicYears.StatusId = activeStatus.Id;
            _context.AcademicYears.Add(academicYears);
            await _context.SaveChangesAsync();
            return academicYears;
        }

        public async Task<AcademicYears> DeleteAsync(int academicYearsId)
        {
            var data = await _context.AcademicYears.Where(x => x.Id == academicYearsId).Include(x => x.Status).FirstOrDefaultAsync();
            if (data == null) return null;
            _context.AcademicYears.Remove(data);
            await _context.SaveChangesAsync();
            return data;
        }

        public async Task<List<AcademicYears>> GetAllAsync()
        {
            var data = await _context.AcademicYears.Include(x => x.Status).ToListAsync();

            return data;
        }

        public async Task<AcademicYears> GetByIdAsync(int academicYearsId)
        {
            var data = await _context.AcademicYears.Where(x => x.Id == academicYearsId).Include(x => x.Status).FirstOrDefaultAsync();
            if (data == null) return null;
            return data;
        }

        public async Task<AcademicYears> UpdateAsync(AcademicYears academicYears)
        {
            if (academicYears == null) return null;


            var data = _context.AcademicYears.Update(academicYears).Entity;
            await _context.SaveChangesAsync();

            return data;
        }
    }
}

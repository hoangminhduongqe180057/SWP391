using Microsoft.EntityFrameworkCore;
using StudentsManagement.Client.Repository;
using StudentsManagement.Data;
using StudentsManagement.Migrations;
using StudentsManagement.Shared.Models;

namespace StudentsManagement.Services
{
    public class SystemCodeDetailRepository : ISystemCodeDetailRepository
    {
        private readonly ApplicationDbContext _context;

        public SystemCodeDetailRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<SystemCodeDetail> AddAsync(SystemCodeDetail scd)
        {
            if (scd == null) return null;
            var newscd = _context.SystemCodeDetails.Add(scd).Entity;
            await _context.SaveChangesAsync();
            return newscd;
        }

        public async Task<SystemCodeDetail> DeleteAsync(int scdId)
        {
            var scd = await _context.SystemCodeDetails.Where(x => x.Id == scdId).FirstOrDefaultAsync();
            if (scd == null) return null;
            _context.SystemCodeDetails.Remove(scd);
            await _context.SaveChangesAsync();
            return scd;

        }

        public async Task<List<SystemCodeDetail>> GetAllAsync()
        {
            var scds = await _context.SystemCodeDetails.Include(x=> x.SystemCode).ToListAsync();
            return scds;
        }

        public async Task<List<SystemCodeDetail>> GetByCodeAsync(string code)
        {
            // Truy vấn tất cả các SystemCodeDetail có SystemCode.Code trùng khớp với tham số code
            var scds = await _context.SystemCodeDetails
                                      .Include(x => x.SystemCode)
                                      .Where(x => x.SystemCode.Code == code)
                                      .ToListAsync();
            return scds;
        }


        public async Task<SystemCodeDetail> GetByIdAsync(int scdId)
        {
            var scd = await _context.SystemCodeDetails.Include(x => x.SystemCode).Where(x => x.Id == scdId).FirstOrDefaultAsync();
            if (scd == null) return null;
            return scd;
        }

        public async Task<SystemCodeDetail> UpdateAsync(SystemCodeDetail scd)
        {
            if (scd == null) return null;
            var newscd = _context.SystemCodeDetails.Update(scd).Entity;
            await _context.SaveChangesAsync();
            return newscd;
        }
    }
}

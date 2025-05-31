using Microsoft.EntityFrameworkCore;
using MobilePhoneStore.Data;
using MobilePhoneStore.Models;

namespace MobilePhoneStore.Repositories
{
    public class MobileRepository : IMobileRepository
    {
        private readonly ApplicationDbContext _context;

        public MobileRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Mobile>> GetAllAsync()
        {
            return await _context.Mobiles.Include(m => m.Brand).ToListAsync();
        }

        public async Task<Mobile> GetByIdAsync(int id)
        {
            return await _context.Mobiles.Include(m => m.Brand).FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task AddAsync(Mobile mobile)
        {
            await _context.Mobiles.AddAsync(mobile);
        }

        public async Task UpdateAsync(Mobile mobile)
        {
            _context.Mobiles.Update(mobile);
        }

        public async Task DeleteAsync(Mobile mobile)
        {
            _context.Mobiles.Remove(mobile);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    
}
}

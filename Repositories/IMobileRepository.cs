using MobilePhoneStore.Models;

namespace MobilePhoneStore.Repositories
{
    public interface IMobileRepository
    {
        Task<IEnumerable<Mobile>> GetAllAsync();
        Task<Mobile> GetByIdAsync(int id);
        Task AddAsync(Mobile mobile);
        Task UpdateAsync(Mobile mobile);
        Task DeleteAsync(Mobile mobile);
        Task SaveChangesAsync();
    }
}

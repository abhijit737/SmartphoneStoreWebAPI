using MobilePhoneStore.DTOs;
using MobilePhoneStore.Models;

namespace MobilePhoneStore.Services
{
    public interface IMobileService
    {

       
            Task<IEnumerable<Mobile>> GetAllAsync();
            Task<Mobile> GetByIdAsync(int id);
            Task<Mobile> AddAsync(MobileDto dto);
            Task UpdateAsync(int id, MobileDto dto);
            Task DeleteAsync(int id);
        
    }
    }


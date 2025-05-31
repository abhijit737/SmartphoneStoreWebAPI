using Microsoft.EntityFrameworkCore;
using MobilePhoneStore.Data;
using MobilePhoneStore.DTOs;
using MobilePhoneStore.Models;
using MobilePhoneStore.Repositories;

namespace MobilePhoneStore.Services
{
    public class MobileService : IMobileService
    {
        private readonly IMobileRepository _repository;

        public MobileService(IMobileRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Mobile>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Mobile> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Mobile> AddAsync(MobileDto dto)
        {
            var mobile = new Mobile
            {
                ModelName = dto.ModelName,
                CostPrice = dto.CostPrice,
                SellingPrice = dto.SellingPrice,
                Stock = dto.Stock,
                BrandId = dto.BrandId
            };

            await _repository.AddAsync(mobile);
            await _repository.SaveChangesAsync();
            return mobile;
        }

        public async Task UpdateAsync(int id, MobileDto dto)
        {
            var mobile = await _repository.GetByIdAsync(id);
            if (mobile != null)
            {
                mobile.ModelName = dto.ModelName;
                mobile.CostPrice = dto.CostPrice;
                mobile.SellingPrice = dto.SellingPrice;
                mobile.Stock = dto.Stock;
                mobile.BrandId = dto.BrandId;

                await _repository.UpdateAsync(mobile);
                await _repository.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var mobile = await _repository.GetByIdAsync(id);
            if (mobile != null)
            {
                await _repository.DeleteAsync(mobile);
                await _repository.SaveChangesAsync();
            }
        }
    }
}

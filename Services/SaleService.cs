using MobilePhoneStore.DTOs;
using MobilePhoneStore.Models;
using MobilePhoneStore.Repositories;

namespace MobilePhoneStore.Services
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepository;

        public SaleService(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public async Task<Sale> CreateSaleAsync(SaleDto dto)
        {
            var sale = new Sale
            {
                CustomerId = dto.CustomerId,
                SaleDate = dto.SaleDate,
                Discount = dto.Discount,
                SaleItems = new List<SaleItem>()
            };

            decimal total = 0;

            foreach (var item in dto.Items)
            {
                var saleItem = new SaleItem
                {
                    MobileId = item.MobileId,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice,
                    DiscountApplied = item.DiscountApplied
                };

                total += (item.UnitPrice * item.Quantity) - item.DiscountApplied;
                sale.SaleItems.Add(saleItem);
            }

            sale.TotalAmount = total;
            sale.FinalAmount = total - dto.Discount;

            return await _saleRepository.CreateSaleAsync(sale);
        }

        public Task<IEnumerable<object>> GetMonthlySalesReport(DateTime from, DateTime to)
        {
            return _saleRepository.GetMonthlySalesReport(from, to);
        }

        public Task<IEnumerable<object>> GetBrandWiseSalesReport(DateTime from, DateTime to)
        {
            return _saleRepository.GetBrandWiseSalesReport(from, to);
        }

        public Task<object> GetProfitLossReport(DateTime from, DateTime to)
        {
            return _saleRepository.GetProfitLossReport(from, to);
        }

        public Task<decimal?> GetSuggestedPriceAsync(int mobileId)
        {
            return _saleRepository.GetSuggestedPriceAsync(mobileId);
        }
    }
}

using MobilePhoneStore.DTOs;
using MobilePhoneStore.Models;

namespace MobilePhoneStore.Services
{
    public interface ISaleService
    {
        Task<Sale> CreateSaleAsync(SaleDto dto);
        Task<IEnumerable<object>> GetMonthlySalesReport(DateTime from, DateTime to);
        Task<IEnumerable<object>> GetBrandWiseSalesReport(DateTime from, DateTime to);
        Task<object> GetProfitLossReport(DateTime from, DateTime to);

        Task<decimal?> GetSuggestedPriceAsync(int mobileId);


    }
}

using MobilePhoneStore.Models;

namespace MobilePhoneStore.Repositories
{
    public interface ISaleRepository
    {
        Task<Sale> CreateSaleAsync(Sale sale);
        Task<IEnumerable<object>> GetMonthlySalesReport(DateTime from, DateTime to);
        Task<IEnumerable<object>> GetBrandWiseSalesReport(DateTime from, DateTime to);
        Task<object> GetProfitLossReport(DateTime from, DateTime to);
        Task<decimal?> GetSuggestedPriceAsync(int mobileId);






    }
}

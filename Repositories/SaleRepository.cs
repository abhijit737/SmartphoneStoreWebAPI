using Microsoft.EntityFrameworkCore;
using MobilePhoneStore.Data;
using MobilePhoneStore.Models;

namespace MobilePhoneStore.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly ApplicationDbContext _context;

        public SaleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Sale> CreateSaleAsync(Sale sale)
        {
            _context.Sales.Add(sale);
            await _context.SaveChangesAsync();
            return sale;
        }

        public async Task<IEnumerable<object>> GetMonthlySalesReport(DateTime from, DateTime to)
        {
            return await _context.Sales
                .Where(s => s.SaleDate >= from && s.SaleDate <= to)
                .GroupBy(s => new { s.SaleDate.Year, s.SaleDate.Month })
                .Select(g => new
                {
                    Month = g.Key.Month,
                    Year = g.Key.Year,
                    TotalSales = g.Count(),
                    Revenue = g.Sum(x => x.FinalAmount)
                }).ToListAsync();
        }

        public async Task<IEnumerable<object>> GetBrandWiseSalesReport(DateTime from, DateTime to)
        {
            return await _context.SaleItems
                .Where(i => i.Sale.SaleDate >= from && i.Sale.SaleDate <= to)
                .GroupBy(i => i.Mobile.Brand.Name)
                .Select(g => new
                {
                    Brand = g.Key,
                    QuantitySold = g.Sum(i => i.Quantity),
                    Revenue = g.Sum(i => (i.UnitPrice * i.Quantity) - i.DiscountApplied)
                }).ToListAsync();
        }

        public async Task<object> GetProfitLossReport(DateTime from, DateTime to)
        {
            var sales = await _context.SaleItems
                .Where(i => i.Sale.SaleDate >= from && i.Sale.SaleDate <= to)
                .Include(i => i.Mobile)
                .ToListAsync();

            var cost = sales.Sum(i => i.Mobile.CostPrice * i.Quantity);
            var revenue = sales.Sum(i => (i.UnitPrice * i.Quantity) - i.DiscountApplied);
            var profit = revenue - cost;

            return new
            {
                Revenue = revenue,
                Cost = cost,
                ProfitOrLoss = profit
            };
        }

        public async Task<decimal?> GetSuggestedPriceAsync(int mobileId)
        {
            var sales = await _context.SaleItems
                .Where(i => i.MobileId == mobileId)
                .ToListAsync();

            if (!sales.Any())
                return null;

            decimal totalRevenue = sales.Sum(i => i.UnitPrice * i.Quantity);
            int totalQuantity = sales.Sum(i => i.Quantity);

            return totalRevenue / totalQuantity;
        }
    }
}

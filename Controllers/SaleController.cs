using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobilePhoneStore.DTOs;
using MobilePhoneStore.Services;

namespace MobilePhoneStore.Controllers
{

    [Authorize]

    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleService _saleService;

        public SaleController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateSale([FromBody] SaleDto dto)
        {
            var result = await _saleService.CreateSaleAsync(dto);
            return Ok(result);
        }

        [HttpGet("monthly-report")]
        public async Task<IActionResult> GetMonthlyReport(DateTime from, DateTime to)
        {
            var result = await _saleService.GetMonthlySalesReport(from, to);
            return Ok(result);
        }

        [HttpGet("brand-report")]
        public async Task<IActionResult> GetBrandWiseReport(DateTime from, DateTime to)
        {
            var result = await _saleService.GetBrandWiseSalesReport(from, to);
            return Ok(result);
        }

        [HttpGet("profit-loss")]
        public async Task<IActionResult> GetProfitLossReport(DateTime from, DateTime to)
        {
            var result = await _saleService.GetProfitLossReport(from, to);
            return Ok(result);
        }

        [HttpGet("suggested-price/{mobileId}")]
        public async Task<IActionResult> GetSuggestedPrice(int mobileId)
        {
            var price = await _saleService.GetSuggestedPriceAsync(mobileId);

            if (price == null)
                return NotFound($"No sales data found for mobile ID {mobileId}");

            return Ok(new
            {
                MobileId = mobileId,
                SuggestedPrice = Math.Round(price.Value, 2)
            });
        }
    }
}

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
    public class MobileController : ControllerBase
    {
        private readonly IMobileService _mobileService;

        public MobileController(IMobileService mobileService)
        {
            _mobileService = mobileService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _mobileService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var mobile = await _mobileService.GetByIdAsync(id);
            return mobile == null ? NotFound() : Ok(mobile);
        }

        [HttpPost]
        public async Task<IActionResult> Add(MobileDto dto)
        {
            var result = await _mobileService.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, MobileDto dto)
        {
            await _mobileService.UpdateAsync(id, dto);
            return NoContent();
        }
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mobileService.DeleteAsync(id);
            return NoContent();
        }
    }
}

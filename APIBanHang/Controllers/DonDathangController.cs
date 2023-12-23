using APIBanHang.Data;
using APIBanHang.Models;
using APIBanHang.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIBanHang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonDathangController : ControllerBase
    {
        private readonly IDonDatHangService services_;
        public DonDathangController(IDonDatHangService services)
        {
            services_ = services;
        }
        [HttpGet("danh-sach")]
        public async Task<IActionResult> GetAll()
        {
            var ac = await services_.GetAll();
            return Ok(ac);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var ac = await services_.GetById(id);
            if (ac == null)
            {
                return NotFound();
            }
            return Ok(ac);
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create(Dondathang dondathang)
        {
            if (dondathang == null)
            {
                return BadRequest();
            }
            await services_.Create(dondathang);
            return Ok();
        }

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> Update(string id, Dondathang dondathang)
        {
            if (dondathang == null)
            {
                return BadRequest();
            }
            await services_.Update(id, dondathang);
            return Ok();
        }

        [HttpDelete("delte/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await services_.Delete(id);
            return NoContent();
        }
    }
}

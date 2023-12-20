using APIBanHang.Data;
using APIBanHang.Models;
using APIBanHang.Services;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIBanHang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhachHangController : ControllerBase
    {
        private readonly IKhachHangService services_;

        public KhachHangController(IKhachHangService services)
        {
            services_ = services;
        }
        [HttpGet("danh-sach-khach-hang")]
        public async Task<IActionResult> GetAll()
        {
            var kh = await services_.GetAll();
            return Ok(kh);
        }
        [HttpGet("khach-hang/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var kh = await services_.GetById(id);
            if (kh == null)
            {
                return NotFound();
            }
            return Ok(kh);
        }
        [HttpPost("them-khach-hang")]
        public async Task<IActionResult> Create(Khachhang khachhang)
        {
            if (khachhang == null)
            {
                return BadRequest();
            }
            await services_.Create(khachhang);
            return Ok();
        }

        [HttpPut("khach-hang/{id}")]
        public async Task<IActionResult> Update(string id, Khachhang khachhang)
        {
            if (khachhang == null)
            {
                return BadRequest();
            }
            await services_.Update(id, khachhang);
            return Ok();
        }

        [HttpDelete("khach-hang/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await services_.Delete(id);
            return NoContent();
        }
    }
}

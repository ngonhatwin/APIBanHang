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
        [HttpGet("danh-sach")]
        public async Task<IActionResult> GetAll()
        {
            var kh = await services_.GetAll();
            return Ok(kh);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var kh = await services_.GetById(id);
            if (kh == null)
            {
                return NotFound();
            }
            return Ok(kh);
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create(Khachhang khachhang)
        {
            if (khachhang == null)
            {
                return BadRequest();
            }
            await services_.Create(khachhang);
            return Ok();
        }

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> Update(string id, Khachhang khachhang)
        {
            if (khachhang == null)
            {
                return BadRequest();
            }
            await services_.Update(id, khachhang);
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await services_.Delete(id);
            return NoContent();
        }
    }
}

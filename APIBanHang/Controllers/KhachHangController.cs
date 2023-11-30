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
        private readonly IKhachHangServices khachHangServices_;

        public KhachHangController(IKhachHangServices khachHangServices_)
        {
            this.khachHangServices_ = khachHangServices_;
        }
        [HttpGet("danh-sach-khach-hang")]
        public async Task<IActionResult> GetAllKhachHang()
        {
            var kh = await khachHangServices_.GetAll();
            return Ok(kh);
        }
        [HttpGet("khach-hang/{id}")]
        public async Task<IActionResult> GetKhachHangById(string id)
        {
            var kh = await khachHangServices_.GetByID(id);
            if (kh == null)
            {
                return NotFound();
            }
            return Ok(kh);
        }
        [HttpPost("them-khach-hang")]
        public async Task<IActionResult> CreateKhachHang(MKhachHang khachhang)
        {
            if (khachhang == null)
            {
                return BadRequest();
            }
            await khachHangServices_.Create(khachhang);
            return Ok();
        }

        [HttpPut("khach-hang/{id}")]
        public async Task<IActionResult> UpdateKhachHang(string id, MKhachHang khachhang)
        {
            if (khachhang == null)
            {
                return BadRequest();
            }
            await khachHangServices_.Update(id, khachhang);
            return Ok();
        }

        [HttpDelete("khach-hang/{id}")]
        public async Task<IActionResult> Deletekhachhang(string id)
        {
            await khachHangServices_.Delete(id);
            return NoContent();
        }
    }
}

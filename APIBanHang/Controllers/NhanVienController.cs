using APIBanHang.Data;
using APIBanHang.Models;
using APIBanHang.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIBanHang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhanVienController : ControllerBase
    {
        private readonly INhanVienService services_;
        public NhanVienController(INhanVienService services)
        {
            services_ = services;
        }

        [HttpGet("danh-sach")]
        public async Task<IActionResult> GetAll()
        {
            var nv = await services_.GetAll();
            if (nv == null)
            {
                return NotFound();
            }
            return Ok(nv);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(string id)
        {
            var nv = await services_.GetById(id);
            if (nv == null)
            {
                return BadRequest($"không tìm thấy nhân viên có id là {id}");
            }
            return Ok(nv);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(Nhanvien nhanVien)
        {
            if (nhanVien == null)
            {
                return BadRequest();
            }
            await services_.Create(nhanVien);
            return Ok();

        }
        [HttpPut("edit/{id}")]
        public async Task<IActionResult> Edit(string id, Nhanvien nhanVien)
        {
            if (nhanVien == null)
            {
                return BadRequest();
            }
            await services_.Update(id, nhanVien);
            return Ok();
        }

        [HttpDelete("delete/{id}")]

        public async Task<IActionResult> Delete(string id)
        {
            await services_.Delete(id);
            return Ok();
        }
    }
}

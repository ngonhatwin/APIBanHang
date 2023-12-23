using APIBanHang.Data;
using APIBanHang.Models;
using APIBanHang.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIBanHang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiHangController : ControllerBase
    {
        private readonly ILoaiHangService services_;
        public LoaiHangController(ILoaiHangService services_)
        {
            this.services_ = services_;
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
        public async Task<IActionResult> Create(Loaihang loaihang)
        {
            if (loaihang == null)
            {
                return BadRequest();
            }
            await services_.Create(loaihang);
            return Ok();
        }

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> Update(string id, Loaihang loaihang)
        {
            if (loaihang == null)
            {
                return BadRequest();
            }
            await services_.Update(id, loaihang);
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

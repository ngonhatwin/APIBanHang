﻿using APIBanHang.Data;
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
        [HttpGet("danh-sach-loai-hang")]
        public async Task<IActionResult> GetAll()
        {
            var ac = await services_.GetAll();
            return Ok(ac);
        }
        [HttpGet("loai-hang/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var ac = await services_.GetById(id);
            if (ac == null)
            {
                return NotFound();
            }
            return Ok(ac);
        }
        [HttpPost("them-loai-hang")]
        public async Task<IActionResult> Create(Loaihang loaihang)
        {
            if (loaihang == null)
            {
                return BadRequest();
            }
            await services_.Create(loaihang);
            return Ok();
        }

        [HttpPut("loai-hang/{id}")]
        public async Task<IActionResult> Update(string id, Loaihang loaihang)
        {
            if (loaihang == null)
            {
                return BadRequest();
            }
            await services_.Update(id, loaihang);
            return Ok();
        }

        [HttpDelete("loai-hang/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await services_.Delete(id);
            return NoContent();
        }
    }
}

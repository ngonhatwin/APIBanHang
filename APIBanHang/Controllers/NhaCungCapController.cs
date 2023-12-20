﻿using APIBanHang.Data;
using APIBanHang.Models;
using APIBanHang.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIBanHang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhaCungCapController : ControllerBase
    {
        private readonly INhaCungCapService services_;
        public NhaCungCapController(INhaCungCapService services)
        {
            services_ = services;
        }
        [HttpGet("danh-sach-nha-cung-cap")]
        public async Task<IActionResult> GetAll()
        {
            var ac = await services_.GetAll();
            return Ok(ac);
        }
        [HttpGet("nha-cung-cap/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var ac = await services_.GetById(id);
            if (ac == null)
            {
                return NotFound();
            }
            return Ok(ac);
        }
        [HttpPost("them-nha-cung-cap")]
        public async Task<IActionResult> Create(Nhacungcap nhacungcap)
        {
            if (nhacungcap == null)
            {
                return BadRequest();
            }
            await services_.Create(nhacungcap);
            return Ok();
        }

        [HttpPut("nha-cung-cap/{id}")]
        public async Task<IActionResult> Update(string id, Nhacungcap nhacungcap)
        {
            if (nhacungcap == null)
            {
                return BadRequest();
            }
            await services_.Update(id, nhacungcap);
            return Ok();
        }

        [HttpDelete("nha-cung-cap/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await services_.Delete(id );
            return NoContent();
        }
    }
}
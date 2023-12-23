using APIBanHang.Data;
using APIBanHang.Filter;
using APIBanHang.Models;
using APIBanHang.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace APIBanHang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService services_;
        public AccountController(IAccountService services)
        {
            services_ = services;
        }
        [HttpGet("get")]
        //[Authorize(Roles = "admin")]
        
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
        [HttpGet("search")]
        public async Task<IActionResult> SreachAccountByName(string name)
        {
            //thiếu await bị lỗi System.Runtime.CompilerServices.AsyncTaskMethodBuilder
            var ac = await services_.SearchAllAccountByName(name);
            if(ac == null)
            {
                return BadRequest("không tìm thấy tài khoản!");
            }    
            return Ok(ac);
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create(Account account)
        {
            if (account == null)
            {
                return BadRequest();
            }
            await services_.Create(account);
            return Ok();
        }
        [HttpPost("create-by-models")]
        
        public async Task<IActionResult> CreateByModels(MAccount account)
        {
            if (account == null)
            {
                return BadRequest();
            }
            await services_.CreateByModels(account);
            return Ok(account);
        }

        [HttpPut("put/{id}")]
        public async Task<IActionResult> Update(string id, Account account)
        {
            if (account == null)
            {
                return BadRequest();
            }
            await services_.Update(id, account);
            return Ok();
        }
        [HttpPut("put-by-models/{id}")]
        public async Task<IActionResult> UpdateByModels(string id, MAccount account)
        {
            if (account == null)
            {
                return BadRequest();
            }
            await services_.EditByModels(id, account);
            return Ok(account);
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await services_.Delete(id);
            return NoContent();
        }
    }
}

using APIBanHang.Data;
using APIBanHang.Models;
using APIBanHang.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace APIBanHang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    

    public class MathangController : ControllerBase
    {
        private readonly IMatHangService services_;
        public MathangController(IMatHangService services_)
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
        [HttpGet("get-by-models")]
        public async Task<IActionResult> GetByModels()
        {
            var mh = await services_.GetByModels();
            if (mh == null)
            {
                return BadRequest("không tìm thấy mặt hàng");
            }
            return Ok(mh);
        }
        [HttpGet("page")]
        public async Task<IActionResult> Page(int page)
        {
            var pd = await services_.Paging(page);
            if (pd == null)
            {
                return BadRequest();
            }
            return Ok(pd);
        }
        //[HttpGet("tim-kiem-nhieu-mat-hang-by-Name")]
        //public async Task<IActionResult> GetAllMHbyName(string? name, decimal? from, decimal? to)
        //{
        //    var mh = await services_.GetAllMatHang(name, from, to);
        //    if (mh == null)
        //    {
        //        return BadRequest("không tìm thấy mặt hàng");
        //    }
        //    return Ok(mh);
        //}
        //[HttpGet("danh-sach-mat-hang-tang-dan-by-gia")]
        //public async Task<IActionResult> GetAllMatHangACS()
        //{
        //    var mh = await services_.GetAllMatHangSortedByGiaHang();
        //    if (mh == null)
        //    {
        //        return BadRequest();
        //    }
        //    return Ok(mh);

        //}
        //[HttpGet("danh-sach-mat-hang-giam-dan-by-gia")]
        //public async Task<IActionResult> GetAllMatHangDES()
        //{
        //    var mh = await services_.GetAllMatHangSortedByGiaHang();
        //    if (mh == null)
        //    {
        //        return BadRequest();
        //    }
        //    return Ok(mh);

        //}
        [HttpGet("search-by-name")]
        public async Task<IActionResult> Search(string name)
        {
            var result = await services_.SearchByName(name);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("get-chi-tiet")]
        public async Task<IActionResult> getChiTietMatHang(string id)
        {
            var result = await services_.getChiTietByid(id);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create(Mathang mathang)
        {
            if (mathang == null)
            {
                return BadRequest();
            }
            await services_.Create(mathang);
            return Ok();
        }
        [HttpPost("create-by-models")]
        public async Task<IActionResult> createByModels(MMatHang mathang)
        {
            if (mathang == null)
            {
                return BadRequest();
            }
            await services_.CreateByModels(mathang);
            return Ok(mathang);
        }
        [HttpPut("edit/{id}")]
        public async Task<IActionResult> Update(string id, Mathang mathang)
        {
            if (mathang == null)
            {
                return BadRequest();
            }
            await services_.Update(id, mathang);
            return Ok();
        }
        [HttpPut("edit-by-models/{id}")]
        public async Task<IActionResult> UpdatebyModels(string id, MMatHang mathang)
        {
            if (mathang == null)
            {
                return BadRequest();
            }    
            await services_.UpdateByModels(id, mathang);
            return Ok(mathang);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await services_.Delete(id );
            return NoContent();
        }

    }
}

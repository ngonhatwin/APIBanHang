using APIBanHang.Data;
using APIBanHang.Models;
using APIBanHang.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace APIBanHang.Services
{
    public interface INhaCungCapService
    {
        Task<IEnumerable<Nhacungcap>> GetAll();
        Task<Nhacungcap> GetById(string id);
        Task Create(Nhacungcap nhaCungCap);
        Task Update(string id, Nhacungcap nhaCungCap);
        Task Delete(string id);

        //Task<IEnumerable<MDonDatHang>> SearchAllAccountByName(string name);
    }
    public class NhaCungCapServices : INhaCungCapService
    {
        private readonly IRepository<Nhacungcap> repository_;
        public NhaCungCapServices(IRepository<Nhacungcap> repository)
        {
            repository_ = repository;
        }
        public async Task Create(Nhacungcap nhaCungCap)
        {
            await repository_.Create(nhaCungCap);
        }

        public async Task Delete(string id)
        {
            await repository_.Delete(id);
        }

        public async Task<IEnumerable<Nhacungcap>> GetAll()
        {
            return await repository_.GetAll();
        }

        public async Task<Nhacungcap> GetById(string id)
        {
            return await repository_.GetById(id);
        }

        public async Task Update(string id, Nhacungcap nhaCungCap)
        {
            await repository_.Update(id, nhaCungCap);
        }
        ////public async Task<IEnumerable<MNhaCungCap>> SearchNCC(string name)
        //{
        //    if (string.IsNullOrEmpty(name))
        //    {
        //        return Enumerable.Empty<MNhaCungCap>();
        //    }
        //    var ncc = await _context.Nhacungcaps
        //       .Where(mh => mh.TenCongTy.Contains(name))
        //       .Select(mh => new MNhaCungCap
        //       {
        //           TenCongTy = mh.TenCongTy,
        //           TenGiaoDich = mh.TenGiaoDich,
        //           Email = mh.Email,
        //           DiaChi = mh.DiaChi,  
        //           DienThoai = mh.DienThoai,
        //           Fax = mh.Fax,    
        //       })
        //       .ToListAsync();

        //    return ncc ?? Enumerable.Empty<MNhaCungCap>();
        //}


    }
}

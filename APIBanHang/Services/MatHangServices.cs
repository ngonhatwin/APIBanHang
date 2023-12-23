using APIBanHang.Data;
using APIBanHang.Models;
using APIBanHang.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;

namespace APIBanHang.Services
{
    public interface IMatHangService
    {
        Task<IEnumerable<Mathang>> GetAll();
        Task<IEnumerable<MMatHang>> GetByModels();
        Task<Chitietmathang> getChiTietByid(string id);
       // Task<IEnumerable<MMatHang>> GetAllMatHangSortedByGiaHang();
        Task<Mathang> GetById(string id);

        //Task<IEnumerable<MMatHang>> GetAllMatHang(string search, decimal? from, decimal? to);
        Task Create(Mathang matHang);
        Task CreateByModels(MMatHang model);
        Task Update(string id, Mathang matHang);
        Task Delete(string id);
        Task <IEnumerable<MMatHang>> Paging(int page);
        Task<IEnumerable<Mathang>> SearchByName(string name);
        Task UpdateByModels(string id,  MMatHang model);
    }
    public class MatHangServices : IMatHangService
    {
        private readonly IRepository<Mathang> repository_;
        private readonly XyzContext _context;
        public static int Pagesize { get; set; } = 6;
        public MatHangServices(IRepository<Mathang> repository, XyzContext context)
        {
            repository_ = repository;
            _context = context;
        }
        public async Task Create(Mathang matHang)
        {
            await repository_.Create(matHang);
        }
        

        public async Task Delete(string id)
        {
            await repository_.Delete(id);
        }

        public async Task<IEnumerable<Mathang>> GetAll()
        {
            return await repository_.GetAll();
            
        }

        public async Task<IEnumerable<MMatHang>> GetByModels()
        {
            var mathang = await (from h in _context.Mathangs select h).ToListAsync();

            return mathang.Select(m => new MMatHang
            {
                TenHang = m.TenHang,
                LinkAnh = m.LinkAnh,
                Description = m.Description
            });
        }

        public async Task<Mathang> GetById(string id)
        {
            return await repository_.GetById(id);
        }

        public async Task Update(string id, Mathang matHang)
        {
            await repository_.Update(id, matHang);
        }
        #region Filtering

        //public async Task<IEnumerable<MMatHang>> GetAllMatHang(string? search, decimal? from, decimal? to)
        //{
        //    if (string.IsNullOrEmpty(search))
        //    {
        //        return Enumerable.Empty<MMatHang>();
        //    }

        //    IQueryable<Mathang> query = _context.Mathangs;

        //    if (from.HasValue)
        //    {
        //        query = query.Where(mh => mh.GiaHang <= from.Value);
        //    }

        //    if (to.HasValue)
        //    {
        //        query = query.Where(mh => mh.GiaHang >= to.Value);
        //    }

        //    var matHang = await query
        //        .Where(mh => mh.TenHang.Contains(search))
        //        .Select(mh => new MMatHang
        //        {
        //            TenHang = mh.TenHang,
        //            CanNang = mh.CanNang,
        //            DonViTinh = mh.DonViTinh,
        //            GiaHang = mh.GiaHang,
        //            KichThuoc = mh.KichThuoc,
        //            MauSac = mh.MauSac,
        //            SoLuong = mh.SoLuong,
        //        })
        //        .AsNoTracking()
        //        .ToListAsync();

        //    return matHang ?? Enumerable.Empty<MMatHang>();
        //}

        #endregion

        #region Sort
        //public async Task<IEnumerable<MMatHang>> GetAllMatHangSortedByGiaHang()
        //{
        //    var matHangList = await _context.Mathangs
        //        .OrderBy(mh => mh.GiaHang)  // Sắp xếp theo giá hàng hóa tăng dần
        //        .Select(mh => new MMatHang
        //        {
        //            TenHang = mh.TenHang,
        //            CanNang = mh.CanNang,
        //            DonViTinh = mh.DonViTinh,
        //            GiaHang = mh.GiaHang,
        //            KichThuoc = mh.KichThuoc,
        //            MauSac = mh.MauSac,
        //            SoLuong = mh.SoLuong,
        //        })
        //        .AsNoTracking()
        //        .ToListAsync();

        //    return matHangList;
        //}
        //public async Task<IEnumerable<MMatHang>> GetAllMatHangSortedByGiaHang2()
        //{
        //    IQueryable<Mathang> query = _context.Mathangs;
        //    var matHangList = await query
        //        .OrderByDescending(mh => mh.GiaHang)  // Sắp xếp theo giá hàng hóa giảm dần
        //        .Select(mh => new MMatHang
        //        {
        //            TenHang = mh.TenHang,
        //            CanNang = mh.CanNang,
        //            DonViTinh = mh.DonViTinh,
        //            GiaHang = mh.GiaHang,
        //            KichThuoc = mh.KichThuoc,
        //            MauSac = mh.MauSac,
        //            SoLuong = mh.SoLuong,
        //        })
        //        .AsNoTracking()
        //        .ToListAsync();

        //    return matHangList;
        //}
        #endregion

        public async Task<IEnumerable<MMatHang>> Paging(int page = 1)
        {
            //pageSize là số lượng phần tử có trong 1 trang

            var product = _context.Mathangs.AsQueryable();


            product = product.OrderBy(e => e.MaHang).Skip((page - 1) * Pagesize).Take(Pagesize);

            var result = product.Select(h => new MMatHang
            {
                TenHang = h.TenHang,
                LinkAnh = h.LinkAnh,
                Description= h.Description
            });
            return await result.ToListAsync();
        }

        public async Task<IEnumerable<Mathang>> SearchByName(string name)
        {
            IQueryable<Mathang> query = _context.Mathangs;

            var matHang = (from mh in query where mh.TenHang.Contains(name) select mh);
            if(matHang != null)
            {
                return await matHang.ToListAsync();
            }
            return null;
        }

        public async Task CreateByModels(MMatHang model)
        {
            var matHang = new Mathang
            {
                MaHang = model.maHang,
                TenHang = model.TenHang,
                LinkAnh = model.LinkAnh,
                Description = model.Description,
                MaCongTy = model.maCongTy,
                MaLoaiHang = model.maLoaiHang
            };
            _context.Add(matHang);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateByModels(string id, MMatHang model)
        {
            IQueryable<Mathang> query = _context.Mathangs;
            var mh = await query
                .Where(e => e.MaHang == id)
                .FirstOrDefaultAsync();
            if (mh != null)
            {
                mh.TenHang = model.TenHang;
                mh.MaCongTy = model.maCongTy;
                mh.MaLoaiHang= model.maLoaiHang;
                mh.LinkAnh = model.LinkAnh;
                mh.Description = model.Description;
            }
            else
            {
                throw new Exception("Mục không tồn tại");
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Chitietmathang> getChiTietByid(string id)
        {
            IQueryable<Chitietmathang> query = _context.Chitietmathangs;
            var ct = await (from ctmh in query
                            join mh in _context.Mathangs on ctmh.MaHang equals mh.MaHang
                            where ctmh.MaHang == id
                            select ctmh
                            )
                            .AsNoTracking()
                            .SingleOrDefaultAsync();
            if (ct != null)
            {
                return new Chitietmathang
                {
                    CanNang = ct.CanNang,
                    DonViTinh = ct.DonViTinh,
                    GiaHang = ct.GiaHang,
                    KichThuoc = ct.KichThuoc,
                    MauSac = ct.MauSac,
                    MaHang = ct.MaHang,
                    SoLuong = ct.SoLuong,
                    TenHang = ct.TenHang,
                };
            }
            throw new Exception("Hàng không tồn tại");
        }
    }
}
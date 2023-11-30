using APIBanHang.Data;
using APIBanHang.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace APIBanHang.Repository
{
    public class KhachHangRepository : IRepository<MKhachHang>
    {
        private readonly XyzContext context_;
        public KhachHangRepository(XyzContext context)
        {
            context_ = context;
        }
        public async Task Create(MKhachHang khachhang)
        {
            var kh = new Khachhang
            {
                MaAccount = khachhang.MaAccount,
                MaKhachHang = khachhang.MaKhachHang,
                TenKhachHang = khachhang.TenKhachHang,
                SanPhamMua = khachhang.SanPhamMua,
                DiaChi = khachhang.DiaChi,
                DienThoai = khachhang.DienThoai,
                Email = khachhang.Email,
                Fax = khachhang.Fax
            };
            context_.Add(kh);
            await context_.SaveChangesAsync();
        }

        public async Task Delete(string id)
        {
            var khachhang = (from kh in context_.Khachhangs
                             where kh.MaKhachHang.ToString() == id
                             select kh
                             ).SingleOrDefault();

            if (khachhang != null)
            {
                context_.Khachhangs.Remove(khachhang);
                await context_.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<MKhachHang>> GetAll()
        {
             var khachhang = await context_.Khachhangs.ToListAsync();
             return khachhang.Select(kh => new MKhachHang
             {
                 MaAccount = kh.MaAccount,
                 MaKhachHang = kh.MaKhachHang,
                 TenKhachHang = kh.TenKhachHang,
                 SanPhamMua = kh.SanPhamMua,
                 DiaChi = kh.DiaChi,
                 DienThoai = kh.DienThoai,
                 Email = kh.Email,
                 Fax = kh.Fax
             });    
        }

        public async Task<MKhachHang> GetById(string id)
        {
            var khachhang = await context_.Khachhangs
                .Where(kh => kh.MaKhachHang.ToString() == id)
                .SingleOrDefaultAsync();
            if (khachhang != null)
            {
                return new MKhachHang
                {
                    MaAccount = khachhang.MaAccount,
                    MaKhachHang = khachhang.MaKhachHang,
                    TenKhachHang = khachhang.TenKhachHang,
                    SanPhamMua = khachhang.SanPhamMua,
                    DiaChi = khachhang.DiaChi,
                    DienThoai = khachhang.DienThoai,
                    Email = khachhang.Email,
                    Fax = khachhang.Fax
                };
            }
            return null;
        }

        public async Task<IEnumerable<MKhachHang>> GetPage(int page, int pageSize)
        {
            return (IEnumerable<MKhachHang>)await context_.Khachhangs.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<IEnumerable<MKhachHang>> Search(string keyword)
        {
            var khachhang = await context_.Khachhangs
                .Where(kh => kh.TenKhachHang.Contains(keyword))
                .ToListAsync();

            // Chuyển đổi danh sách các đối tượng Khachhang sang danh sách các đối tượng MKhachHang
            var result = khachhang.Select(kh => new MKhachHang
            {
                MaAccount = kh.MaAccount,
                MaKhachHang = kh.MaKhachHang,
                TenKhachHang = kh.TenKhachHang,
                SanPhamMua = kh.SanPhamMua,
                DiaChi = kh.DiaChi,
                DienThoai = kh.DienThoai,
                Email = kh.Email,
                Fax = kh.Fax
            }).ToList();
            return result;
        }

        public async Task Update(string id, MKhachHang khachhang)
        {
            var existingKhachHang = context_.Khachhangs.SingleOrDefault(kh => kh.MaKhachHang.ToString() == id);

            if (existingKhachHang != null)
            {
                existingKhachHang.MaKhachHang = khachhang.MaKhachHang;
                existingKhachHang.MaAccount = khachhang.MaAccount;
                existingKhachHang.TenKhachHang = khachhang.TenKhachHang;
                existingKhachHang.SanPhamMua = khachhang.SanPhamMua;
                existingKhachHang.DiaChi = khachhang.DiaChi;
                existingKhachHang.DienThoai = khachhang.DienThoai;
                existingKhachHang.Fax = khachhang.Fax;
                existingKhachHang.Email  = khachhang.Email;
                await context_.SaveChangesAsync();
            }
        }
    }
}

using APIBanHang.Data;
using APIBanHang.Models;
using Microsoft.EntityFrameworkCore;

namespace APIBanHang.Repository
{
    public class NhanVienRepository : IRepository<MNhanVien>
    {
        private readonly XyzContext context_;
        public NhanVienRepository(XyzContext context) 
        { 
            context_ = context;
        }

        public async Task Create(MNhanVien nhanvien)
        {
            var Nhanvien = new Nhanvien
            {
                MaNhanVien = nhanvien.MaNhanVien,
                MaAccount = nhanvien.MaAccount,
                Ten = nhanvien.Ten,
                Ho = nhanvien.Ho,
                DiaChi = nhanvien.DiaChi,
                DienThoai = nhanvien.DienThoai,
                LuongCoBan = nhanvien.LuongCoBan,
                NgayLamViec = nhanvien.NgayLamViec,
                NgaySinh = nhanvien.NgaySinh,
                PhuCap = nhanvien.PhuCap,
            };
            context_.Add(Nhanvien);
            await context_.SaveChangesAsync();
        }

        public async Task Delete(string id)
        {
            var Nhanvien = (from nv in context_.Nhanviens
                            where nv.MaNhanVien == id
                            select nv
                             ).SingleOrDefault();

            if (Nhanvien != null)
            {
                context_.Nhanviens.Remove(Nhanvien);
                await context_.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<MNhanVien>> GetAll()
        {
            var Nhanvien = await context_.Nhanviens.ToListAsync();
            return Nhanvien.Select(nv => new MNhanVien
            {
                MaAccount = nv.MaAccount,
                MaNhanVien = nv.MaNhanVien,
                Ten = nv.Ten,
                Ho = nv.Ho,
                DiaChi = nv.DiaChi,
                DienThoai = nv.DienThoai,
                LuongCoBan = nv.LuongCoBan,
                NgayLamViec = nv.NgayLamViec,
                NgaySinh = nv.NgaySinh,
                PhuCap = nv.PhuCap,
            });
        }

        public async Task<MNhanVien> GetById(string id)
        {
            var Nhanvien = await context_.Nhanviens
                .Where(nv => nv.MaNhanVien == id)
                .SingleOrDefaultAsync();

            if (Nhanvien != null)
            {
                return new MNhanVien
                {
                    MaAccount = Nhanvien.MaAccount,
                    MaNhanVien = Nhanvien.MaNhanVien,
                    Ten = Nhanvien.Ten,
                    Ho = Nhanvien.Ho,
                    DiaChi = Nhanvien.DiaChi,
                    DienThoai = Nhanvien.DienThoai,
                    LuongCoBan = Nhanvien.LuongCoBan,
                    NgayLamViec = Nhanvien.NgayLamViec,
                    NgaySinh = Nhanvien.NgaySinh,
                    PhuCap = Nhanvien.PhuCap,
                };
            }
            return null;
        }

        public async Task<IEnumerable<MNhanVien>> GetPage(int page, int pageSize)
        {
            return (IEnumerable<MNhanVien>)await context_.Nhanviens.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

        }

        public async Task<IEnumerable<MNhanVien>> Search(string keyword)
        {
            var Nhanvien = await context_.Nhanviens
                .Where(nv => nv.Ten.Contains(keyword))
                .ToListAsync();


            var result = Nhanvien.Select(nv => new MNhanVien
            {
                MaAccount = nv.MaAccount,
                MaNhanVien = nv.MaNhanVien,
                Ten = nv.Ten,
                Ho = nv.Ho,
                DiaChi = nv.DiaChi,
                DienThoai = nv.DienThoai,
                LuongCoBan = nv.LuongCoBan,
                NgayLamViec = nv.NgayLamViec,
                NgaySinh = nv.NgaySinh,
                PhuCap = nv.PhuCap,
            }).ToList();
            return result;
        }

        public async Task Update(string id, MNhanVien nhanvien)
        {
            var existNhanVien = context_.Nhanviens.SingleOrDefault(nv => nv.MaNhanVien == id);

            if (existNhanVien != null)
            {
                existNhanVien.Ten = nhanvien.Ten;
                existNhanVien.Ho = nhanvien.Ho;
                existNhanVien.NgaySinh = nhanvien.NgaySinh;
                existNhanVien.NgayLamViec = nhanvien.NgayLamViec;
                existNhanVien.DiaChi = nhanvien.DiaChi;
                existNhanVien.LuongCoBan = nhanvien.LuongCoBan;
                existNhanVien.PhuCap = nhanvien.PhuCap;
                existNhanVien.DienThoai = nhanvien.DienThoai;
                await context_.SaveChangesAsync();
            }
        }
    }
}

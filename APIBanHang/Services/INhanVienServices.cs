using APIBanHang.Models;

namespace APIBanHang.Services
{
    public interface INhanVienServices
    {
        Task<IEnumerable<MNhanVien>> GetAll();
        Task<MNhanVien> GetByID(string id);
        Task Create(MNhanVien Nhanvien);
        Task Update(string id, MNhanVien Nhanvien);
        Task Delete(string id);
        Task<IEnumerable<MNhanVien>> GetPageNhanVien(int page, int pageSize);
    }
}

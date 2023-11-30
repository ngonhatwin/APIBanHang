using APIBanHang.Models;

namespace APIBanHang.Services
{
    public interface IKhachHangServices
    {
        Task<IEnumerable<MKhachHang>> GetAll();
        Task<MKhachHang> GetByID(string id);
        Task Create(MKhachHang khachHang);
        Task Update(string id, MKhachHang khachHang);
        Task Delete(string id);
        Task<IEnumerable<MKhachHang>> GetPageKhachHang(int page, int pageSize);
        //Task<IEnumerable<MKhachHang>> SearchKhachHang(string keyword);
    }
}

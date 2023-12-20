using APIBanHang.Data;
using APIBanHang.Models;
using APIBanHang.Repository;


namespace APIBanHang.Services
{
    public interface IKhachHangService
    {
        Task<IEnumerable<Khachhang>> GetAll();
        Task<Khachhang> GetById(string id);
        Task Create(Khachhang account);
        Task Update(string id, Khachhang account);
        Task Delete(string id);

        //Task<IEnumerable<MDonDatHang>> SearchAllAccountByName(string name);
    }
    public class KhachHangServices : IKhachHangService
    {
        private readonly IRepository<Khachhang> repository_;
        public KhachHangServices(IRepository<Khachhang> repository) 
        {
            repository_ = repository;
        }
        public async Task Create(Khachhang khachHang)
        {
            await repository_.Create(khachHang);
        }

        public async Task Delete(string id)
        {
            await repository_.Delete(id);
        }

        public async Task<IEnumerable<Khachhang>> GetAll()
        {
            return await repository_.GetAll();
        }

        public async Task<Khachhang> GetById(string id)
        {
            return await repository_.GetById(id);
        }

        public async Task Update(string id, Khachhang khachHang)
        {
            await repository_.Update(id, khachHang);
        }
    }
}

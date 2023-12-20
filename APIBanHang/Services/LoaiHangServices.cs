using APIBanHang.Data;
using APIBanHang.Models;
using APIBanHang.Repository;

namespace APIBanHang.Services
{
    public interface ILoaiHangService
    {
        Task<IEnumerable<Loaihang>> GetAll();
        Task<Loaihang> GetById(string id);
        Task Create(Loaihang account);
        Task Update(string id, Loaihang account);
        Task Delete(string id);

        //Task<IEnumerable<MDonDatHang>> SearchAllAccountByName(string name);
    }
    public class LoaiHangServices : ILoaiHangService
    {
        private readonly IRepository<Loaihang> repository_;
        public LoaiHangServices(IRepository<Loaihang> repository) 
        {
            repository_ = repository;
        }
        public async Task Create(Loaihang loaiHang)
        {
            await repository_.Create(loaiHang);
        }

        public async Task Delete(string id)
        {
            await repository_.Delete(id);
        }

        public async Task<IEnumerable<Loaihang>> GetAll()
        {
            return await repository_.GetAll();
        }

        public async Task<Loaihang> GetById(string id)
        {
            return await repository_.GetById(id);
        }

        public async Task Update(string id, Loaihang loaiHang)
        {
            await repository_.Update(id, loaiHang);
        }
    }
}

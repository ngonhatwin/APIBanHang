using APIBanHang.Data;
using APIBanHang.Models;
using APIBanHang.Repository;

namespace APIBanHang.Services
{
    public interface IDonDatHangService
    {
        Task<IEnumerable<Dondathang>> GetAll();
        Task<Dondathang> GetById(string id);
        Task Create(Dondathang account);
        Task Update(string id, Dondathang account);
        Task Delete(string id);

        //Task<IEnumerable<MDonDatHang>> SearchAllAccountByName(string name);
    }
    public class DonDatHangServices : IDonDatHangService
    {
        private readonly IRepository<Dondathang> repository_;

        public DonDatHangServices(IRepository<Dondathang> repository) 
        {
            repository_ = repository;
        }
        public async Task Create(Dondathang ddh)
        {
            await repository_.Create(ddh);
        }

        public async Task Delete(string id)
        {
            await repository_.Delete(id);
        }

        public async Task<IEnumerable<Dondathang>> GetAll()
        {
            return await repository_.GetAll();
        }

        public async Task<Dondathang> GetById(string id)
        {
            return await repository_.GetById(id);
        }

        public async Task Update(string id, Dondathang ddh)
        {
            await repository_.Update(id, ddh);
        }
    }
}

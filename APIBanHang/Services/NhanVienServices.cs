using APIBanHang.Data;
using APIBanHang.Models;
using APIBanHang.Repository;


namespace APIBanHang.Services
{
    public interface INhanVienService
    {
        Task<IEnumerable<Nhanvien>> GetAll();
        Task<Nhanvien> GetById(string id);
        Task Create(Nhanvien account);
        Task Update(string id, Nhanvien account);
        Task Delete(string id);

        //Task<IEnumerable<MDonDatHang>> SearchAllAccountByName(string name);
    }
    public class NhanVienServices : INhanVienService
    {
        private readonly IRepository<Nhanvien> repository_;
        public NhanVienServices(IRepository<Nhanvien> repository)
        {
            repository_ = repository;
        }
        public async Task Create(Nhanvien nhanVien)
        {
            await repository_.Create(nhanVien);
        }

        public async Task Delete(string id)
        {
            await repository_.Delete(id);
        }

        public async Task<IEnumerable<Nhanvien>> GetAll()
        {
            return await repository_.GetAll();
        }

        public async Task<Nhanvien> GetById(string id)
        {
            return await repository_.GetById(id);
        }

        public async Task Update(string id, Nhanvien nhanVien)
        {
            await repository_.Update(id, nhanVien);
        }
    }
}

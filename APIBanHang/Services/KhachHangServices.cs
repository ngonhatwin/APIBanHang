using APIBanHang.Models;
using APIBanHang.Repository;

namespace APIBanHang.Services
{
    public class KhachHangServices : IKhachHangServices
    {
        private readonly IRepository<MKhachHang> khachHangRepository_;

        public KhachHangServices(IRepository<MKhachHang> repository_)
        {
            khachHangRepository_ = repository_;
        }
        public async Task Create(MKhachHang khachHang)
        {
            await khachHangRepository_.Create(khachHang);
        }

        public async Task Delete(string id)
        {
            await khachHangRepository_.Delete(id);
        }

        public Task<IEnumerable<MKhachHang>> GetAll()
        {
            return khachHangRepository_.GetAll();
        }

        public async Task<MKhachHang> GetByID(string id)
        {
            return await khachHangRepository_.GetById(id);
        }

        public async Task<IEnumerable<MKhachHang>> GetPageKhachHang(int page, int pageSize)
        {
            return await khachHangRepository_.GetPage(page, pageSize);
        }

        //public Task<IEnumerable<MKhachHang>> SearchKhachHang(string keyword)
        //{
        //    throw new NotImplementedException();
        //}
        public async Task Update(string id, MKhachHang khachHang)
        {
            await khachHangRepository_.Update(id, khachHang);
        }

    }
}

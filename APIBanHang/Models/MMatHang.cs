namespace APIBanHang.Models
{
    public class MMatHang
    {
        public string MaHang { get; set; } = null!;

        public string? MaCongTy { get; set; }

        public string? TenHang { get; set; }

        public int? CanNang { get; set; }

        public string? MauSac { get; set; }

        public string? KichThuoc { get; set; }

        public string? MaLoaiHang { get; set; }

        public int? SoLuong { get; set; }

        public string? DonViTinh { get; set; }

        public decimal? GiaHang { get; set; }
    }
}

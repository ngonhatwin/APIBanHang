using System;
using System.Collections.Generic;

namespace APIBanHang.Data;

public partial class Dondathang
{
    public int SoHoaDon { get; set; }

    public int? MaKhachHang { get; set; }

    public string? MaNhanVien { get; set; }

    public DateTime? NgayDatHang { get; set; }

    public DateTime? NgayGiaoHang { get; set; }

    public DateTime? NgayChuyenHang { get; set; }

    public string? NoiGiaoHang { get; set; }

    public virtual ICollection<Chitietdonhang> Chitietdonhangs { get; set; } = new List<Chitietdonhang>();

    public virtual Khachhang? MaKhachHangNavigation { get; set; }

    public virtual Nhanvien? MaNhanVienNavigation { get; set; }
}

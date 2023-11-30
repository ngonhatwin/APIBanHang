using System;
using System.Collections.Generic;

namespace APIBanHang.Data;

public partial class Nhanvien
{
    public string MaNhanVien { get; set; } = null!;

    public string? MaAccount { get; set; }

    public string? Ho { get; set; }

    public string? Ten { get; set; }

    public DateTime? NgaySinh { get; set; }

    public DateTime? NgayLamViec { get; set; }

    public string? DiaChi { get; set; }

    public string? DienThoai { get; set; }

    public decimal? LuongCoBan { get; set; }

    public decimal? PhuCap { get; set; }

    public virtual ICollection<Dondathang> Dondathangs { get; set; } = new List<Dondathang>();

    public virtual Account? MaAccountNavigation { get; set; }
}

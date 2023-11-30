using System;
using System.Collections.Generic;

namespace APIBanHang.Data;

public partial class Khachhang
{
    public int MaKhachHang { get; set; }

    public string? MaAccount { get; set; }

    public string? TenKhachHang { get; set; }

    public string? SanPhamMua { get; set; }

    public string? DiaChi { get; set; }

    public string? Email { get; set; }

    public string? DienThoai { get; set; }

    public string? Fax { get; set; }

    public virtual ICollection<Dondathang> Dondathangs { get; set; } = new List<Dondathang>();

    public virtual Account? MaAccountNavigation { get; set; }
}

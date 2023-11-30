using System;
using System.Collections.Generic;

namespace APIBanHang.Data;

public partial class Mathang
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

    public virtual ICollection<Chitietdonhang> Chitietdonhangs { get; set; } = new List<Chitietdonhang>();

    public virtual Nhacungcap? MaCongTyNavigation { get; set; }

    public virtual Loaihang? MaLoaiHangNavigation { get; set; }
}

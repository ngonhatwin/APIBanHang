using System;
using System.Collections.Generic;

namespace APIBanHang.Data;

public partial class Chitietmathang
{
    public string MaHang { get; set; } = null!;

    public string? TenHang { get; set; }

    public int? CanNang { get; set; }

    public string? MauSac { get; set; }

    public string? KichThuoc { get; set; }

    public int? SoLuong { get; set; }

    public string? DonViTinh { get; set; }

    public decimal? GiaHang { get; set; }
}

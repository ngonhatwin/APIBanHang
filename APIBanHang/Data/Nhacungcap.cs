using System;
using System.Collections.Generic;

namespace APIBanHang.Data;

public partial class Nhacungcap
{
    public string MaCongTy { get; set; } = null!;

    public string? TenCongTy { get; set; }

    public string? TenGiaoDich { get; set; }

    public string? DiaChi { get; set; }

    public string? DienThoai { get; set; }

    public string? Fax { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Mathang> Mathangs { get; set; } = new List<Mathang>();
}

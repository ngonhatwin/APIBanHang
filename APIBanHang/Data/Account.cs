using System;
using System.Collections.Generic;

namespace APIBanHang.Data;

public partial class Account
{
    public string MaAccount { get; set; } = null!;

    public string? UserName { get; set; }

    public string? Passwords { get; set; }

    public virtual ICollection<Khachhang> Khachhangs { get; set; } = new List<Khachhang>();

    public virtual ICollection<Nhanvien> Nhanviens { get; set; } = new List<Nhanvien>();
}

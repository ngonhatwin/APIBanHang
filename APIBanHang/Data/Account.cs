using CsvHelper.Configuration.Attributes;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace APIBanHang.Data;

public partial class Account 
{
    [Name("Ma Account")]
    public string MaAccount { get; set; } = null!;
    [Name("User Name")]
    public string? UserName { get; set; }
    [Name("Email")]
    public string? Email {  get; set; }
    [Name("Passwords")]
    public string? Passwords { get; set; }

    public virtual ICollection<Khachhang> Khachhangs { get; set; } = new List<Khachhang>();

    public virtual ICollection<Nhanvien> Nhanviens { get; set; } = new List<Nhanvien>();
}

using System;
using System.Collections.Generic;

namespace APIBanHang.Data;

public partial class Mathang
{
    public string MaHang { get; set; } = null!;

    public string LinkAnh { get; set; } = null!;

    public string Description { get; set; } = null!;
    public string? MaCongTy { get; set; }

    public string? TenHang { get; set; }


    public string? MaLoaiHang { get; set; }



    public virtual ICollection<Chitietdonhang> Chitietdonhangs { get; set; } = new List<Chitietdonhang>();

    public virtual Nhacungcap? MaCongTyNavigation { get; set; }

    public virtual Loaihang? MaLoaiHangNavigation { get; set; }

    public virtual Chitietmathang? ChitietmathangNavigation {  get; set; }
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace APIBanHang.Data;

public partial class XyzContext : DbContext
{
    public XyzContext()
    {
    }

    public XyzContext(DbContextOptions<XyzContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Chitietdonhang> Chitietdonhangs { get; set; }

    public virtual DbSet<Chitietmathang> Chitietmathangs { get; set; }

    public virtual DbSet<Dondathang> Dondathangs { get; set; }

    public virtual DbSet<Khachhang> Khachhangs { get; set; }

    public virtual DbSet<Loaihang> Loaihangs { get; set; }

    public virtual DbSet<Mathang> Mathangs { get; set; }

    public virtual DbSet<Nhacungcap> Nhacungcaps { get; set; }

    public virtual DbSet<Nhanvien> Nhanviens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-SR6CI3Q\\SQLEXPRESS;Initial Catalog=xyz;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.MaAccount).HasName("PK__ACCOUNT__0A2B8E34B4280F2D");

            entity.ToTable("ACCOUNT");

            entity.Property(e => e.MaAccount).HasMaxLength(50);
            entity.Property(e => e.Passwords)
                .HasMaxLength(50)
                .HasColumnName("passwords");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Chitietdonhang>(entity =>
        {
            entity.HasKey(e => new { e.SoHoaDon, e.MaHang }).HasName("PK__CHITIETD__C0B293E30148B623");

            entity.ToTable("CHITIETDONHANG");

            entity.Property(e => e.MaHang)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.GiaBan).HasColumnType("numeric(10, 2)");
            entity.Property(e => e.MuaGiamGia).HasColumnType("numeric(10, 2)");

            entity.HasOne(d => d.MaHangNavigation).WithMany(p => p.Chitietdonhangs)
                .HasForeignKey(d => d.MaHang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CHITIETDO__MaHan__4D94879B");

            entity.HasOne(d => d.SoHoaDonNavigation).WithMany(p => p.Chitietdonhangs)
                .HasForeignKey(d => d.SoHoaDon)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CHITIETDO__SoHoa__4CA06362");
        });

        modelBuilder.Entity<Chitietmathang>(entity =>
        {
            entity.HasKey(e => e.MaHang).HasName("PK__CHITIETM__19C0DB1D3009AE8F");

            entity.ToTable("CHITIETMATHANG");

            entity.Property(e => e.MaHang)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.KichThuoc).HasMaxLength(20);
            entity.Property(e => e.MauSac).HasMaxLength(10);
            entity.Property(e => e.TenHang).HasMaxLength(30);
        });

        modelBuilder.Entity<Dondathang>(entity =>
        {
            entity.HasKey(e => e.SoHoaDon).HasName("PK__DONDATHA__012E9E52FD6D9ED9");

            entity.ToTable("DONDATHANG");

            entity.Property(e => e.SoHoaDon).ValueGeneratedNever();
            entity.Property(e => e.MaNhanVien)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.NgayChuyenHang).HasColumnType("smalldatetime");
            entity.Property(e => e.NgayDatHang).HasColumnType("smalldatetime");
            entity.Property(e => e.NgayGiaoHang).HasColumnType("smalldatetime");
            entity.Property(e => e.NoiGiaoHang).HasMaxLength(50);

            entity.HasOne(d => d.MaKhachHangNavigation).WithMany(p => p.Dondathangs)
                .HasForeignKey(d => d.MaKhachHang)
                .HasConstraintName("FK__DONDATHAN__MaKha__48CFD27E");

            entity.HasOne(d => d.MaNhanVienNavigation).WithMany(p => p.Dondathangs)
                .HasForeignKey(d => d.MaNhanVien)
                .HasConstraintName("FK__DONDATHAN__MaNha__49C3F6B7");
        });

        modelBuilder.Entity<Khachhang>(entity =>
        {
            entity.HasKey(e => e.MaKhachHang).HasName("PK__KHACHHAN__88D2F0E546A61CD6");

            entity.ToTable("KHACHHANG");

            entity.Property(e => e.MaKhachHang).ValueGeneratedNever();
            entity.Property(e => e.DiaChi).HasMaxLength(50);
            entity.Property(e => e.DienThoai)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Fax)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.MaAccount).HasMaxLength(50);
            entity.Property(e => e.SanPhamMua).HasMaxLength(20);
            entity.Property(e => e.TenKhachHang).HasMaxLength(50);

            entity.HasOne(d => d.MaAccountNavigation).WithMany(p => p.Khachhangs)
                .HasForeignKey(d => d.MaAccount)
                .HasConstraintName("FK__KHACHHANG__Fax__398D8EEE");
        });

        modelBuilder.Entity<Loaihang>(entity =>
        {
            entity.HasKey(e => e.MaLoaiHang).HasName("PK__LOAIHANG__5EEA4160B0D6C536");

            entity.ToTable("LOAIHANG");

            entity.Property(e => e.MaLoaiHang)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TenLoaiHang).HasMaxLength(30);
        });

        modelBuilder.Entity<Mathang>(entity =>
        {
            entity.HasKey(e => e.MaHang).HasName("PK__MATHANG__19C0DB1DBF3A2B6F");

            entity.ToTable("MATHANG");

            entity.Property(e => e.MaHang)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.DonViTinh).HasMaxLength(10);
            entity.Property(e => e.GiaHang).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.KichThuoc).HasMaxLength(20);
            entity.Property(e => e.MaCongTy)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MaLoaiHang)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MauSac).HasMaxLength(10);
            entity.Property(e => e.TenHang).HasMaxLength(30);

            entity.HasOne(d => d.MaCongTyNavigation).WithMany(p => p.Mathangs)
                .HasForeignKey(d => d.MaCongTy)
                .HasConstraintName("FK__MATHANG__MaCongT__4222D4EF");

            entity.HasOne(d => d.MaLoaiHangNavigation).WithMany(p => p.Mathangs)
                .HasForeignKey(d => d.MaLoaiHang)
                .HasConstraintName("FK__MATHANG__MaLoaiH__4316F928");
        });

        modelBuilder.Entity<Nhacungcap>(entity =>
        {
            entity.HasKey(e => e.MaCongTy).HasName("PK__NHACUNGC__E452D3DB56A0B92D");

            entity.ToTable("NHACUNGCAP");

            entity.Property(e => e.MaCongTy)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.DiaChi).HasMaxLength(50);
            entity.Property(e => e.DienThoai)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Fax)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.TenCongTy).HasMaxLength(40);
            entity.Property(e => e.TenGiaoDich).HasMaxLength(30);
        });

        modelBuilder.Entity<Nhanvien>(entity =>
        {
            entity.HasKey(e => e.MaNhanVien).HasName("PK__NHANVIEN__77B2CA47267B669C");

            entity.ToTable("NHANVIEN");

            entity.Property(e => e.MaNhanVien)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.DiaChi).HasMaxLength(50);
            entity.Property(e => e.DienThoai)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Ho).HasMaxLength(20);
            entity.Property(e => e.LuongCoBan).HasColumnType("numeric(10, 2)");
            entity.Property(e => e.MaAccount).HasMaxLength(50);
            entity.Property(e => e.NgayLamViec).HasColumnType("datetime");
            entity.Property(e => e.NgaySinh).HasColumnType("datetime");
            entity.Property(e => e.PhuCap).HasColumnType("numeric(10, 2)");
            entity.Property(e => e.Ten).HasMaxLength(10);

            entity.HasOne(d => d.MaAccountNavigation).WithMany(p => p.Nhanviens)
                .HasForeignKey(d => d.MaAccount)
                .HasConstraintName("FK__NHANVIEN__PhuCap__45F365D3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

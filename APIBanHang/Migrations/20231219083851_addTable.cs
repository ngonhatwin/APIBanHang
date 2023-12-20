using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIBanHang.Migrations
{
    /// <inheritdoc />
    public partial class addTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ACCOUNT",
                columns: table => new
                {
                    MaAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    passwords = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ACCOUNT__0A2B8E34B4280F2D", x => x.MaAccount);
                });

            migrationBuilder.CreateTable(
                name: "CHITIETMATHANG",
                columns: table => new
                {
                    MaHang = table.Column<string>(type: "char(4)", unicode: false, fixedLength: true, maxLength: 4, nullable: false),
                    TenHang = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    CanNang = table.Column<int>(type: "int", maxLength: 20, nullable: true),
                    MauSac = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    KichThuoc = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    SoLuong = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    DonViTinh = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    GiaHang = table.Column<decimal>(type: "decimal(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CHITIETM__19C0DB1D3009AE8F", x => x.MaHang);
                });

            migrationBuilder.CreateTable(
                name: "LOAIHANG",
                columns: table => new
                {
                    MaLoaiHang = table.Column<string>(type: "char(2)", unicode: false, fixedLength: true, maxLength: 2, nullable: false),
                    TenLoaiHang = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LOAIHANG__5EEA4160B0D6C536", x => x.MaLoaiHang);
                });

            migrationBuilder.CreateTable(
                name: "NHACUNGCAP",
                columns: table => new
                {
                    MaCongTy = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: false),
                    TenCongTy = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    TenGiaoDich = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DienThoai = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    Fax = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    Email = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NHACUNGC__E452D3DB56A0B92D", x => x.MaCongTy);
                });

            migrationBuilder.CreateTable(
                name: "KHACHHANG",
                columns: table => new
                {
                    MaKhachHang = table.Column<int>(type: "int", nullable: false),
                    MaAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TenKhachHang = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SanPhamMua = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    DienThoai = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    Fax = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__KHACHHAN__88D2F0E546A61CD6", x => x.MaKhachHang);
                    table.ForeignKey(
                        name: "FK__KHACHHANG__Fax__398D8EEE",
                        column: x => x.MaAccount,
                        principalTable: "ACCOUNT",
                        principalColumn: "MaAccount");
                });

            migrationBuilder.CreateTable(
                name: "NHANVIEN",
                columns: table => new
                {
                    MaNhanVien = table.Column<string>(type: "char(4)", unicode: false, fixedLength: true, maxLength: 4, nullable: false),
                    MaAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Ho = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Ten = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    NgaySinh = table.Column<DateTime>(type: "datetime", nullable: true),
                    NgayLamViec = table.Column<DateTime>(type: "datetime", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DienThoai = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    LuongCoBan = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    PhuCap = table.Column<decimal>(type: "numeric(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NHANVIEN__77B2CA47267B669C", x => x.MaNhanVien);
                    table.ForeignKey(
                        name: "FK__NHANVIEN__PhuCap__45F365D3",
                        column: x => x.MaAccount,
                        principalTable: "ACCOUNT",
                        principalColumn: "MaAccount");
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaAccount = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JwtID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    IsRevoked = table.Column<bool>(type: "bit", nullable: false),
                    IssuedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpireAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_ACCOUNT_MaAccount",
                        column: x => x.MaAccount,
                        principalTable: "ACCOUNT",
                        principalColumn: "MaAccount",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MATHANG",
                columns: table => new
                {
                    MaHang = table.Column<string>(type: "char(4)", unicode: false, fixedLength: true, maxLength: 4, nullable: false),
                    LinkAnh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaCongTy = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: true),
                    TenHang = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    MaLoaiHang = table.Column<string>(type: "char(2)", unicode: false, fixedLength: true, maxLength: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__MATHANG__19C0DB1DBF3A2B6F", x => x.MaHang);
                    table.ForeignKey(
                        name: "FK_MATHANG_CHITIETMATHANG_MaHang",
                        column: x => x.MaHang,
                        principalTable: "CHITIETMATHANG",
                        principalColumn: "MaHang",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__MATHANG__MaCongT__4222D4EF",
                        column: x => x.MaCongTy,
                        principalTable: "NHACUNGCAP",
                        principalColumn: "MaCongTy");
                    table.ForeignKey(
                        name: "FK__MATHANG__MaLoaiH__4316F928",
                        column: x => x.MaLoaiHang,
                        principalTable: "LOAIHANG",
                        principalColumn: "MaLoaiHang");
                });

            migrationBuilder.CreateTable(
                name: "DONDATHANG",
                columns: table => new
                {
                    SoHoaDon = table.Column<int>(type: "int", nullable: false),
                    MaKhachHang = table.Column<int>(type: "int", nullable: true),
                    MaNhanVien = table.Column<string>(type: "char(4)", unicode: false, fixedLength: true, maxLength: 4, nullable: true),
                    NgayDatHang = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    NgayGiaoHang = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    NgayChuyenHang = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    NoiGiaoHang = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DONDATHA__012E9E52FD6D9ED9", x => x.SoHoaDon);
                    table.ForeignKey(
                        name: "FK__DONDATHAN__MaKha__48CFD27E",
                        column: x => x.MaKhachHang,
                        principalTable: "KHACHHANG",
                        principalColumn: "MaKhachHang");
                    table.ForeignKey(
                        name: "FK__DONDATHAN__MaNha__49C3F6B7",
                        column: x => x.MaNhanVien,
                        principalTable: "NHANVIEN",
                        principalColumn: "MaNhanVien");
                });

            migrationBuilder.CreateTable(
                name: "CHITIETDONHANG",
                columns: table => new
                {
                    SoHoaDon = table.Column<int>(type: "int", nullable: false),
                    MaHang = table.Column<string>(type: "char(4)", unicode: false, fixedLength: true, maxLength: 4, nullable: false),
                    GiaBan = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    SoLuong = table.Column<short>(type: "smallint", nullable: true),
                    MuaGiamGia = table.Column<decimal>(type: "numeric(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CHITIETD__C0B293E30148B623", x => new { x.SoHoaDon, x.MaHang });
                    table.ForeignKey(
                        name: "FK__CHITIETDO__MaHan__4D94879B",
                        column: x => x.MaHang,
                        principalTable: "MATHANG",
                        principalColumn: "MaHang");
                    table.ForeignKey(
                        name: "FK__CHITIETDO__SoHoa__4CA06362",
                        column: x => x.SoHoaDon,
                        principalTable: "DONDATHANG",
                        principalColumn: "SoHoaDon");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CHITIETDONHANG_MaHang",
                table: "CHITIETDONHANG",
                column: "MaHang");

            migrationBuilder.CreateIndex(
                name: "IX_DONDATHANG_MaKhachHang",
                table: "DONDATHANG",
                column: "MaKhachHang");

            migrationBuilder.CreateIndex(
                name: "IX_DONDATHANG_MaNhanVien",
                table: "DONDATHANG",
                column: "MaNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_KHACHHANG_MaAccount",
                table: "KHACHHANG",
                column: "MaAccount");

            migrationBuilder.CreateIndex(
                name: "IX_MATHANG_MaCongTy",
                table: "MATHANG",
                column: "MaCongTy");

            migrationBuilder.CreateIndex(
                name: "IX_MATHANG_MaLoaiHang",
                table: "MATHANG",
                column: "MaLoaiHang");

            migrationBuilder.CreateIndex(
                name: "IX_NHANVIEN_MaAccount",
                table: "NHANVIEN",
                column: "MaAccount");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_MaAccount",
                table: "RefreshTokens",
                column: "MaAccount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CHITIETDONHANG");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "MATHANG");

            migrationBuilder.DropTable(
                name: "DONDATHANG");

            migrationBuilder.DropTable(
                name: "CHITIETMATHANG");

            migrationBuilder.DropTable(
                name: "NHACUNGCAP");

            migrationBuilder.DropTable(
                name: "LOAIHANG");

            migrationBuilder.DropTable(
                name: "KHACHHANG");

            migrationBuilder.DropTable(
                name: "NHANVIEN");

            migrationBuilder.DropTable(
                name: "ACCOUNT");
        }
    }
}

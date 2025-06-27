using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_Adidas.Data.Migrations
{
    public partial class ThemDuLieu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GioHang",
                columns: table => new
                {
                    MaGioHang = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaNguoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DaXoa = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GioHang", x => x.MaGioHang);
                });

            migrationBuilder.CreateTable(
                name: "TheLoai",
                columns: table => new
                {
                    MaTheLoai = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTheLoai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheLoai", x => x.MaTheLoai);
                });

            migrationBuilder.CreateTable(
                name: "TrangThaiDonHang",
                columns: table => new
                {
                    MaTrangThaiDonHang = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTrangThaiDonHang = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrangThaiDonHang", x => x.MaTrangThaiDonHang);
                });

            migrationBuilder.CreateTable(
                name: "Sach",
                columns: table => new
                {
                    MaSanPham = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenSanPham = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Size = table.Column<float>(type: "real", nullable: false),
                    Gia = table.Column<double>(type: "float", nullable: false),
                    HinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaTheLoai = table.Column<int>(type: "int", nullable: false),
                    TheLoaiMaTheLoai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sach", x => x.MaSanPham);
                    table.ForeignKey(
                        name: "FK_Sach_TheLoai_TheLoaiMaTheLoai",
                        column: x => x.TheLoaiMaTheLoai,
                        principalTable: "TheLoai",
                        principalColumn: "MaTheLoai",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DonHang",
                columns: table => new
                {
                    MaDonHang = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaNguoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayTaoDonHang = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaTrangThaiDonHang = table.Column<int>(type: "int", nullable: false),
                    DaXoa = table.Column<bool>(type: "bit", nullable: false),
                    TrangThaiDonHangMaTrangThaiDonHang = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonHang", x => x.MaDonHang);
                    table.ForeignKey(
                        name: "FK_DonHang_TrangThaiDonHang_TrangThaiDonHangMaTrangThaiDonHang",
                        column: x => x.TrangThaiDonHangMaTrangThaiDonHang,
                        principalTable: "TrangThaiDonHang",
                        principalColumn: "MaTrangThaiDonHang",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietGioHang",
                columns: table => new
                {
                    MaChiTietGioHang = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaGioHang = table.Column<int>(type: "int", nullable: false),
                    MaSanPhan = table.Column<int>(type: "int", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    DonGia = table.Column<double>(type: "float", nullable: false),
                    GioHangMaGioHang = table.Column<int>(type: "int", nullable: false),
                    SanPhamMaSanPham = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietGioHang", x => x.MaChiTietGioHang);
                    table.ForeignKey(
                        name: "FK_ChiTietGioHang_GioHang_GioHangMaGioHang",
                        column: x => x.GioHangMaGioHang,
                        principalTable: "GioHang",
                        principalColumn: "MaGioHang",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietGioHang_Sach_SanPhamMaSanPham",
                        column: x => x.SanPhamMaSanPham,
                        principalTable: "Sach",
                        principalColumn: "MaSanPham",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietDonHang",
                columns: table => new
                {
                    MaChiTietDonHAng = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaDonHang = table.Column<int>(type: "int", nullable: false),
                    MaSanPham = table.Column<int>(type: "int", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    DonGia = table.Column<double>(type: "float", nullable: false),
                    SachMaSanPham = table.Column<int>(type: "int", nullable: false),
                    DonHangMaDonHang = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietDonHang", x => x.MaChiTietDonHAng);
                    table.ForeignKey(
                        name: "FK_ChiTietDonHang_DonHang_DonHangMaDonHang",
                        column: x => x.DonHangMaDonHang,
                        principalTable: "DonHang",
                        principalColumn: "MaDonHang",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietDonHang_Sach_SachMaSanPham",
                        column: x => x.SachMaSanPham,
                        principalTable: "Sach",
                        principalColumn: "MaSanPham",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDonHang_DonHangMaDonHang",
                table: "ChiTietDonHang",
                column: "DonHangMaDonHang");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDonHang_SachMaSanPham",
                table: "ChiTietDonHang",
                column: "SachMaSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietGioHang_GioHangMaGioHang",
                table: "ChiTietGioHang",
                column: "GioHangMaGioHang");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietGioHang_SanPhamMaSanPham",
                table: "ChiTietGioHang",
                column: "SanPhamMaSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_DonHang_TrangThaiDonHangMaTrangThaiDonHang",
                table: "DonHang",
                column: "TrangThaiDonHangMaTrangThaiDonHang");

            migrationBuilder.CreateIndex(
                name: "IX_Sach_TheLoaiMaTheLoai",
                table: "Sach",
                column: "TheLoaiMaTheLoai");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietDonHang");

            migrationBuilder.DropTable(
                name: "ChiTietGioHang");

            migrationBuilder.DropTable(
                name: "DonHang");

            migrationBuilder.DropTable(
                name: "GioHang");

            migrationBuilder.DropTable(
                name: "Sach");

            migrationBuilder.DropTable(
                name: "TrangThaiDonHang");

            migrationBuilder.DropTable(
                name: "TheLoai");
        }
    }
}

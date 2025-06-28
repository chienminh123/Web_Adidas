using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_Adidas.Data.Migrations
{
    public partial class themDuLieu2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietDonHang_Sach_SachMaSanPham",
                table: "ChiTietDonHang");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietGioHang_Sach_SanPhamMaSanPham",
                table: "ChiTietGioHang");

            migrationBuilder.DropForeignKey(
                name: "FK_Sach_TheLoai_TheLoaiMaTheLoai",
                table: "Sach");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sach",
                table: "Sach");

            migrationBuilder.DropColumn(
                name: "MaTrangThaiDonHang",
                table: "DonHang");

            migrationBuilder.DropColumn(
                name: "MaGioHang",
                table: "ChiTietGioHang");

            migrationBuilder.DropColumn(
                name: "MaSanPhan",
                table: "ChiTietGioHang");

            migrationBuilder.DropColumn(
                name: "MaDonHang",
                table: "ChiTietDonHang");

            migrationBuilder.DropColumn(
                name: "MaSanPham",
                table: "ChiTietDonHang");

            migrationBuilder.DropColumn(
                name: "MaTheLoai",
                table: "Sach");

            migrationBuilder.RenameTable(
                name: "Sach",
                newName: "SanPham");

            migrationBuilder.RenameIndex(
                name: "IX_Sach_TheLoaiMaTheLoai",
                table: "SanPham",
                newName: "IX_SanPham_TheLoaiMaTheLoai");

            migrationBuilder.AlterColumn<string>(
                name: "Size",
                table: "SanPham",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SanPham",
                table: "SanPham",
                column: "MaSanPham");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietDonHang_SanPham_SachMaSanPham",
                table: "ChiTietDonHang",
                column: "SachMaSanPham",
                principalTable: "SanPham",
                principalColumn: "MaSanPham",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietGioHang_SanPham_SanPhamMaSanPham",
                table: "ChiTietGioHang",
                column: "SanPhamMaSanPham",
                principalTable: "SanPham",
                principalColumn: "MaSanPham",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SanPham_TheLoai_TheLoaiMaTheLoai",
                table: "SanPham",
                column: "TheLoaiMaTheLoai",
                principalTable: "TheLoai",
                principalColumn: "MaTheLoai",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietDonHang_SanPham_SachMaSanPham",
                table: "ChiTietDonHang");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietGioHang_SanPham_SanPhamMaSanPham",
                table: "ChiTietGioHang");

            migrationBuilder.DropForeignKey(
                name: "FK_SanPham_TheLoai_TheLoaiMaTheLoai",
                table: "SanPham");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SanPham",
                table: "SanPham");

            migrationBuilder.RenameTable(
                name: "SanPham",
                newName: "Sach");

            migrationBuilder.RenameIndex(
                name: "IX_SanPham_TheLoaiMaTheLoai",
                table: "Sach",
                newName: "IX_Sach_TheLoaiMaTheLoai");

            migrationBuilder.AddColumn<int>(
                name: "MaTrangThaiDonHang",
                table: "DonHang",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaGioHang",
                table: "ChiTietGioHang",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaSanPhan",
                table: "ChiTietGioHang",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaDonHang",
                table: "ChiTietDonHang",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaSanPham",
                table: "ChiTietDonHang",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<float>(
                name: "Size",
                table: "Sach",
                type: "real",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "MaTheLoai",
                table: "Sach",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sach",
                table: "Sach",
                column: "MaSanPham");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietDonHang_Sach_SachMaSanPham",
                table: "ChiTietDonHang",
                column: "SachMaSanPham",
                principalTable: "Sach",
                principalColumn: "MaSanPham",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietGioHang_Sach_SanPhamMaSanPham",
                table: "ChiTietGioHang",
                column: "SanPhamMaSanPham",
                principalTable: "Sach",
                principalColumn: "MaSanPham",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sach_TheLoai_TheLoaiMaTheLoai",
                table: "Sach",
                column: "TheLoaiMaTheLoai",
                principalTable: "TheLoai",
                principalColumn: "MaTheLoai",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

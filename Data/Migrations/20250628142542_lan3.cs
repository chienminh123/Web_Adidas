using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_Adidas.Data.Migrations
{
    public partial class lan3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietDonHang_SanPham_SachMaSanPham",
                table: "ChiTietDonHang");

            migrationBuilder.RenameColumn(
                name: "SachMaSanPham",
                table: "ChiTietDonHang",
                newName: "SanPhamMaSanPham");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTietDonHang_SachMaSanPham",
                table: "ChiTietDonHang",
                newName: "IX_ChiTietDonHang_SanPhamMaSanPham");

            migrationBuilder.AddColumn<string>(
                name: "DiaChi",
                table: "DonHang",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PTThanhToan",
                table: "DonHang",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SDT",
                table: "DonHang",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "ThanhToan",
                table: "DonHang",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietDonHang_SanPham_SanPhamMaSanPham",
                table: "ChiTietDonHang",
                column: "SanPhamMaSanPham",
                principalTable: "SanPham",
                principalColumn: "MaSanPham",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietDonHang_SanPham_SanPhamMaSanPham",
                table: "ChiTietDonHang");

            migrationBuilder.DropColumn(
                name: "DiaChi",
                table: "DonHang");

            migrationBuilder.DropColumn(
                name: "PTThanhToan",
                table: "DonHang");

            migrationBuilder.DropColumn(
                name: "SDT",
                table: "DonHang");

            migrationBuilder.DropColumn(
                name: "ThanhToan",
                table: "DonHang");

            migrationBuilder.RenameColumn(
                name: "SanPhamMaSanPham",
                table: "ChiTietDonHang",
                newName: "SachMaSanPham");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTietDonHang_SanPhamMaSanPham",
                table: "ChiTietDonHang",
                newName: "IX_ChiTietDonHang_SachMaSanPham");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietDonHang_SanPham_SachMaSanPham",
                table: "ChiTietDonHang",
                column: "SachMaSanPham",
                principalTable: "SanPham",
                principalColumn: "MaSanPham",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

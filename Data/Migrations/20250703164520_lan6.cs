using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_Adidas.Data.Migrations
{
    public partial class lan6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietDonHang_DonHang_DonHangMaDonHang",
                table: "ChiTietDonHang");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietDonHang_SanPham_SanPhamMaSanPham",
                table: "ChiTietDonHang");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietGioHang_GioHang_GioHangMaGioHang",
                table: "ChiTietGioHang");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietGioHang_SanPham_SanPhamMaSanPham",
                table: "ChiTietGioHang");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietDonHang_DonHangMaDonHang",
                table: "ChiTietDonHang");

            migrationBuilder.DropColumn(
                name: "DonHangMaDonHang",
                table: "ChiTietDonHang");

            migrationBuilder.RenameColumn(
                name: "SanPhamMaSanPham",
                table: "ChiTietGioHang",
                newName: "MaSanPham1");

            migrationBuilder.RenameColumn(
                name: "GioHangMaGioHang",
                table: "ChiTietGioHang",
                newName: "MaGioHang1");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTietGioHang_SanPhamMaSanPham",
                table: "ChiTietGioHang",
                newName: "IX_ChiTietGioHang_MaSanPham1");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTietGioHang_GioHangMaGioHang",
                table: "ChiTietGioHang",
                newName: "IX_ChiTietGioHang_MaGioHang1");

            migrationBuilder.RenameColumn(
                name: "SanPhamMaSanPham",
                table: "ChiTietDonHang",
                newName: "MaSanPham1");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTietDonHang_SanPhamMaSanPham",
                table: "ChiTietDonHang",
                newName: "IX_ChiTietDonHang_MaSanPham1");

            migrationBuilder.AlterColumn<string>(
                name: "MaDonHang",
                table: "DonHang",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "MaDonHang1",
                table: "ChiTietDonHang",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDonHang_MaDonHang1",
                table: "ChiTietDonHang",
                column: "MaDonHang1");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietDonHang_DonHang_MaDonHang1",
                table: "ChiTietDonHang",
                column: "MaDonHang1",
                principalTable: "DonHang",
                principalColumn: "MaDonHang",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietDonHang_SanPham_MaSanPham1",
                table: "ChiTietDonHang",
                column: "MaSanPham1",
                principalTable: "SanPham",
                principalColumn: "MaSanPham",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietGioHang_GioHang_MaGioHang1",
                table: "ChiTietGioHang",
                column: "MaGioHang1",
                principalTable: "GioHang",
                principalColumn: "MaGioHang",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietGioHang_SanPham_MaSanPham1",
                table: "ChiTietGioHang",
                column: "MaSanPham1",
                principalTable: "SanPham",
                principalColumn: "MaSanPham",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietDonHang_DonHang_MaDonHang1",
                table: "ChiTietDonHang");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietDonHang_SanPham_MaSanPham1",
                table: "ChiTietDonHang");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietGioHang_GioHang_MaGioHang1",
                table: "ChiTietGioHang");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietGioHang_SanPham_MaSanPham1",
                table: "ChiTietGioHang");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietDonHang_MaDonHang1",
                table: "ChiTietDonHang");

            migrationBuilder.DropColumn(
                name: "MaDonHang1",
                table: "ChiTietDonHang");

            migrationBuilder.RenameColumn(
                name: "MaSanPham1",
                table: "ChiTietGioHang",
                newName: "SanPhamMaSanPham");

            migrationBuilder.RenameColumn(
                name: "MaGioHang1",
                table: "ChiTietGioHang",
                newName: "GioHangMaGioHang");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTietGioHang_MaSanPham1",
                table: "ChiTietGioHang",
                newName: "IX_ChiTietGioHang_SanPhamMaSanPham");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTietGioHang_MaGioHang1",
                table: "ChiTietGioHang",
                newName: "IX_ChiTietGioHang_GioHangMaGioHang");

            migrationBuilder.RenameColumn(
                name: "MaSanPham1",
                table: "ChiTietDonHang",
                newName: "SanPhamMaSanPham");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTietDonHang_MaSanPham1",
                table: "ChiTietDonHang",
                newName: "IX_ChiTietDonHang_SanPhamMaSanPham");

            migrationBuilder.AlterColumn<int>(
                name: "MaDonHang",
                table: "DonHang",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "DonHangMaDonHang",
                table: "ChiTietDonHang",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDonHang_DonHangMaDonHang",
                table: "ChiTietDonHang",
                column: "DonHangMaDonHang");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietDonHang_DonHang_DonHangMaDonHang",
                table: "ChiTietDonHang",
                column: "DonHangMaDonHang",
                principalTable: "DonHang",
                principalColumn: "MaDonHang",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietDonHang_SanPham_SanPhamMaSanPham",
                table: "ChiTietDonHang",
                column: "SanPhamMaSanPham",
                principalTable: "SanPham",
                principalColumn: "MaSanPham",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietGioHang_GioHang_GioHangMaGioHang",
                table: "ChiTietGioHang",
                column: "GioHangMaGioHang",
                principalTable: "GioHang",
                principalColumn: "MaGioHang",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietGioHang_SanPham_SanPhamMaSanPham",
                table: "ChiTietGioHang",
                column: "SanPhamMaSanPham",
                principalTable: "SanPham",
                principalColumn: "MaSanPham",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

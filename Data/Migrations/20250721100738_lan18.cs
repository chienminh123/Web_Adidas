using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_Adidas.Data.Migrations
{
    public partial class lan18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DanhGiaPhanHoi_ChiTietDonHang_MaChiTietDonHAng",
                table: "DanhGiaPhanHoi");

            migrationBuilder.RenameColumn(
                name: "MaChiTietDonHAng",
                table: "DanhGiaPhanHoi",
                newName: "MaDonHang");

            migrationBuilder.RenameIndex(
                name: "IX_DanhGiaPhanHoi_MaChiTietDonHAng",
                table: "DanhGiaPhanHoi",
                newName: "IX_DanhGiaPhanHoi_MaDonHang");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhGiaPhanHoi_DonHang_MaDonHang",
                table: "DanhGiaPhanHoi",
                column: "MaDonHang",
                principalTable: "DonHang",
                principalColumn: "MaDonHang",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DanhGiaPhanHoi_DonHang_MaDonHang",
                table: "DanhGiaPhanHoi");

            migrationBuilder.RenameColumn(
                name: "MaDonHang",
                table: "DanhGiaPhanHoi",
                newName: "MaChiTietDonHAng");

            migrationBuilder.RenameIndex(
                name: "IX_DanhGiaPhanHoi_MaDonHang",
                table: "DanhGiaPhanHoi",
                newName: "IX_DanhGiaPhanHoi_MaChiTietDonHAng");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhGiaPhanHoi_ChiTietDonHang_MaChiTietDonHAng",
                table: "DanhGiaPhanHoi",
                column: "MaChiTietDonHAng",
                principalTable: "ChiTietDonHang",
                principalColumn: "MaChiTietDonHAng",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

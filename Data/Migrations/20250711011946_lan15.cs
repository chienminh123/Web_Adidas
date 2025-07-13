using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_Adidas.Data.Migrations
{
    public partial class lan15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DanhGiaPhanHoi_ChiTietDonHang_ChiTietDonHangMaChiTietDonHAng",
                table: "DanhGiaPhanHoi");

            migrationBuilder.RenameColumn(
                name: "ChiTietDonHangMaChiTietDonHAng",
                table: "DanhGiaPhanHoi",
                newName: "MaChiTietDonHAng");

            migrationBuilder.RenameIndex(
                name: "IX_DanhGiaPhanHoi_ChiTietDonHangMaChiTietDonHAng",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DanhGiaPhanHoi_ChiTietDonHang_MaChiTietDonHAng",
                table: "DanhGiaPhanHoi");

            migrationBuilder.RenameColumn(
                name: "MaChiTietDonHAng",
                table: "DanhGiaPhanHoi",
                newName: "ChiTietDonHangMaChiTietDonHAng");

            migrationBuilder.RenameIndex(
                name: "IX_DanhGiaPhanHoi_MaChiTietDonHAng",
                table: "DanhGiaPhanHoi",
                newName: "IX_DanhGiaPhanHoi_ChiTietDonHangMaChiTietDonHAng");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhGiaPhanHoi_ChiTietDonHang_ChiTietDonHangMaChiTietDonHAng",
                table: "DanhGiaPhanHoi",
                column: "ChiTietDonHangMaChiTietDonHAng",
                principalTable: "ChiTietDonHang",
                principalColumn: "MaChiTietDonHAng",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_Adidas.Data.Migrations
{
    public partial class lan4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DanhGiaPhanHoi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChiTietDonHangMaChiTietDonHAng = table.Column<int>(type: "int", nullable: false),
                    PhanHoi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhGiaPhanHoi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DanhGiaPhanHoi_ChiTietDonHang_ChiTietDonHangMaChiTietDonHAng",
                        column: x => x.ChiTietDonHangMaChiTietDonHAng,
                        principalTable: "ChiTietDonHang",
                        principalColumn: "MaChiTietDonHAng",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DanhGiaPhanHoi_ChiTietDonHangMaChiTietDonHAng",
                table: "DanhGiaPhanHoi",
                column: "ChiTietDonHangMaChiTietDonHAng");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DanhGiaPhanHoi");
        }
    }
}

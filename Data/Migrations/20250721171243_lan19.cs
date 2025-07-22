using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_Adidas.Data.Migrations
{
    public partial class lan19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MaNguoiDung",
                table: "DanhGiaPhanHoi",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaNguoiDung",
                table: "DanhGiaPhanHoi");
        }
    }
}

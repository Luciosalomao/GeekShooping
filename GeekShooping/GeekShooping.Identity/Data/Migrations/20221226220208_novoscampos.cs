using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeekShooping.Identity.Data.Migrations
{
    public partial class novoscampos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "nome",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "sobrenome",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "nome",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "sobrenome",
                table: "AspNetUsers");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kovacs_Adela_Licenta.Migrations
{
    public partial class Categorie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CategorieCafea",
                table: "Cafea",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategorieCafea",
                table: "Cafea");
        }
    }
}

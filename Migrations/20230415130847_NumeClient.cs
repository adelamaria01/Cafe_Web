using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kovacs_Adela_Licenta.Migrations
{
    public partial class NumeClient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NumeClient",
                table: "Poveste",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumeClient",
                table: "Poveste");
        }
    }
}

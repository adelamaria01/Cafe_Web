using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kovacs_Adela_Licenta.Migrations
{
    public partial class toate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Prenume = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Marime",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarimeMl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pret = table.Column<decimal>(type: "decimal(6,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marime", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TipAroma",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DenumireAroma = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipAroma", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TipBoabe",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DenumireBoabe = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipBoabe", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TipCafea",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tip = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipCafea", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TipLapte",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DenumireLapte = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipLapte", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TipTopping",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DenumireTopping = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipTopping", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Poveste",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poveste", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Poveste_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Cafea",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DenumireCafea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipCafeaID = table.Column<int>(type: "int", nullable: true),
                    TipBoabeID = table.Column<int>(type: "int", nullable: true),
                    TipLapteID = table.Column<int>(type: "int", nullable: true),
                    TipAromaID = table.Column<int>(type: "int", nullable: true),
                    TipToppingID = table.Column<int>(type: "int", nullable: true),
                    Pret = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    Imagine = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cafea", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Cafea_TipAroma_TipAromaID",
                        column: x => x.TipAromaID,
                        principalTable: "TipAroma",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Cafea_TipBoabe_TipBoabeID",
                        column: x => x.TipBoabeID,
                        principalTable: "TipBoabe",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Cafea_TipCafea_TipCafeaID",
                        column: x => x.TipCafeaID,
                        principalTable: "TipCafea",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Cafea_TipLapte_TipLapteID",
                        column: x => x.TipLapteID,
                        principalTable: "TipLapte",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Cafea_TipTopping_TipToppingID",
                        column: x => x.TipToppingID,
                        principalTable: "TipTopping",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "CafeaClient",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DenumireCafea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipCafeaID = table.Column<int>(type: "int", nullable: true),
                    TipBoabeID = table.Column<int>(type: "int", nullable: true),
                    TipLapteID = table.Column<int>(type: "int", nullable: true),
                    TipAromaID = table.Column<int>(type: "int", nullable: true),
                    TipToppingID = table.Column<int>(type: "int", nullable: true),
                    MarimeID = table.Column<int>(type: "int", nullable: true),
                    ClientID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CafeaClient", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CafeaClient_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_CafeaClient_Marime_MarimeID",
                        column: x => x.MarimeID,
                        principalTable: "Marime",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_CafeaClient_TipAroma_TipAromaID",
                        column: x => x.TipAromaID,
                        principalTable: "TipAroma",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_CafeaClient_TipBoabe_TipBoabeID",
                        column: x => x.TipBoabeID,
                        principalTable: "TipBoabe",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_CafeaClient_TipCafea_TipCafeaID",
                        column: x => x.TipCafeaID,
                        principalTable: "TipCafea",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_CafeaClient_TipLapte_TipLapteID",
                        column: x => x.TipLapteID,
                        principalTable: "TipLapte",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_CafeaClient_TipTopping_TipToppingID",
                        column: x => x.TipToppingID,
                        principalTable: "TipTopping",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cafea_TipAromaID",
                table: "Cafea",
                column: "TipAromaID");

            migrationBuilder.CreateIndex(
                name: "IX_Cafea_TipBoabeID",
                table: "Cafea",
                column: "TipBoabeID");

            migrationBuilder.CreateIndex(
                name: "IX_Cafea_TipCafeaID",
                table: "Cafea",
                column: "TipCafeaID");

            migrationBuilder.CreateIndex(
                name: "IX_Cafea_TipLapteID",
                table: "Cafea",
                column: "TipLapteID");

            migrationBuilder.CreateIndex(
                name: "IX_Cafea_TipToppingID",
                table: "Cafea",
                column: "TipToppingID");

            migrationBuilder.CreateIndex(
                name: "IX_CafeaClient_ClientID",
                table: "CafeaClient",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_CafeaClient_MarimeID",
                table: "CafeaClient",
                column: "MarimeID");

            migrationBuilder.CreateIndex(
                name: "IX_CafeaClient_TipAromaID",
                table: "CafeaClient",
                column: "TipAromaID");

            migrationBuilder.CreateIndex(
                name: "IX_CafeaClient_TipBoabeID",
                table: "CafeaClient",
                column: "TipBoabeID");

            migrationBuilder.CreateIndex(
                name: "IX_CafeaClient_TipCafeaID",
                table: "CafeaClient",
                column: "TipCafeaID");

            migrationBuilder.CreateIndex(
                name: "IX_CafeaClient_TipLapteID",
                table: "CafeaClient",
                column: "TipLapteID");

            migrationBuilder.CreateIndex(
                name: "IX_CafeaClient_TipToppingID",
                table: "CafeaClient",
                column: "TipToppingID");

            migrationBuilder.CreateIndex(
                name: "IX_Poveste_ClientID",
                table: "Poveste",
                column: "ClientID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cafea");

            migrationBuilder.DropTable(
                name: "CafeaClient");

            migrationBuilder.DropTable(
                name: "Poveste");

            migrationBuilder.DropTable(
                name: "Marime");

            migrationBuilder.DropTable(
                name: "TipAroma");

            migrationBuilder.DropTable(
                name: "TipBoabe");

            migrationBuilder.DropTable(
                name: "TipCafea");

            migrationBuilder.DropTable(
                name: "TipLapte");

            migrationBuilder.DropTable(
                name: "TipTopping");

            migrationBuilder.DropTable(
                name: "Client");
        }
    }
}

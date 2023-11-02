using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MAS_2.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Klient",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumerTelefonu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klient", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MateracLateksowy",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rodzaj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cecha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Wysokosc = table.Column<float>(type: "real", nullable: false),
                    Sztywnosc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Przeznaczenie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cena = table.Column<float>(type: "real", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MateracLateksowy", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Zgloszenies",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KlientID = table.Column<int>(type: "int", nullable: false),
                    MateracLateksowyID = table.Column<int>(type: "int", nullable: false),
                    DataZainicjalizowania = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataZrealizowania = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zgloszenies", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Zgloszenies_Klient_KlientID",
                        column: x => x.KlientID,
                        principalTable: "Klient",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zgloszenies_MateracLateksowy_MateracLateksowyID",
                        column: x => x.MateracLateksowyID,
                        principalTable: "MateracLateksowy",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Zgloszenies_KlientID",
                table: "Zgloszenies",
                column: "KlientID");

            migrationBuilder.CreateIndex(
                name: "IX_Zgloszenies_MateracLateksowyID",
                table: "Zgloszenies",
                column: "MateracLateksowyID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Zgloszenies");

            migrationBuilder.DropTable(
                name: "Klient");

            migrationBuilder.DropTable(
                name: "MateracLateksowy");
        }
    }
}

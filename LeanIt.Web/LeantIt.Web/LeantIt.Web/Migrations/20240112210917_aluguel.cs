using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeantIt.Web.Migrations
{
    /// <inheritdoc />
    public partial class aluguel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AlguelCarros",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Minutos = table.Column<int>(type: "int", nullable: false),
                    CarroId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlguelCarros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlguelCarros_Carros_CarroId",
                        column: x => x.CarroId,
                        principalTable: "Carros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AlguelCarros_CarroId",
                table: "AlguelCarros",
                column: "CarroId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlguelCarros");
        }
    }
}

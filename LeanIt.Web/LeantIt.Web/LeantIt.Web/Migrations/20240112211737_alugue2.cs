using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeantIt.Web.Migrations
{
    /// <inheritdoc />
    public partial class alugue2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "AlguelCarros",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AlguelCarros_UserId",
                table: "AlguelCarros",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AlguelCarros_AspNetUsers_UserId",
                table: "AlguelCarros",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlguelCarros_AspNetUsers_UserId",
                table: "AlguelCarros");

            migrationBuilder.DropIndex(
                name: "IX_AlguelCarros_UserId",
                table: "AlguelCarros");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AlguelCarros");
        }
    }
}

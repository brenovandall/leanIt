using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeantIt.Web.Migrations
{
    /// <inheritdoc />
    public partial class aluguel10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Preco",
                table: "AlguelCarros",
                type: "double",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Preco",
                table: "AlguelCarros");
        }
    }
}

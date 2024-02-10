using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeantIt.Web.Migrations
{
    /// <inheritdoc />
    public partial class feedbackupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "4c09518d-82bc-4475-8ba7-8cf257110e1c" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4c09518d-82bc-4475-8ba7-8cf257110e1c");

            migrationBuilder.AddColumn<string>(
                name: "Avaliacao_Descricao_Feedback",
                table: "AlguelCarros",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "Avaliacao_Estrelas",
                table: "AlguelCarros",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CNH", "CPF", "ConcurrencyStamp", "DataNascimento", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Sexo", "Telefone", "TwoFactorEnabled", "UserName" },
                values: new object[] { "5b5c947b-a47c-4d87-9f41-580dd58a8c2e", 0, "000000000000", "00000000000", "003acc3b-b006-44c9-b997-abae06b60e20", "2000-01-01", "admin@gmail.com", true, false, null, "admin@gmail.com", "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEB4xAUiaS4mTbYcmNGG9qFLqysQbihPC0BcYlzFH1RRRLt+DM7aH7OoCM7re2Ah8OQ==", "0000000000", false, "ae9253c3-22c5-4e84-833a-d59509421174", "Masculino", "0000000000", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "5b5c947b-a47c-4d87-9f41-580dd58a8c2e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "5b5c947b-a47c-4d87-9f41-580dd58a8c2e" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5b5c947b-a47c-4d87-9f41-580dd58a8c2e");

            migrationBuilder.DropColumn(
                name: "Avaliacao_Descricao_Feedback",
                table: "AlguelCarros");

            migrationBuilder.DropColumn(
                name: "Avaliacao_Estrelas",
                table: "AlguelCarros");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CNH", "CPF", "ConcurrencyStamp", "DataNascimento", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Sexo", "Telefone", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4c09518d-82bc-4475-8ba7-8cf257110e1c", 0, "000000000000", "00000000000", "b5e91877-7935-4988-a4af-05e04d16be56", "2000-01-01", "admin@gmail.com", true, false, null, "admin@gmail.com", "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEKhT47+qgBOlFYxs6tmKI1fjHDr5G+DYuaYhN9aWFrigEWrb70gFth2VmQr3MvV5rA==", "0000000000", false, "ad3a8b14-4487-4b8f-8794-cb755a6d9743", "Masculino", "0000000000", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "4c09518d-82bc-4475-8ba7-8cf257110e1c" });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeantIt.Web.Migrations
{
    /// <inheritdoc />
    public partial class brenoatualizadofeedechat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "5f409919-76f4-4546-b65a-ff04f1769719" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5f409919-76f4-4546-b65a-ff04f1769719");

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
                values: new object[] { "a75fe0c9-7b56-4fa2-97f5-3524a39eec4a", 0, "000000000000", "00000000000", "2da62e22-ba0c-4ad0-bf5c-f2e8e7b7feea", "2000-01-01", "admin@gmail.com", true, false, null, "admin@gmail.com", "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEF/fkH5ChpF8MfZDuikNNbiQR3p0scuXn4o+fNg3UUr0pMi4NIEj8LfjI9tu19vweQ==", "0000000000", false, "0b9edddc-14b2-4839-a763-7685b8680f42", "Masculino", "0000000000", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "a75fe0c9-7b56-4fa2-97f5-3524a39eec4a" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "a75fe0c9-7b56-4fa2-97f5-3524a39eec4a" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a75fe0c9-7b56-4fa2-97f5-3524a39eec4a");

            migrationBuilder.DropColumn(
                name: "Avaliacao_Descricao_Feedback",
                table: "AlguelCarros");

            migrationBuilder.DropColumn(
                name: "Avaliacao_Estrelas",
                table: "AlguelCarros");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CNH", "CPF", "ConcurrencyStamp", "DataNascimento", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Sexo", "Telefone", "TwoFactorEnabled", "UserName" },
                values: new object[] { "5f409919-76f4-4546-b65a-ff04f1769719", 0, "000000000000", "00000000000", "530cf6de-7c92-42a8-849d-5f203333bab0", "2000-01-01", "admin@gmail.com", true, false, null, "admin@gmail.com", "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEG568h0K6NzVAx9XyzuZE08B7WdLieaPrZiQ0vFU452rkCfWe7ARnHqst02vytAyLg==", "0000000000", false, "3a0da962-d655-4c41-9368-61d153bea47d", "Masculino", "0000000000", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "5f409919-76f4-4546-b65a-ff04f1769719" });
        }
    }
}

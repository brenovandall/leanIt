using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeantIt.Web.Migrations
{
    /// <inheritdoc />
    public partial class pedrocasa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "a75fe0c9-7b56-4fa2-97f5-3524a39eec4a" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a75fe0c9-7b56-4fa2-97f5-3524a39eec4a");

            migrationBuilder.AlterColumn<string>(
                name: "Avaliacao_Descricao_Feedback",
                table: "AlguelCarros",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CNH", "CPF", "ConcurrencyStamp", "DataNascimento", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Sexo", "Telefone", "TwoFactorEnabled", "UserName" },
                values: new object[] { "efe62718-aad3-44ae-9316-3c461288414c", 0, "000000000000", "00000000000", "feedfdc7-46b1-4a00-8a11-d854847885e2", "2000-01-01", "admin@gmail.com", true, false, null, "admin@gmail.com", "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEGJNpLSHeaXKyk3FFOo8gS6KpBxU6S9Fwp+uLYYFCRFctp5NF8P/JfD/u/tXEDqgww==", "0000000000", false, "9fe25b5e-6b1b-4ad9-bf07-ee258796a258", "Masculino", "0000000000", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "efe62718-aad3-44ae-9316-3c461288414c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "efe62718-aad3-44ae-9316-3c461288414c" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "efe62718-aad3-44ae-9316-3c461288414c");

            migrationBuilder.UpdateData(
                table: "AlguelCarros",
                keyColumn: "Avaliacao_Descricao_Feedback",
                keyValue: null,
                column: "Avaliacao_Descricao_Feedback",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Avaliacao_Descricao_Feedback",
                table: "AlguelCarros",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CNH", "CPF", "ConcurrencyStamp", "DataNascimento", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Sexo", "Telefone", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a75fe0c9-7b56-4fa2-97f5-3524a39eec4a", 0, "000000000000", "00000000000", "2da62e22-ba0c-4ad0-bf5c-f2e8e7b7feea", "2000-01-01", "admin@gmail.com", true, false, null, "admin@gmail.com", "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEF/fkH5ChpF8MfZDuikNNbiQR3p0scuXn4o+fNg3UUr0pMi4NIEj8LfjI9tu19vweQ==", "0000000000", false, "0b9edddc-14b2-4839-a763-7685b8680f42", "Masculino", "0000000000", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "a75fe0c9-7b56-4fa2-97f5-3524a39eec4a" });
        }
    }
}

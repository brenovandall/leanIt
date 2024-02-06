using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeantIt.Web.Migrations
{
    /// <inheritdoc />
    public partial class pedrotesteBD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "a9e78468-f964-4cb7-a7d4-9256370919c1" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a9e78468-f964-4cb7-a7d4-9256370919c1");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CNH", "CPF", "ConcurrencyStamp", "DataNascimento", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Sexo", "Telefone", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4c09518d-82bc-4475-8ba7-8cf257110e1c", 0, "000000000000", "00000000000", "b5e91877-7935-4988-a4af-05e04d16be56", "2000-01-01", "admin@gmail.com", true, false, null, "admin@gmail.com", "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEKhT47+qgBOlFYxs6tmKI1fjHDr5G+DYuaYhN9aWFrigEWrb70gFth2VmQr3MvV5rA==", "0000000000", false, "ad3a8b14-4487-4b8f-8794-cb755a6d9743", "Masculino", "0000000000", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "4c09518d-82bc-4475-8ba7-8cf257110e1c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "4c09518d-82bc-4475-8ba7-8cf257110e1c" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4c09518d-82bc-4475-8ba7-8cf257110e1c");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CNH", "CPF", "ConcurrencyStamp", "DataNascimento", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Sexo", "Telefone", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a9e78468-f964-4cb7-a7d4-9256370919c1", 0, "000000000000", "00000000000", "63ff14b2-56ef-4a2a-bf48-dc6c9588aa60", "2000-01-01", "admin@gmail.com", true, false, null, "admin@gmail.com", "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAELx1xx6s1ja62IZpxwzxTGi/jVHjlw4WHBMZz/2KK5YeDz9alUpWfbLOq+4eGxY7Bw==", "0000000000", false, "1c85e923-efd3-4101-9c42-135c090e350a", "Masculino", "0000000000", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "a9e78468-f964-4cb7-a7d4-9256370919c1" });
        }
    }
}

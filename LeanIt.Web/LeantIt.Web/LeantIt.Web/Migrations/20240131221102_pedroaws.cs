using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeantIt.Web.Migrations
{
    /// <inheritdoc />
    public partial class pedroaws : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "2ac4e68c-095f-4ea3-96c9-63c0d4026a4e" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2ac4e68c-095f-4ea3-96c9-63c0d4026a4e");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CNH", "CPF", "ConcurrencyStamp", "DataNascimento", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Sexo", "Telefone", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a9e78468-f964-4cb7-a7d4-9256370919c1", 0, "000000000000", "00000000000", "63ff14b2-56ef-4a2a-bf48-dc6c9588aa60", "2000-01-01", "admin@gmail.com", true, false, null, "admin@gmail.com", "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAELx1xx6s1ja62IZpxwzxTGi/jVHjlw4WHBMZz/2KK5YeDz9alUpWfbLOq+4eGxY7Bw==", "0000000000", false, "1c85e923-efd3-4101-9c42-135c090e350a", "Masculino", "0000000000", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "a9e78468-f964-4cb7-a7d4-9256370919c1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "2ac4e68c-095f-4ea3-96c9-63c0d4026a4e", 0, "000000000000", "00000000000", "96c2c386-06e0-4e1b-9c1b-b8da8d4290a8", "2000-01-01", "admin@gmail.com", true, false, null, "admin@gmail.com", "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEGW9m/XZnGWCWtJhEE8heF4n02bRoXN9ZbtHaVcJOpuB6qOCqZYd2fOI8wPp1eZkSg==", "0000000000", false, "40149f99-defd-47dc-8f1d-f141f605fa60", "Masculino", "0000000000", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "2ac4e68c-095f-4ea3-96c9-63c0d4026a4e" });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeantIt.Web.Migrations
{
    /// <inheritdoc />
    public partial class brenocasa2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "ed974418-2a56-4713-888c-6b720dba34cf" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ed974418-2a56-4713-888c-6b720dba34cf");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CNH", "CPF", "ConcurrencyStamp", "DataNascimento", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Sexo", "Telefone", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f82f53fc-46c0-4349-b385-8f3c0274d5e4", 0, "000000000000", "00000000000", "4687e9c2-d9e8-4574-b1c9-8596910b0ab1", "2000-01-01", "admin@gmail.com", false, false, null, "admin@gmail.com", "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEIq6CUQxT4uz7rYyGQXLfNuZwDBI5bq9Q4kEuz4Lt184rU3SSKsFn7tJI1RGE/EViA==", "0000000000", false, "c14b7acf-f8e3-4ef5-9146-d02a852dd299", "Masculino", "0000000000", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "f82f53fc-46c0-4349-b385-8f3c0274d5e4" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "f82f53fc-46c0-4349-b385-8f3c0274d5e4" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f82f53fc-46c0-4349-b385-8f3c0274d5e4");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CNH", "CPF", "ConcurrencyStamp", "DataNascimento", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Sexo", "Telefone", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ed974418-2a56-4713-888c-6b720dba34cf", 0, "000000000000", "00000000000", "b1bb9450-ecd5-4db5-a58c-6fd8f67682d5", "2000-01-01", "admin@gmail.com", false, false, null, "admin@gmail.com", null, null, "AQAAAAIAAYagAAAAENVbfgc75pEZrnGoTfivrW0rNQLLsBwRjYC+xg+MtDhEsxhydFFgvqfw0wFdTbG0Ow==", "0000000000", false, "f5cda0e1-87d2-4280-8797-dabda185aa9f", "Masculino", "0000000000", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "ed974418-2a56-4713-888c-6b720dba34cf" });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeantIt.Web.Migrations
{
    /// <inheritdoc />
    public partial class brenocasa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "9ba5da82-8ab1-4128-ad2c-ebe468ee0fd3" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9ba5da82-8ab1-4128-ad2c-ebe468ee0fd3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CNH", "CPF", "ConcurrencyStamp", "DataNascimento", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Sexo", "Telefone", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ed974418-2a56-4713-888c-6b720dba34cf", 0, "000000000000", "00000000000", "b1bb9450-ecd5-4db5-a58c-6fd8f67682d5", "2000-01-01", "admin@gmail.com", false, false, null, "admin@gmail.com", null, null, "AQAAAAIAAYagAAAAENVbfgc75pEZrnGoTfivrW0rNQLLsBwRjYC+xg+MtDhEsxhydFFgvqfw0wFdTbG0Ow==", "0000000000", false, "f5cda0e1-87d2-4280-8797-dabda185aa9f", "Masculino", "0000000000", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "ed974418-2a56-4713-888c-6b720dba34cf" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "ed974418-2a56-4713-888c-6b720dba34cf" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ed974418-2a56-4713-888c-6b720dba34cf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "admin", "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CNH", "CPF", "ConcurrencyStamp", "DataNascimento", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Sexo", "Telefone", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9ba5da82-8ab1-4128-ad2c-ebe468ee0fd3", 0, "000000000000", "00000000000", "15fc6994-900b-4724-ad3f-22723e04f99a", "2000-01-01", "admin@gmail.com", false, false, null, "admin@gmail.com", null, null, "AQAAAAIAAYagAAAAEDBdBJ1P9kHLMBqolx3fPIeU0qZEz2+ao+B52FMDOi4va+nNKUQziNr+Ixbug+LBng==", "0000000000", false, "4abd7a10-3d61-4620-83e5-60878215126f", "Masculino", "0000000000", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "9ba5da82-8ab1-4128-ad2c-ebe468ee0fd3" });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeantIt.Web.Migrations
{
    /// <inheritdoc />
    public partial class brenoproway5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "d55793d5-313a-4549-9e42-5ac1339b688c" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d55793d5-313a-4549-9e42-5ac1339b688c");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CNH", "CPF", "ConcurrencyStamp", "DataNascimento", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Sexo", "Telefone", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9ba5da82-8ab1-4128-ad2c-ebe468ee0fd3", 0, "000000000000", "00000000000", "15fc6994-900b-4724-ad3f-22723e04f99a", "2000-01-01", "admin@gmail.com", false, false, null, "admin@gmail.com", null, null, "AQAAAAIAAYagAAAAEDBdBJ1P9kHLMBqolx3fPIeU0qZEz2+ao+B52FMDOi4va+nNKUQziNr+Ixbug+LBng==", "0000000000", false, "4abd7a10-3d61-4620-83e5-60878215126f", "Masculino", "0000000000", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "9ba5da82-8ab1-4128-ad2c-ebe468ee0fd3" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "9ba5da82-8ab1-4128-ad2c-ebe468ee0fd3" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9ba5da82-8ab1-4128-ad2c-ebe468ee0fd3");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CNH", "CPF", "ConcurrencyStamp", "DataNascimento", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Sexo", "Telefone", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d55793d5-313a-4549-9e42-5ac1339b688c", 0, "000000000000", "00000000000", "c76ac799-0f81-4531-bd39-9c4bda799c80", "2000-01-01", "admin@gmail.com", false, false, null, "admin", null, null, "AQAAAAIAAYagAAAAEJCwbXy07LmBzwkoIMesfkCB+Bi8H9IwcWM4UH/WSxg8n/gTdSW5gTfh5jTBL87n/g==", "0000000000", false, "5ee3ff3a-7246-4bd5-a432-99ee498c461d", "Masculino", "0000000000", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "d55793d5-313a-4549-9e42-5ac1339b688c" });
        }
    }
}

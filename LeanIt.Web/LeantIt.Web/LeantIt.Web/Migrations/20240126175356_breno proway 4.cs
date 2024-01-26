using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeantIt.Web.Migrations
{
    /// <inheritdoc />
    public partial class brenoproway4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e8f6a54b-b06c-4b63-99a2-b00c4d4a49a0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1", "1", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CNH", "CPF", "ConcurrencyStamp", "DataNascimento", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Sexo", "Telefone", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d55793d5-313a-4549-9e42-5ac1339b688c", 0, "000000000000", "00000000000", "c76ac799-0f81-4531-bd39-9c4bda799c80", "2000-01-01", "admin@gmail.com", false, false, null, "admin", null, null, "AQAAAAIAAYagAAAAEJCwbXy07LmBzwkoIMesfkCB+Bi8H9IwcWM4UH/WSxg8n/gTdSW5gTfh5jTBL87n/g==", "0000000000", false, "5ee3ff3a-7246-4bd5-a432-99ee498c461d", "Masculino", "0000000000", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "d55793d5-313a-4549-9e42-5ac1339b688c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "d55793d5-313a-4549-9e42-5ac1339b688c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d55793d5-313a-4549-9e42-5ac1339b688c");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CNH", "CPF", "ConcurrencyStamp", "DataNascimento", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Sexo", "Telefone", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e8f6a54b-b06c-4b63-99a2-b00c4d4a49a0", 0, "000000000000", "00000000000", "72811344-0f5f-4a48-bb64-68ce1ac00304", "2000-01-01", "admin@gmail.com", false, false, null, "admin", null, null, "AQAAAAIAAYagAAAAEIR9WreUe6u5qB4fg1C8ks7u9ehwpXxn+1wmGEnA+yRKHezwSdT/exV6Ud1Hibna9Q==", "0000000000", false, "2e446487-1c09-4908-807b-71cb16a495c5", "Masculino", "0000000000", false, "admin" });
        }
    }
}

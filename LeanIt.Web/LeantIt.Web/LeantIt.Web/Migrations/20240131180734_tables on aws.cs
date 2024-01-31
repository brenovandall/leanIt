using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeantIt.Web.Migrations
{
    /// <inheritdoc />
    public partial class tablesonaws : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "2ac4e68c-095f-4ea3-96c9-63c0d4026a4e", 0, "000000000000", "00000000000", "96c2c386-06e0-4e1b-9c1b-b8da8d4290a8", "2000-01-01", "admin@gmail.com", true, false, null, "admin@gmail.com", "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEGW9m/XZnGWCWtJhEE8heF4n02bRoXN9ZbtHaVcJOpuB6qOCqZYd2fOI8wPp1eZkSg==", "0000000000", false, "40149f99-defd-47dc-8f1d-f141f605fa60", "Masculino", "0000000000", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "2ac4e68c-095f-4ea3-96c9-63c0d4026a4e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "f82f53fc-46c0-4349-b385-8f3c0274d5e4", 0, "000000000000", "00000000000", "4687e9c2-d9e8-4574-b1c9-8596910b0ab1", "2000-01-01", "admin@gmail.com", false, false, null, "admin@gmail.com", "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEIq6CUQxT4uz7rYyGQXLfNuZwDBI5bq9Q4kEuz4Lt184rU3SSKsFn7tJI1RGE/EViA==", "0000000000", false, "c14b7acf-f8e3-4ef5-9146-d02a852dd299", "Masculino", "0000000000", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "f82f53fc-46c0-4349-b385-8f3c0274d5e4" });
        }
    }
}

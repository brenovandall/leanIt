using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeantIt.Web.Migrations
{
    /// <inheritdoc />
    public partial class awsdia13022 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "0c923b46-eab0-47ad-adef-5db77d1da9db" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c923b46-eab0-47ad-adef-5db77d1da9db");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CNH", "CPF", "ConcurrencyStamp", "DataNascimento", "Email", "EmailConfirmed", "ImagemDePerfil", "LockoutEnabled", "LockoutEnd", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Sexo", "Telefone", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8b57ae66-f0b1-4218-830e-d1b37276b175", 0, "000000000000", "00000000000", "544fef13-d131-4b56-acb3-84877adcac41", "2000-01-01", "admin@gmail.com", true, "https://res.cloudinary.com/dubnbered/image/upload/v1702248124/perfil_bwxiye.png", false, null, "admin@gmail.com", "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEPjcz6po6TAHLO8XXjN07iXbIlzXUTTCiyEGKjWsXfJJ6PwoFCX/nP976fz1Q+k6kg==", "0000000000", false, "37a8956f-d292-4249-bf89-bab743e243bf", "Masculino", "0000000000", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "8b57ae66-f0b1-4218-830e-d1b37276b175" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "8b57ae66-f0b1-4218-830e-d1b37276b175" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8b57ae66-f0b1-4218-830e-d1b37276b175");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CNH", "CPF", "ConcurrencyStamp", "DataNascimento", "Email", "EmailConfirmed", "ImagemDePerfil", "LockoutEnabled", "LockoutEnd", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Sexo", "Telefone", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0c923b46-eab0-47ad-adef-5db77d1da9db", 0, "000000000000", "00000000000", "d2e4ed36-478c-4f5b-8fb9-3d6bed1b79dd", "2000-01-01", "admin@gmail.com", true, "https://res.cloudinary.com/dubnbered/image/upload/v1702248124/perfil_bwxiye.png", false, null, "admin@gmail.com", "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAED8GXTD6GvOCiYQVlRl39fPGbVi5h9wepXc7pEmOgkVWIEIunveTYxuBJNaVZwt9HA==", "0000000000", false, "8ff09e91-766c-4486-929f-faa94e150dad", "Masculino", "0000000000", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "0c923b46-eab0-47ad-adef-5db77d1da9db" });
        }
    }
}

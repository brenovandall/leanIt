using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeantIt.Web.Migrations
{
    /// <inheritdoc />
    public partial class awsdia1302 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "59c57002-9c30-4afc-bce1-d007f799046b" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "59c57002-9c30-4afc-bce1-d007f799046b");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CNH", "CPF", "ConcurrencyStamp", "DataNascimento", "Email", "EmailConfirmed", "ImagemDePerfil", "LockoutEnabled", "LockoutEnd", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Sexo", "Telefone", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0c923b46-eab0-47ad-adef-5db77d1da9db", 0, "000000000000", "00000000000", "d2e4ed36-478c-4f5b-8fb9-3d6bed1b79dd", "2000-01-01", "admin@gmail.com", true, "https://res.cloudinary.com/dubnbered/image/upload/v1702248124/perfil_bwxiye.png", false, null, "admin@gmail.com", "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAED8GXTD6GvOCiYQVlRl39fPGbVi5h9wepXc7pEmOgkVWIEIunveTYxuBJNaVZwt9HA==", "0000000000", false, "8ff09e91-766c-4486-929f-faa94e150dad", "Masculino", "0000000000", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "0c923b46-eab0-47ad-adef-5db77d1da9db" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "59c57002-9c30-4afc-bce1-d007f799046b", 0, "000000000000", "00000000000", "d40c5ceb-4011-4989-b154-ebd242b59061", "2000-01-01", "admin@gmail.com", true, "https://res.cloudinary.com/dubnbered/image/upload/v1702248124/perfil_bwxiye.png", false, null, "admin@gmail.com", "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAECIbB+hs/abeLkLsY+7NjVm4pst/4Jlz/f+lYZ8OxqXuK4ynztvp3P1n6TtzQClr7g==", "0000000000", false, "ebcc58b5-252e-41f8-bc84-cdeb9257a741", "Masculino", "0000000000", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "59c57002-9c30-4afc-bce1-d007f799046b" });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeantIt.Web.Migrations
{
    /// <inheritdoc />
    public partial class brenoprowaydia1302 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "e020b1b8-9c30-4fc0-b380-d096edb69e52" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e020b1b8-9c30-4fc0-b380-d096edb69e52");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CNH", "CPF", "ConcurrencyStamp", "DataNascimento", "Email", "EmailConfirmed", "ImagemDePerfil", "LockoutEnabled", "LockoutEnd", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Sexo", "Telefone", "TwoFactorEnabled", "UserName" },
                values: new object[] { "59c57002-9c30-4afc-bce1-d007f799046b", 0, "000000000000", "00000000000", "d40c5ceb-4011-4989-b154-ebd242b59061", "2000-01-01", "admin@gmail.com", true, "https://res.cloudinary.com/dubnbered/image/upload/v1702248124/perfil_bwxiye.png", false, null, "admin@gmail.com", "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAECIbB+hs/abeLkLsY+7NjVm4pst/4Jlz/f+lYZ8OxqXuK4ynztvp3P1n6TtzQClr7g==", "0000000000", false, "ebcc58b5-252e-41f8-bc84-cdeb9257a741", "Masculino", "0000000000", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "59c57002-9c30-4afc-bce1-d007f799046b" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "e020b1b8-9c30-4fc0-b380-d096edb69e52", 0, "000000000000", "00000000000", "dc7730d6-34e8-4b91-bb64-574a1f581c52", "2000-01-01", "admin@gmail.com", true, "https://res.cloudinary.com/dubnbered/image/upload/v1702248124/perfil_bwxiye.png", false, null, "admin@gmail.com", "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEB3W9e0vy4fedvmFsPaHYbl2vnu2jC3/XVsdyZKqKA5CW0p7XeqGLT2qAEQR4ZbfKw==", "0000000000", false, "0cbc93b4-d4f0-4544-bf3f-b650b9c0f4a8", "Masculino", "0000000000", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "e020b1b8-9c30-4fc0-b380-d096edb69e52" });
        }
    }
}

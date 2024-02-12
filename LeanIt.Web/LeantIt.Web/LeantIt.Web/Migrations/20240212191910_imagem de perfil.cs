using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeantIt.Web.Migrations
{
    /// <inheritdoc />
    public partial class imagemdeperfil : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "498f6b09-9f57-48eb-8013-f1a3be855534" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "498f6b09-9f57-48eb-8013-f1a3be855534");

            migrationBuilder.AddColumn<string>(
                name: "ImagemDePerfil",
                table: "AspNetUsers",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CNH", "CPF", "ConcurrencyStamp", "DataNascimento", "Email", "EmailConfirmed", "ImagemDePerfil", "LockoutEnabled", "LockoutEnd", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Sexo", "Telefone", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e020b1b8-9c30-4fc0-b380-d096edb69e52", 0, "000000000000", "00000000000", "dc7730d6-34e8-4b91-bb64-574a1f581c52", "2000-01-01", "admin@gmail.com", true, "https://res.cloudinary.com/dubnbered/image/upload/v1702248124/perfil_bwxiye.png", false, null, "admin@gmail.com", "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEB3W9e0vy4fedvmFsPaHYbl2vnu2jC3/XVsdyZKqKA5CW0p7XeqGLT2qAEQR4ZbfKw==", "0000000000", false, "0cbc93b4-d4f0-4544-bf3f-b650b9c0f4a8", "Masculino", "0000000000", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "e020b1b8-9c30-4fc0-b380-d096edb69e52" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "e020b1b8-9c30-4fc0-b380-d096edb69e52" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e020b1b8-9c30-4fc0-b380-d096edb69e52");

            migrationBuilder.DropColumn(
                name: "ImagemDePerfil",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CNH", "CPF", "ConcurrencyStamp", "DataNascimento", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Sexo", "Telefone", "TwoFactorEnabled", "UserName" },
                values: new object[] { "498f6b09-9f57-48eb-8013-f1a3be855534", 0, "000000000000", "00000000000", "ea8bc0b3-db27-43d0-abce-e749e99a87ec", "2000-01-01", "admin@gmail.com", true, false, null, "admin@gmail.com", "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEGClhKNFZoZ1FmPLPoJpl859PjtpwZwDbNRT3Ai9g9vw74BBIit1ANx6b8uBFAKsWQ==", "0000000000", false, "727f59f8-8897-40a6-be60-fc8a731778e7", "Masculino", "0000000000", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "498f6b09-9f57-48eb-8013-f1a3be855534" });
        }
    }
}

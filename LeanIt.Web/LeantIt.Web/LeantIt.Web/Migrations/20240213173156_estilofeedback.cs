using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeantIt.Web.Migrations
{
    /// <inheritdoc />
    public partial class estilofeedback : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "1e358cbe-884f-4cfc-a0bb-cd1b7fea97ca" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1e358cbe-884f-4cfc-a0bb-cd1b7fea97ca");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CNH", "CPF", "ConcurrencyStamp", "DataNascimento", "Email", "EmailConfirmed", "ImagemDePerfil", "LockoutEnabled", "LockoutEnd", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Sexo", "Telefone", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ba5c92a2-ffd7-409e-b23e-700bd05e12c4", 0, "000000000000", "00000000000", "e1b90bd9-263e-4dcb-a0dd-70adccae8c25", "2000-01-01", "admin@gmail.com", true, "https://res.cloudinary.com/dubnbered/image/upload/v1702248124/perfil_bwxiye.png", false, null, "admin@gmail.com", "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEINe95LYnj9Roqg0s2KwKh2u7vFEHP5k3Yn+1QVS2CMojpBN1LqNCc9RwuyDiirvGA==", "0000000000", false, "af16ba65-77ec-4605-9427-fd06117b5062", "Masculino", "0000000000", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "ba5c92a2-ffd7-409e-b23e-700bd05e12c4" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "ba5c92a2-ffd7-409e-b23e-700bd05e12c4" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ba5c92a2-ffd7-409e-b23e-700bd05e12c4");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CNH", "CPF", "ConcurrencyStamp", "DataNascimento", "Email", "EmailConfirmed", "ImagemDePerfil", "LockoutEnabled", "LockoutEnd", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Sexo", "Telefone", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1e358cbe-884f-4cfc-a0bb-cd1b7fea97ca", 0, "000000000000", "00000000000", "e53ac36b-d0bb-444d-b1a1-8cf8ba3799c7", "2000-01-01", "admin@gmail.com", true, "https://res.cloudinary.com/dubnbered/image/upload/v1702248124/perfil_bwxiye.png", false, null, "admin@gmail.com", "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEKauoZ8uXaFlnWSGciswCprZtGxaN6134CykmgbToh2cP7X6zdClE/Ge1SMUqBCIaA==", "0000000000", false, "3a03d0a5-b72b-4e71-9b1f-0a62a7023f18", "Masculino", "0000000000", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "1e358cbe-884f-4cfc-a0bb-cd1b7fea97ca" });
        }
    }
}

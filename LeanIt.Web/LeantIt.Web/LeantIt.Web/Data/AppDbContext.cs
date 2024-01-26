using LeantIt.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Data;

namespace LeantIt.Web.Data;

public class AppDbContext : IdentityDbContext<AplicacaoUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<CarroModel> Carros { get; set; }
    public DbSet<AluguelCarros> AlguelCarros { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        var id1 = "d09a4d10-86b5-403c-8d17-749f4fd31c74";
        var id2 = "effc421b-4c95-474a-be11-a6bb78b583a5";
        var id3 = "f70cedfc-073a-417b-8187-d5253eb725cf";

        builder.Entity<Categoria>().HasData(
            new Categoria()
            {
                Id = Guid.Parse(id1),
                Descricao = "Basico"
            },

            new Categoria()
            {
                Id = Guid.Parse(id2),
                Descricao = "Familia"
            },

            new Categoria()
            {
                Id = Guid.Parse(id3),
                Descricao = "Carga"
            }
        );

        var role = new IdentityRole()
        {
            Name = "Admin",
            NormalizedName = "Admin",
            Id = "1",
            ConcurrencyStamp = "1"
        };

        builder.Entity<IdentityRole>().HasData(role);


        var adminUser = new AplicacaoUser
        {
            UserName = "admin@gmail.com",
            Email = "admin@gmail.com",
            CNH = "000000000000",
            CPF = "00000000000",
            Sexo = "Masculino" ?? "Desconhecido",
            Telefone = "0000000000",
            DataNascimento = "2000-01-01",
            PhoneNumber = "0000000000",
            Nome = "admin@gmail.com"
        };

        adminUser.PasswordHash = new PasswordHasher<AplicacaoUser>().HashPassword(adminUser, "Ab123.");

        builder.Entity<AplicacaoUser>().HasData(adminUser);

        var superAdminRole = new IdentityUserRole<string>()
        {
            RoleId = "1",
            UserId = adminUser.Id
        };

        builder.Entity<IdentityUserRole<string>>().HasData(superAdminRole);
    }

}

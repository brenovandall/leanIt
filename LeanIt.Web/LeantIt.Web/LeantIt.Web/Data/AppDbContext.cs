using LeantIt.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace LeantIt.Web.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<CarroModel> Carros { get; set; }

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

    }

}

using LeantIt.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace LeantIt.Web.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<CarroModel> Carros { get; set; }
}

using Brain.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Brain.InfraEstrutura.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Item> Itens { get; set; }

   
}

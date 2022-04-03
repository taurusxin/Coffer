using CofferBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace CofferBackend;

public class DbService : DbContext
{
    public DbSet<NewCoffee>? NewCoffees { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL(DbConfig.GetConnString());
    }
}
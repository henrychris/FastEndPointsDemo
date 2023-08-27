using FastEndPointsDemo.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FastEndPointsDemo.Data;

public class DataContext : DbContext
{
    private readonly IConfiguration _configuration;

    public DataContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = _configuration.GetConnectionString("DefaultConnection");
        optionsBuilder.UseSqlite(connectionString);
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Business> Businesses { get; set; }
}
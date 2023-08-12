using Microsoft.EntityFrameworkCore;
using ShopGame.DAL.Configuration.ContextConfiguration;
using ShopGame.DAL.Configuration.ModelConfiguration;
using ShopGame.DAL.Models;

namespace ShopGame.DAL.Context;

public class ApplicationContext:DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        :base(options)
    {
        
    }
    
    public ApplicationContext()
    {
        
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        if (!optionsBuilder.IsConfigured)
        {

            optionsBuilder.UseMySql(Connector.ConnectString(),
                ServerVersion.AutoDetect(Connector.ConnectString()));

        }
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        if (Database.IsRelational())
        {

            modelBuilder.ApplyConfiguration(new GameConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new GenreConfiguration());
        }
        
        
       
    }

    public DbSet<Game> Games { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<Genre> Genres { get; set; } = null!;
}
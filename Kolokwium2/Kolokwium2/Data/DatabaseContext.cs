using Kolokwium2.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium2.Data;

public class DatabaseContext : DbContext
{
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<backpacks> Backpacks { get; set; }
    public DbSet<characters> Characters { get; set; }
    public DbSet<charactertitles> CharacterTitles { get; set; }
    public DbSet<items> Items { get; set; }
    public DbSet<titles> Titles { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<characters>().HasData(new List<characters>
            {
                new characters {
                    Id = 1,
                    FirstName = "Jan",
                    LastName = "Kowalski",
                    CurrentWeight = 10,
                    MaxWeight = 15
                },
            });

            modelBuilder.Entity<items>().HasData(new List<items>
            {
                new items {
                    Id = 1,
                    Name = "Przedmiot",
                    Weight = 1
                }
            });

            modelBuilder.Entity<titles>().HasData(new List<titles>
            {
                new titles
                {
                    Id = 1,
                    Name = "Tytul"
                }
            });

            modelBuilder.Entity<charactertitles>().HasData(new List<charactertitles>
            {
                new charactertitles
                {
                    CharacterId = 1,
                    TitleId = 1,
                    AcquiredAt = DateTime.Now
                }
            });

            modelBuilder.Entity<backpacks>().HasData(new List<backpacks>
            {
                new backpacks
                {
                    CharacterId = 1,
                    ItemId = 1,
                    Amount = 3
                }
            });
    }

}
using Kolokwium.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium.Context
{
    public class DatabaseContext : DbContext
    {
        protected DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Backpack> Backpacks { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<CharacterTitles> CharacterTitles { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Title> Titles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Character>().HasData(new List<Character>
            {
                new Character { Id = 1, FirstName = "John", LastName = "Doe", CurrentWeight = 50, MaxWeight = 100 },
                new Character { Id = 2, FirstName = "Jane", LastName = "Smith", CurrentWeight = 70, MaxWeight = 120 }
            });

            modelBuilder.Entity<Item>().HasData(new List<Item>
            {
                new Item { Id = 1, Name = "Sword", Weight = 10 },
                new Item { Id = 2, Name = "Shield", Weight = 15 }
            });

            modelBuilder.Entity<Title>().HasData(new List<Title>
            {
                new Title { Id = 1, Name = "Warrior" },
                new Title { Id = 2, Name = "Mage" }
            });

            modelBuilder.Entity<Backpack>().HasData(new List<Backpack>
            {
                new Backpack { CharacterId = 1, ItemId = 1, Amount = 1 },
                new Backpack { CharacterId = 2, ItemId = 2, Amount = 2 }
            });

            modelBuilder.Entity<CharacterTitles>().HasData(new List<CharacterTitles>
            {
                new CharacterTitles { CharacterId = 1, TitleId = 1, AcquiredAt = new DateTime(2023, 1, 1) },
                new CharacterTitles { CharacterId = 2, TitleId = 2, AcquiredAt = new DateTime(2023, 1, 2) }
            });
        }
    }
}

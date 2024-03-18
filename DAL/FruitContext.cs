using FruitIMSite.Models;
using Microsoft.EntityFrameworkCore;

namespace IMFruitSite.DAL
{
    public class FruitContext : DbContext
    {
        // Not a best practice here
        private string _connectionString;
        public FruitContext()
        {
            IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public DbSet<Fruit> Fruits { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<FruitType> FruitTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .UseSqlServer(_connectionString);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region ColorSeed
            modelBuilder.Entity<Color>().HasData(
                new Color { ColorId = 1, Name = "Brown" },
                new Color { ColorId = 2, Name = "Green" },
                new Color { ColorId = 3, Name = "Red" },
                new Color { ColorId = 4, Name = "Yellow" }
                );
            #endregion
            

            #region FruitTypeSeed
            modelBuilder.Entity<FruitType>().HasData(
                new FruitType { FruitTypeId = 1, FruitName = "Apple" },
                new FruitType { FruitTypeId = 2, FruitName = "Banana" },
                new FruitType { FruitTypeId = 3, FruitName = "Cherry" },
                new FruitType { FruitTypeId = 4, FruitName = "Coconut" },
                new FruitType { FruitTypeId = 5, FruitName = "Kiwi" },
                new FruitType { FruitTypeId = 6, FruitName = "Strawberry" }
                );
            #endregion

            #region FruitSeeding
            modelBuilder.Entity<Fruit>()
                .HasData(
                //  Coconut
                new Fruit { FruitId = 1, Weight = 2.2, ColorId = 1, Price = .99, DatePicked = new DateTime(2024, 3, 1), HasSeeds = false, FruitTypeId = 4 },
                new Fruit { FruitId = 2, Weight = 2.0, ColorId = 1, Price = .98, DatePicked = new DateTime(2024, 2, 1), HasSeeds = false, FruitTypeId = 4 },
                // Strawberry
                new Fruit { FruitId = 3, Weight = 1.0, ColorId = 3, Price = 1.99, DatePicked = new DateTime(2024, 3, 10), HasSeeds = false, FruitTypeId = 6 },
                new Fruit { FruitId = 4, Weight = 1.5, ColorId = 3, Price = 2.50, DatePicked = new DateTime(2024, 3, 11), HasSeeds = false, FruitTypeId = 6 },
                // Apple
                new Fruit { FruitId = 5, Weight = .25, ColorId = 2, Price = .50, DatePicked = new DateTime(2024, 3, 10), HasSeeds = true, FruitTypeId = 1 },
                new Fruit { FruitId = 6, Weight = .75, ColorId = 2, Price = 1.50, DatePicked = new DateTime(2024, 3, 11), HasSeeds = true, FruitTypeId = 1 },
                // Kiwi
                new Fruit { FruitId = 7, Weight = 1.0, ColorId = 1, Price = 1.00, DatePicked = new DateTime(2024, 3, 1), HasSeeds = true, FruitTypeId = 5 },
                new Fruit { FruitId = 8, Weight = 1.25, ColorId = 1, Price = 1.25, DatePicked = new DateTime(2024, 3, 2), HasSeeds = true, FruitTypeId = 5 },
                // Cherry
                new Fruit { FruitId = 9, Weight = 1.0, ColorId = 3, Price = 1.60, DatePicked = new DateTime(2024, 3, 3), HasSeeds = true, FruitTypeId = 3 },
                new Fruit { FruitId = 10, Weight = 1.50, ColorId = 3, Price = 1.90, DatePicked = new DateTime(2024, 3, 4), HasSeeds = true, FruitTypeId = 3 },
                // Banana
                new Fruit { FruitId = 11, Weight = .25, ColorId = 4, Price = 1.00, DatePicked = new DateTime(2024, 3, 5), HasSeeds = false, FruitTypeId = 2 },
                new Fruit { FruitId = 12, Weight = .50, ColorId = 4, Price = 2.00, DatePicked = new DateTime(2024, 3, 6), HasSeeds = false, FruitTypeId = 2 }
                );

            #endregion

        }
    }
}

using FoodBotGqlApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodBotGqlApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Food> Foods { get; set; }
        public DbSet<Preparation> Preparations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Food>()
                .HasMany(p => p.Preparations)
                .WithOne(p => p.Food!)
                .HasForeignKey(p => p.FoodId);

            modelBuilder
                .Entity<Preparation>()
                .HasOne(p => p.Food)
                .WithMany(p => p.Preparations)
                .HasForeignKey(p => p.FoodId);
        }
    }
}
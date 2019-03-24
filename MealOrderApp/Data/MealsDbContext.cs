using MealOrderApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealOrderApp.Data
{
    public class MealsDbContext : DbContext
    {
        public MealsDbContext(DbContextOptions<MealsDbContext> options) : base(options)
        {

        }

        public DbSet<RestaurantMealType> RestaurantMealTypes { get; set; }
        public DbSet<OrderedMealType> OrderedMealTypes { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Meal> Meals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderedMealType>(entity =>
            {
                entity.HasKey(e => e.OrderedMealTypeId);
                entity.HasOne(p => p.Meal)
                .WithMany(b => b.OrderedMealTypes)
                .HasForeignKey(p => p.MealId)
                .HasConstraintName("ForeignKey_OrderedMealType_Meal");
            });

            modelBuilder.Entity<RestaurantMealType>(entity =>
            {
                entity.HasKey(e => e.RestaurantMealTypeId);
                entity.HasOne(p => p.Restaurant)
                .WithMany(b => b.RestaurantMealTypes)
                .HasForeignKey(p => p.RestaurantId)
                .HasConstraintName("ForeignKey_RestaurantMealType_Restaurant");
            });
        }
    }
}

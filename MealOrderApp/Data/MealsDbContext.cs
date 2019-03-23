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

        public DbSet<MealType> MealTypes { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Meal> Meals { get; set; }
    }
}

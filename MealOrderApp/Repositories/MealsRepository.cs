using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MealOrderApp.Data;
using MealOrderApp.Models;
using Microsoft.EntityFrameworkCore;

namespace MealOrderApp.Repositories
{
    public class MealsRepository : IMealsRepository
    {
        private readonly MealsDbContext _context;

        public MealsRepository(MealsDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Meal> GetMeals()
        {
            return _context.Meals.Include(i => i.OrderedMealTypes).ToList();
        }

        public Meal GetMealById(int id)
        {
            return _context.Meals.Include(i => i.OrderedMealTypes).Where(t => t.MealId == id).FirstOrDefault();
        }

        public void UpdateMeal(Meal meal)
        {
            _context.Meals.UpdateRange(meal);
            _context.SaveChanges();
        }

        public void CreateMeal(Meal meal)
        {
            _context.Meals.Add(meal);
            _context.SaveChangesAsync();
        }

        public Meal GetMealByIdForDelete(int id)
        {
            return _context.Meals.Find(id);
        }

        public void DeleteMeal(Meal meal)
        {
            _context.Meals.RemoveRange(meal);
            _context.SaveChanges();
        }

        public bool FindMealExists(int id)
        {
            return _context.Meals.Any(e => e.MealId == id);
        }
    }
}

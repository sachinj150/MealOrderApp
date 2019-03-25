using MealOrderApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealOrderApp.Repositories
{
    public interface IMealsRepository
    {
        IEnumerable<Meal> GetMeals();
        Meal GetMealById(int id);
        void UpdateMeal(Meal meal);
        void CreateMeal(Meal meal);
        Meal GetMealByIdForDelete(int id);
        void DeleteMeal(Meal meal);
        bool FindMealExists(int id);
    }
}

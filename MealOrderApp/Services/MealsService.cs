using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MealOrderApp.Models;
using MealOrderApp.Repositories;

namespace MealOrderApp.Services
{
    public class MealsService : IMealsService
    {
        private readonly IMealsRepository _mealsRepository;

        public MealsService(IMealsRepository mealsRepository)
        {
            _mealsRepository = mealsRepository;
        }

        public IEnumerable<Meal> GetMeals()
        {
            return _mealsRepository.GetMeals();
        }

        public IEnumerable<Meal> GetMealById(int id)
        {
            return _mealsRepository.GetMealById(id);
        }

        public void UpdateMeal(Meal meal)
        {
            _mealsRepository.UpdateMeal(meal);
        }

        public void CreateMeal(Meal meal)
        {
            _mealsRepository.CreateMeal(meal);
        }

        public Meal GetMealByIdForDelete(int id)
        {
            return _mealsRepository.GetMealByIdForDelete(id);
        }

        public void DeleteMeal(Meal meal)
        {
            _mealsRepository.DeleteMeal(meal);
        }

        public bool FindMealExists(int id)
        {
            return _mealsRepository.FindMealExists(id);
        }
    }
}

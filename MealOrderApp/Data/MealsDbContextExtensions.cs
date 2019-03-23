using MealOrderApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealOrderApp.Data
{
    public static class MealsDbContextExtensions
    {
        public static void EnsureSeedDataForContext(this MealsDbContext context)
        {
            context.Meals.RemoveRange(context.Meals);
            context.SaveChanges();

            //seed data
            var meals = new List<Meal>()
            {
                new Meal()
                {
                    NumberOfMeals = 50,
                    SpecialityMeals = new List<MealType>()
                    {
                        new MealType()
                        {
                            MealName = "FishFree"
                        },
                        new MealType()
                        {
                            MealName = "NutFree"
                        }
                    }
                }
            };

            //seed data
            var restauants = new List<Restaurant>()
            {
                new Restaurant()
                {
                    RestaurantName = "Sunterra",
                    Rating = 4.8M,
                    Capacity = 100,

                }
            };

            context.Meals.AddRange(meals);
            context.SaveChanges();
        }
    }
}

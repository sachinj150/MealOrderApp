using MealOrderApp.Enums;
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
                    SpecialityMeals = new List<OrderedMealType>()
                    {
                        new OrderedMealType()
                        {
                            MealType = MealType.FishFree,
                            NumberOfMeals = 10
                        },
                        new OrderedMealType()
                        {
                            MealType = MealType.Vegetarian,
                            NumberOfMeals = 20
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
                    AvailableMealTypes = new List<RestaurantMealType>()
                    {
                        new RestaurantMealType()
                        {
                            MealType = MealType.FishFree,
                            Capacity = 20
                        },
                        new RestaurantMealType()
                        {
                            MealType = MealType.Vegetarian,
                            Capacity = 30
                        }
                    },
                    Capacity = 100
                }
            };

            context.Meals.AddRange(meals);
            context.SaveChanges();

            context.Restaurants.AddRange(restauants);
            context.SaveChanges();
        }
    }
}

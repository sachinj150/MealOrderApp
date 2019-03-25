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
            context.Restaurants.RemoveRange(context.Restaurants);
            context.SaveChanges();

            //seed data
            var meals = new List<Meal>()
            {
                new Meal()
                {
                    NumberOfMeals = 50,
                    OrderedMealTypes = new List<OrderedMealType>()
                    {
                        new OrderedMealType()
                        {
                            MealType = nameof(MealType.FishFree),
                            NumberOfMeals = 10
                        },
                        new OrderedMealType()
                        {
                            MealType = nameof(MealType.Vegetarian),
                            NumberOfMeals = 20
                        }
                    }
                }
            };

            //seed data
            var restaurants = new List<Restaurant>()
            {
                new Restaurant()
                {
                    RestaurantName = "Sunterra",
                    Rating = 4.8M,
                    RestaurantMealTypes = new List<RestaurantMealType>()
                    {
                        new RestaurantMealType()
                        {
                            MealType = nameof(MealType.FishFree),
                            Capacity = 20
                        },
                        new RestaurantMealType()
                        {
                            MealType = nameof(MealType.Vegetarian),
                            Capacity = 30
                        }
                    },
                    Capacity = 100
                }
            };

            context.Meals.AddRange(meals);
            context.SaveChanges();

            context.Restaurants.AddRange(restaurants);
            context.SaveChanges();
        }
    }
}

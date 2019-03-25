using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MealOrderApp.DTOs;
using MealOrderApp.Enums;
using MealOrderApp.Models;
using MealOrderApp.Repositories;

namespace MealOrderApp.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IRestaurantsRepository _restaurantsRepository;
        private readonly IMealsRepository _mealsRepository;

        public OrdersService(IRestaurantsRepository restaurantsRepository, IMealsRepository mealsRepository)
        {
            _restaurantsRepository = restaurantsRepository;
            _mealsRepository = mealsRepository;
        }

        public MealResponseDTO GetOrder(int id)
        {
            var mealRequest = _mealsRepository.GetMealById(id);
            var restaurants = _restaurantsRepository.GetRestaurants();
            return ProcessMealOrder(mealRequest, restaurants);
        }

        public MealResponseDTO ProcessMealOrder(Meal mealRequest, IEnumerable<Restaurant> restaurants)
        {
            
            var mealCount = mealRequest.NumberOfMeals;
            var specialMealCount = 0;

            foreach (var specialMeal in mealRequest.OrderedMealTypes)
            {
                specialMealCount += specialMeal.NumberOfMeals;
            }

            var regularMealCount = mealCount - specialMealCount;

            MealResponseDTO mealOrder = new MealResponseDTO();

            foreach (var restaurant in restaurants.OrderByDescending(o => o.Rating))
            {
                if (mealRequest.NumberOfMeals > 0)
                {
                    foreach (var specialityMeal in mealRequest.OrderedMealTypes)
                    {
                        foreach (var restaurantSpecialityMeal in restaurant.RestaurantMealTypes)
                        {
                            SpecialityMealResponseDTO specialityMealOrder = new SpecialityMealResponseDTO();

                            if (specialityMeal.MealType == restaurantSpecialityMeal.MealType)
                            {
                                if (specialityMeal.NumberOfMeals <= restaurantSpecialityMeal.Capacity && specialityMeal.NumberOfMeals != 0)
                                {
                                    specialityMealOrder.NumberOfMealsAvailable = specialityMeal.NumberOfMeals;
                                    specialityMealOrder.MealType = specialityMeal.MealType;
                                    specialityMealOrder.RestaurantName = restaurant.RestaurantName;

                                    mealOrder.SpecialityMealsAvailable.Add(specialityMealOrder);

                                    mealOrder.TotalNumberOfMealsAvailable += specialityMeal.NumberOfMeals;
                                    mealRequest.NumberOfMeals -= specialityMeal.NumberOfMeals;
                                    restaurant.Capacity -= specialityMeal.NumberOfMeals;
                                    specialityMeal.NumberOfMeals = 0;
                                }
                                else if (specialityMeal.NumberOfMeals > restaurantSpecialityMeal.Capacity && restaurantSpecialityMeal.Capacity != 0)
                                {
                                    specialityMealOrder.NumberOfMealsAvailable = restaurantSpecialityMeal.Capacity;
                                    specialityMealOrder.MealType = specialityMeal.MealType;
                                    specialityMealOrder.RestaurantName = restaurant.RestaurantName;

                                    mealOrder.SpecialityMealsAvailable.Add(specialityMealOrder);

                                    mealOrder.TotalNumberOfMealsAvailable += restaurantSpecialityMeal.Capacity;
                                    mealRequest.NumberOfMeals -= restaurantSpecialityMeal.Capacity;
                                    specialityMeal.NumberOfMeals -= restaurantSpecialityMeal.Capacity;
                                    restaurant.Capacity -= restaurantSpecialityMeal.Capacity;

                                }
                            }
                        }
                    }

                    if (restaurant.Capacity > 0 && regularMealCount > 0)
                    {
                        if (restaurant.Capacity >= regularMealCount)
                        {
                            mealOrder.RegularMeals.Add(restaurant.RestaurantName, regularMealCount);
                            mealOrder.TotalNumberOfMealsAvailable += regularMealCount;
                            mealRequest.NumberOfMeals -= regularMealCount;
                            restaurant.Capacity -= regularMealCount;
                            regularMealCount = 0;
                        }
                        else
                        {
                            mealOrder.RegularMeals.Add(restaurant.RestaurantName, restaurant.Capacity);
                            mealOrder.TotalNumberOfMealsAvailable += restaurant.Capacity;
                            mealRequest.NumberOfMeals -= restaurant.Capacity;
                            regularMealCount -= restaurant.Capacity;
                            restaurant.Capacity = 0;
                        }
                    }

                    if (mealRequest.NumberOfMeals > 0)
                    {
                        mealOrder.Status = nameof(MealStatus.InsufficientFood);
                    }
                    else
                    {
                        mealOrder.Status = nameof(MealStatus.Confirmed);
                    }
                }
                else
                {
                    mealOrder.Status = nameof(MealStatus.Confirmed);
                }
            }
            return mealOrder;
        }
    }
}

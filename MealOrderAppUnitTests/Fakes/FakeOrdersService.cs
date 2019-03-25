using MealOrderApp.DTOs;
using MealOrderApp.Models;
using MealOrderApp.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MealOrderAppUnitTests.Fakes
{
    public class FakeOrdersService : IOrdersService
    {
        public MealResponseDTO GetOrder(int id)
        {
            throw new NotImplementedException();
        }

        public MealResponseDTO ProcessMealOrder(Meal mealRequest, IEnumerable<Restaurant> restaurants)
        {
            throw new NotImplementedException();
        }
    }
}

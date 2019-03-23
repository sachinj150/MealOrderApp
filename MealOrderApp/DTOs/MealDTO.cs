using MealOrderApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealOrderApp.DTOs
{
    public class MealDTO
    {
        public int NumberOfMeals { get; set; }
        public List<RestaurantMealType> SpecialityMeals { get; set; }
        public string RestaurantName { get; set; }
    }
}

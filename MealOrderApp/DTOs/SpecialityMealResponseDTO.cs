using MealOrderApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealOrderApp.DTOs
{
    public class SpecialityMealResponseDTO
    {
        public MealType MealType { get; set; }
        public int NumberOfMealsAvailable { get; set; }
        public string RestaurantName { get; set; }
    }
}

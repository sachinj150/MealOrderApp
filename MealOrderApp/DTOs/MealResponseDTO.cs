using MealOrderApp.Enums;
using MealOrderApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealOrderApp.DTOs
{
    public class MealResponseDTO
    {
        public int TotalNumberOfMealsAvailable { get; set; }
        public MealStatus Status { get; set; }
        public List<String> RestaurantNames { get; set; }
        public List<SpecialityMealResponseDTO> SpecialityMealsAvailable { get; set; }
    }
}

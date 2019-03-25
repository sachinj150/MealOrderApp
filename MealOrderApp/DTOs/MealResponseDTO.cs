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
        public MealResponseDTO()
        {
            SpecialityMealsAvailable = new List<SpecialityMealResponseDTO>();
            RegularMeals = new Dictionary<string, int>();
        }
        public int TotalNumberOfMealsAvailable { get; set; }
        public string Status { get; set; }
        public Dictionary<string, int> RegularMeals { get; set; }
        public List<SpecialityMealResponseDTO> SpecialityMealsAvailable { get; set; }
    }
}

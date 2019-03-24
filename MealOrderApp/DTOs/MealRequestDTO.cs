using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealOrderApp.DTOs
{
    public class MealRequestDTO
    {
        public int TotalNumberOfMeals { get; set; }
        public List<SpecialityMealRequestDTO> SpecialityMealRequests { get; set; }
    }
}

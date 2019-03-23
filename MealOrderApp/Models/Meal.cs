using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MealOrderApp.Models
{
    public class Meal
    {
        [Key]
        public int MealId { get; set; }
        public int NumberOfMeals { get; set; }
        public List<MealType> SpecialityMeals { get; set; }
    }
}

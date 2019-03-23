using MealOrderApp.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MealOrderApp.Models
{
    public class OrderedMealType
    {
        [Key]
        public int OrderedMealTypeId { get; set; }
        public MealType MealType { get; set; }
        public int NumberOfMeals { get; set; }
    }
}

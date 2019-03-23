using MealOrderApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealOrderApp.Models
{
    public class Restaurant
    {
        public string restaurantName { get; set; }
        public decimal rating { get; set; }
        public List<MealType> mealTypes { get; set; }
        public int capacity { get; set; }

    }
}

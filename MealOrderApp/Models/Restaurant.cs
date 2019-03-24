using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MealOrderApp.Models
{
    public class Restaurant
    {
        public Restaurant()
        {
            RestaurantMealTypes = new HashSet<RestaurantMealType>();
        }

        [Key]
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public decimal Rating { get; set; }
        public int Capacity { get; set; }

        public ICollection<RestaurantMealType> RestaurantMealTypes { get; set; }
    }
}

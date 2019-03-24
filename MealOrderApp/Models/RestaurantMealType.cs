using MealOrderApp.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MealOrderApp.Models
{
    public class RestaurantMealType
    {
        [Key]
        public int RestaurantMealTypeId { get; set; }
        public MealType MealType { get; set; }
        public int Capacity { get; set; }
        [ForeignKey("Restaurant")]
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MealOrderApp.Models
{
    public class MealType
    {
        [Key]
        public int MealTypeId { get; set; }
        public string MealName { get; set; }
    }
}

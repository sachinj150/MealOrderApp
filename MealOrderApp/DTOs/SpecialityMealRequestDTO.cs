﻿using MealOrderApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealOrderApp.DTOs
{
    public class SpecialityMealRequestDTO
    {
        public MealType MealType { get; set; }
        public int NumberOfMealsRequested { get; set; }
    }
}
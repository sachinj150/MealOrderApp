using MealOrderApp.DTOs;
using MealOrderApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealOrderApp.Services
{
    public interface IOrdersService
    {
        MealResponseDTO GetOrder(int id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MealOrderApp.Data;
using MealOrderApp.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MealOrderApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly MealsDbContext _context;

        public OrdersController(MealsDbContext context)
        {
            _context = context;
        }

        // GET: api/Orders
        [HttpPost]
        public IActionResult GetMeal([FromBody] MealRequestDTO mealRequests)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var restaurants = _context.Restaurants.Include(i => i.RestaurantMealTypes).ToList().OrderByDescending(o => o.Rating);
            return Ok(restaurants);

            //foreach (var restaurant in restaurants)
            //{
            //    if (restaurant.RestaurantMealTypes.)
            //}
        }
    }
}

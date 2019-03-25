using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MealOrderApp.Data;
using MealOrderApp.Models;
using MealOrderApp.Services;

namespace MealOrderApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly IRestaurantsService _restaurantsService;

        public RestaurantsController(IRestaurantsService restaurantsService)
        {
            _restaurantsService = restaurantsService;
        }

        // GET: api/Restaurants
        /// <summary>
        /// Get list of restaurants with meal availability
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Restaurant> GetRestaurants()
        {
            return _restaurantsService.GetRestaurants();
        }

        // GET: api/Restaurants/5
        /// <summary>
        /// Get Restaurant based on a id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetRestaurant([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var restaurant = _restaurantsService.GetRestaurantById(id);

            if (restaurant == null)
            {
                return NotFound();
            }

            return Ok(restaurant);
        }

        // PUT: api/Restaurants/5
        /// <summary>
        /// Update restaurant
        /// </summary>
        /// <param name="id"></param>
        /// <param name="restaurant"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult PutRestaurant([FromRoute] int id, [FromBody] Restaurant restaurant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != restaurant.RestaurantId)
            {
                return BadRequest();
            }

            try
            {
                _restaurantsService.UpdateRestaurant(restaurant);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Restaurants
        /// <summary>
        /// Add a new restaurant
        /// </summary>
        /// <param name="restaurant"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult PostRestaurant([FromBody] Restaurant restaurant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _restaurantsService.CreateRestaurant(restaurant);

            return CreatedAtAction("GetRestaurant", new { id = restaurant.RestaurantId }, restaurant);
        }

        // DELETE: api/Restaurants/5
        /// <summary>
        /// Delete a restaurant
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteRestaurant([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var restaurant = _restaurantsService.GetRestaurantByIdForDelete(id);
            if (restaurant == null)
            {
                return NotFound();
            }

            _restaurantsService.DeleteRestaurant(restaurant);

            return Ok(restaurant);
        }

        /// <summary>
        /// Check if a restaurant exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool RestaurantExists(int id)
        {
            return _restaurantsService.FindRestaurantExists(id);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MealOrderApp.Data;
using MealOrderApp.Models;
using Newtonsoft.Json;
using MealOrderApp.Services;

namespace MealOrderApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealsController : ControllerBase
    {
        private readonly IMealsService _mealsService;

        public MealsController(IMealsService mealsService)
        {
            _mealsService = mealsService;
        }

        // GET: api/Meals
        /// <summary>
        /// Get list of ordered meals
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Meal> GetMeals()
        {
            return _mealsService.GetMeals();
        }

        // GET: api/Meals/5
        /// <summary>
        /// Get ordered meal by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetMeal([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var meal = _mealsService.GetMealById(id);

            if (meal == null)
            {
                return NotFound();
            }

            return Ok(meal);
        }

        // PUT: api/Meals/5
        /// <summary>
        /// Update ordered meal
        /// </summary>
        /// <param name="id"></param>
        /// <param name="meal"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult PutMeal([FromRoute] int id, [FromBody] Meal meal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != meal.MealId)
            {
                return BadRequest();
            }

            try
            {
                _mealsService.UpdateMeal(meal);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MealExists(id))
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

        // POST: api/Meals
        /// <summary>
        /// Insert new meal
        /// </summary>
        /// <param name="meal"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult PostMeal([FromBody] Meal meal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _mealsService.CreateMeal(meal);

            return CreatedAtAction("GetMeal", new { id = meal.MealId }, meal);
        }

        // DELETE: api/Meals/5
        /// <summary>
        /// Delete meal
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteMeal([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var meal = _mealsService.GetMealByIdForDelete(id);
            if (meal == null)
            {
                return NotFound();
            }

            _mealsService.DeleteMeal(meal);

            return Ok(meal);
        }

        /// <summary>
        /// Check if meal exists based on the meal id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool MealExists(int id)
        {
            return _mealsService.FindMealExists(id);
        }
    }
}
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
        [HttpGet]
        public IEnumerable<Meal> GetMeals()
        {
            return _mealsService.GetMeals();
        }

        // GET: api/Meals/5
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

        private bool MealExists(int id)
        {
            return _mealsService.FindMealExists(id);
        }
    }
}
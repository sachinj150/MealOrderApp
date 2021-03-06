﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MealOrderApp.Data;
using MealOrderApp.DTOs;
using MealOrderApp.Models;
using MealOrderApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MealOrderApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        // GET: api/Orders/5
        /// <summary>
        /// Get Order details for a meal requirement
        /// </summary>
        /// <param name="mealid"></param>
        /// <returns></returns>
        [HttpGet("{mealid}")]
        public IActionResult GetMeal([FromRoute] int mealid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mealOrder = _ordersService.GetOrder(mealid);
            return Ok(mealOrder);
        }
    }
}

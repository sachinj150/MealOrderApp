using MealOrderApp.Data;
using MealOrderApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealOrderApp.Repositories
{
    public class RestaurantsRepository : IRestaurantsRepository
    {
        private readonly MealsDbContext _context;

        public RestaurantsRepository(MealsDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Restaurant> GetRestaurants()
        {
            return _context.Restaurants.Include(i => i.RestaurantMealTypes).ToList();
        }

        public IEnumerable<Restaurant> GetRestaurantById(int id)
        {
            return _context.Restaurants.Include(i => i.RestaurantMealTypes).Where(t => t.RestaurantId == id);
        }

        public void UpdateRestaurant(Restaurant restaurant)
        {
            _context.Restaurants.UpdateRange(restaurant);
            _context.SaveChanges();
        }

        public void CreateRestaurant(Restaurant restaurant)
        {
            _context.Restaurants.Add(restaurant);
            _context.SaveChangesAsync();
        }

        public Restaurant GetRestaurantByIdForDelete(int id)
        {
            return _context.Restaurants.Find(id);
        }

        public void DeleteRestaurant(Restaurant restaurant)
        {
            _context.Restaurants.RemoveRange(restaurant);
            _context.SaveChanges();
        }

        public bool FindRestaurantExists(int id)
        {
            return _context.Restaurants.Any(e => e.RestaurantId == id);
        }
    }
}

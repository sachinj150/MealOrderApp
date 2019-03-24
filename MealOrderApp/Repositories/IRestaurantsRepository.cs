using MealOrderApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealOrderApp.Repositories
{
    public interface IRestaurantsRepository
    {
        IEnumerable<Restaurant> GetRestaurants();
        IEnumerable<Restaurant> GetRestaurantById(int id);
        void UpdateRestaurant(Restaurant restaurant);
        void CreateRestaurant(Restaurant restaurant);
        Restaurant GetRestaurantByIdForDelete(int id);
        void DeleteRestaurant(Restaurant restaurant);
        bool FindRestaurantExists(int id);
    }
}

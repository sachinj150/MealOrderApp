using MealOrderApp.Models;
using MealOrderApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealOrderApp.Services
{
    public class RestaurantsService : IRestaurantsService
    {
        private readonly IRestaurantsRepository _restaurantsRepository;

        public RestaurantsService(IRestaurantsRepository restaurantsRepository)
        {
            _restaurantsRepository = restaurantsRepository;
        }

        public IEnumerable<Restaurant> GetRestaurants()
        {
            return _restaurantsRepository.GetRestaurants();
        }

        public IEnumerable<Restaurant> GetRestaurantById(int id)
        {
            return _restaurantsRepository.GetRestaurantById(id);
        }

        public void UpdateRestaurant(Restaurant restaurant)
        {
            _restaurantsRepository.UpdateRestaurant(restaurant);
        }

        public void CreateRestaurant(Restaurant restaurant)
        {
            _restaurantsRepository.CreateRestaurant(restaurant);
        }

        public Restaurant GetRestaurantByIdForDelete(int id)
        {
            return _restaurantsRepository.GetRestaurantByIdForDelete(id);
        }

        public void DeleteRestaurant(Restaurant restaurant)
        {
            _restaurantsRepository.DeleteRestaurant(restaurant);
        }

        public bool FindRestaurantExists(int id)
        {
            return _restaurantsRepository.FindRestaurantExists(id);
        }
    }
}

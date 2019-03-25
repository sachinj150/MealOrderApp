using MealOrderApp.DTOs;
using MealOrderApp.Enums;
using MealOrderApp.Models;
using MealOrderApp.Repositories;
using MealOrderApp.Services;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace MealOrderAppUnitTests
{
    public class MealOrderUnitTests
    {
        private readonly Mock<IRestaurantsRepository> mockRestaurantsRepository = new Mock<IRestaurantsRepository>();
        private readonly Mock<IMealsRepository> mockMealsRepository = new Mock<IMealsRepository>();

        [Theory]
        [InlineData("Confirmed")]
        public void Sufficient_Food_Available_At_A_Single_Restaurant_Including_Speciality_Meals(string expected)
        {
            var meal = new Meal()
            {
                NumberOfMeals = 50,
                OrderedMealTypes = new List<OrderedMealType>()
                    {
                        new OrderedMealType()
                        {
                            MealType = MealType.FishFree,
                            NumberOfMeals = 10
                        },
                        new OrderedMealType()
                        {
                            MealType = MealType.Vegetarian,
                            NumberOfMeals = 20
                        }
                    }
            };

            var restaurants = new List<Restaurant>()
            {
                new Restaurant()
                {
                    RestaurantName = "Sunterra",
                    Rating = 4.8M,
                    RestaurantMealTypes = new List<RestaurantMealType>()
                    {
                        new RestaurantMealType()
                        {
                            MealType = MealType.FishFree,
                            Capacity = 20
                        },
                        new RestaurantMealType()
                        {
                            MealType = MealType.Vegetarian,
                            Capacity = 30
                        }
                    },
                    Capacity = 100
                }
            };

            mockRestaurantsRepository.Setup(x => x.GetRestaurants()).Returns(restaurants);
            mockMealsRepository.Setup(x => x.GetMealById(1)).Returns(meal);
            OrdersService ordersService = new OrdersService(mockRestaurantsRepository.Object, mockMealsRepository.Object);

            var mealOrder = ordersService.ProcessMealOrder(meal, restaurants);
            Assert.Equal(mealOrder.Status, expected);
        }

        [Theory]
        [InlineData("InsufficientFood")]
        public void In_Sufficient_Food_Available_At_A_Single_Restaurant_Including_Speciality_Meals(string expected)
        {
            var meal = new Meal()
            {
                NumberOfMeals = 50,
                OrderedMealTypes = new List<OrderedMealType>()
                    {
                        new OrderedMealType()
                        {
                            MealType = MealType.FishFree,
                            NumberOfMeals = 10
                        },
                        new OrderedMealType()
                        {
                            MealType = MealType.Vegetarian,
                            NumberOfMeals = 20
                        }
                    }
            };

            var restaurants = new List<Restaurant>()
            {
                new Restaurant()
                {
                    RestaurantName = "Sunterra",
                    Rating = 4.8M,
                    RestaurantMealTypes = new List<RestaurantMealType>()
                    {
                        new RestaurantMealType()
                        {
                            MealType = MealType.FishFree,
                            Capacity = 20
                        },
                        new RestaurantMealType()
                        {
                            MealType = MealType.GlutenFree,
                            Capacity = 30
                        }
                    },
                    Capacity = 100
                }
            };

            mockRestaurantsRepository.Setup(x => x.GetRestaurants()).Returns(restaurants);
            mockMealsRepository.Setup(x => x.GetMealById(1)).Returns(meal);
            OrdersService ordersService = new OrdersService(mockRestaurantsRepository.Object, mockMealsRepository.Object);

            var mealOrder = ordersService.ProcessMealOrder(meal, restaurants);
            Assert.Equal(mealOrder.Status, expected);
        }

        [Theory]
        [InlineData("Confirmed")]
        public void Sufficient_Food_Available_At_Multiple_Restaurants_Including_Speciality_Meals(string expected)
        {
            var meal = new Meal()
            {
                NumberOfMeals = 50,
                OrderedMealTypes = new List<OrderedMealType>()
                    {
                        new OrderedMealType()
                        {
                            MealType = MealType.FishFree,
                            NumberOfMeals = 10
                        },
                        new OrderedMealType()
                        {
                            MealType = MealType.GlutenFree,
                            NumberOfMeals = 20
                        }
                    }
            };

            var restaurants = new List<Restaurant>()
            {
                new Restaurant()
                {
                    RestaurantName = "Sunterra",
                    Rating = 4.8M,
                    RestaurantMealTypes = new List<RestaurantMealType>()
                    {
                        new RestaurantMealType()
                        {
                            MealType = MealType.FishFree,
                            Capacity = 20
                        },
                        new RestaurantMealType()
                        {
                            MealType = MealType.Vegetarian,
                            Capacity = 30
                        }
                    },
                    Capacity = 100
                },
                new Restaurant()
                {
                    RestaurantName = "Marcello's",
                    Rating = 4.2M,
                    RestaurantMealTypes = new List<RestaurantMealType>()
                    {
                        new RestaurantMealType()
                        {
                            MealType = MealType.GlutenFree,
                            Capacity = 20
                        },
                        new RestaurantMealType()
                        {
                            MealType = MealType.NutFree,
                            Capacity = 30
                        }
                    },
                    Capacity = 100
                }
            };

            mockRestaurantsRepository.Setup(x => x.GetRestaurants()).Returns(restaurants);
            mockMealsRepository.Setup(x => x.GetMealById(1)).Returns(meal);
            OrdersService ordersService = new OrdersService(mockRestaurantsRepository.Object, mockMealsRepository.Object);

            var mealOrder = ordersService.ProcessMealOrder(meal, restaurants);
            Assert.Equal(mealOrder.Status, expected);
        }

        [Theory]
        [InlineData("InsufficientFood")]
        public void In_Sufficient_Food_Available_At_Multiple_Restaurants_Including_Speciality_Meals(string expected)
        {
            var meal = new Meal()
            {
                NumberOfMeals = 50,
                OrderedMealTypes = new List<OrderedMealType>()
                    {
                        new OrderedMealType()
                        {
                            MealType = MealType.FishFree,
                            NumberOfMeals = 10
                        },
                        new OrderedMealType()
                        {
                            MealType = MealType.NutFree,
                            NumberOfMeals = 20
                        }
                    }
            };

            var restaurants = new List<Restaurant>()
            {
                new Restaurant()
                {
                    RestaurantName = "Sunterra",
                    Rating = 4.8M,
                    RestaurantMealTypes = new List<RestaurantMealType>()
                    {
                        new RestaurantMealType()
                        {
                            MealType = MealType.FishFree,
                            Capacity = 20
                        },
                        new RestaurantMealType()
                        {
                            MealType = MealType.Vegetarian,
                            Capacity = 30
                        }
                    },
                    Capacity = 100
                },
                new Restaurant()
                {
                    RestaurantName = "Marcello's",
                    Rating = 4.2M,
                    RestaurantMealTypes = new List<RestaurantMealType>()
                    {
                        new RestaurantMealType()
                        {
                            MealType = MealType.GlutenFree,
                            Capacity = 20
                        },
                        new RestaurantMealType()
                        {
                            MealType = MealType.NutFree,
                            Capacity = 5
                        }
                    },
                    Capacity = 100
                }
            };

            mockRestaurantsRepository.Setup(x => x.GetRestaurants()).Returns(restaurants);
            mockMealsRepository.Setup(x => x.GetMealById(1)).Returns(meal);
            OrdersService ordersService = new OrdersService(mockRestaurantsRepository.Object, mockMealsRepository.Object);

            var mealOrder = ordersService.ProcessMealOrder(meal, restaurants);
            Assert.Equal(mealOrder.Status, expected);
        }

        [Theory]
        [InlineData("Confirmed")]
        public void Sufficient_Food_Available_At_A_Single_Restaurants_With_Only_Regular_Meals(string expected)
        {
            var meal = new Meal()
            {
                NumberOfMeals = 50,
                OrderedMealTypes = new List<OrderedMealType>()
            };

            var restaurants = new List<Restaurant>()
            {
                new Restaurant()
                {
                    RestaurantName = "Sunterra",
                    Rating = 4.8M,
                    RestaurantMealTypes = new List<RestaurantMealType>()
                    {
                        new RestaurantMealType()
                        {
                            MealType = MealType.FishFree,
                            Capacity = 20
                        },
                        new RestaurantMealType()
                        {
                            MealType = MealType.Vegetarian,
                            Capacity = 30
                        }
                    },
                    Capacity = 100
                }
            };

            mockRestaurantsRepository.Setup(x => x.GetRestaurants()).Returns(restaurants);
            mockMealsRepository.Setup(x => x.GetMealById(1)).Returns(meal);
            OrdersService ordersService = new OrdersService(mockRestaurantsRepository.Object, mockMealsRepository.Object);

            var mealOrder = ordersService.ProcessMealOrder(meal, restaurants);
            Assert.Equal(mealOrder.Status, expected);
        }

        [Theory]
        [InlineData("InsufficientFood")]
        public void In_Sufficient_Food_Available_At_A_Single_Restaurants_With_Only_Regular_Meals(string expected)
        {
            var meal = new Meal()
            {
                NumberOfMeals = 50,
                OrderedMealTypes = new List<OrderedMealType>()
            };

            var restaurants = new List<Restaurant>()
            {
                new Restaurant()
                {
                    RestaurantName = "Sunterra",
                    Rating = 4.8M,
                    RestaurantMealTypes = new List<RestaurantMealType>()
                    {
                        new RestaurantMealType()
                        {
                            MealType = MealType.FishFree,
                            Capacity = 10
                        },
                        new RestaurantMealType()
                        {
                            MealType = MealType.Vegetarian,
                            Capacity = 10
                        }
                    },
                    Capacity = 30
                }
            };

            mockRestaurantsRepository.Setup(x => x.GetRestaurants()).Returns(restaurants);
            mockMealsRepository.Setup(x => x.GetMealById(1)).Returns(meal);
            OrdersService ordersService = new OrdersService(mockRestaurantsRepository.Object, mockMealsRepository.Object);

            var mealOrder = ordersService.ProcessMealOrder(meal, restaurants);
            Assert.Equal(mealOrder.Status, expected);
        }

        [Theory]
        [InlineData("Confirmed")]
        public void Sufficient_Food_Available_At_Multiple_Restaurants_With_Only_Regular_Meals(string expected)
        {
            var meal = new Meal()
            {
                NumberOfMeals = 50,
                OrderedMealTypes = new List<OrderedMealType>()
            };

            var restaurants = new List<Restaurant>()
            {
                new Restaurant()
                {
                    RestaurantName = "Sunterra",
                    Rating = 4.8M,
                    RestaurantMealTypes = new List<RestaurantMealType>()
                    {
                        new RestaurantMealType()
                        {
                            MealType = MealType.FishFree,
                            Capacity = 5
                        },
                        new RestaurantMealType()
                        {
                            MealType = MealType.Vegetarian,
                            Capacity = 5
                        }
                    },
                    Capacity = 25
                },
                new Restaurant()
                {
                    RestaurantName = "Marcello's",
                    Rating = 4.7M,
                    RestaurantMealTypes = new List<RestaurantMealType>()
                    {
                        new RestaurantMealType()
                        {
                            MealType = MealType.GlutenFree,
                            Capacity = 5
                        },
                        new RestaurantMealType()
                        {
                            MealType = MealType.NutFree,
                            Capacity = 5
                        }
                    },
                    Capacity = 25
                }
            };

            mockRestaurantsRepository.Setup(x => x.GetRestaurants()).Returns(restaurants);
            mockMealsRepository.Setup(x => x.GetMealById(1)).Returns(meal);
            OrdersService ordersService = new OrdersService(mockRestaurantsRepository.Object, mockMealsRepository.Object);

            var mealOrder = ordersService.ProcessMealOrder(meal, restaurants);
            Assert.Equal(mealOrder.Status, expected);
        }

        [Theory]
        [InlineData("InsufficientFood")]
        public void In_Sufficient_Food_Available_At_Multiple_Restaurants_With_Only_Regular_Meals(string expected)
        {
            var meal = new Meal()
            {
                NumberOfMeals = 50,
                OrderedMealTypes = new List<OrderedMealType>()
            };

            var restaurants = new List<Restaurant>()
            {
                new Restaurant()
                {
                    RestaurantName = "Sunterra",
                    Rating = 4.8M,
                    RestaurantMealTypes = new List<RestaurantMealType>()
                    {
                        new RestaurantMealType()
                        {
                            MealType = MealType.FishFree,
                            Capacity = 5
                        },
                        new RestaurantMealType()
                        {
                            MealType = MealType.Vegetarian,
                            Capacity = 5
                        }
                    },
                    Capacity = 25
                },
                new Restaurant()
                {
                    RestaurantName = "Marcello's",
                    Rating = 4.7M,
                    RestaurantMealTypes = new List<RestaurantMealType>()
                    {
                        new RestaurantMealType()
                        {
                            MealType = MealType.GlutenFree,
                            Capacity = 5
                        },
                        new RestaurantMealType()
                        {
                            MealType = MealType.NutFree,
                            Capacity = 5
                        }
                    },
                    Capacity = 20
                }
            };

            mockRestaurantsRepository.Setup(x => x.GetRestaurants()).Returns(restaurants);
            mockMealsRepository.Setup(x => x.GetMealById(1)).Returns(meal);
            OrdersService ordersService = new OrdersService(mockRestaurantsRepository.Object, mockMealsRepository.Object);

            var mealOrder = ordersService.ProcessMealOrder(meal, restaurants);
            Assert.Equal(mealOrder.Status, expected);
        }
    }
}

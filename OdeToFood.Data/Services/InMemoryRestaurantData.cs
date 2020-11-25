using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants; // private field
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "Zsofi's Croissants", Cuisine = CuisineType.French},
                new Restaurant { Id = 2, Name = "Bella Italia", Cuisine = CuisineType.Italian},
                new Restaurant { Id = 3, Name = "Blue Ginger", Cuisine = CuisineType.Indian},
            };
        }

        public Restaurant Get(int id)
        {
            return restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return restaurants.OrderBy(r => r.Name);
        }
    }
}

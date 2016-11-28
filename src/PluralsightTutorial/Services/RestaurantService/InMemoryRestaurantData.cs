using PluralsightTutorial.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PluralsightTutorial.Services
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
    }
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> _restaurants;

        public InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>
            {
                new Restaurant {Id =1, Name ="Steak house" },
                new Restaurant {Id =2, Name ="the Windmill" },
                new Restaurant {Id =3, Name ="Jimmys" }
            };
        }
        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants;
        }
    }
}

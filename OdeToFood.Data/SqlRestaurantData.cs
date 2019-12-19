using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly OdeToFoodDbContext _db;

        public SqlRestaurantData(OdeToFoodDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            return _db.Restaurants
                .Where(r => r.Name.StartsWith(name) || string.IsNullOrEmpty(name))
                .OrderBy(r => r.Name);
        }

        public Restaurant GetById(int id)
        {
            return _db.Restaurants
                .SingleOrDefault(r => r.Id == id);
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var entity = _db.Restaurants.Attach(updatedRestaurant);
            entity.State = EntityState.Modified;
            return updatedRestaurant;
        }

        public int Commit()
        {
            return _db.SaveChanges();
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
           _db.Add(newRestaurant);
           return newRestaurant;
        }

        public Restaurant Delete(int id)
        {
            var restaurantToDelete = GetById(id);
            if (restaurantToDelete != null)
            {
                _db.Remove(restaurantToDelete);
            }

            return restaurantToDelete;
        }

        public int GetCountOfRestaurants()
        {
            return _db.Restaurants.Count();
        }
    }
}
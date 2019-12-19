﻿using System.Collections.Generic;
using System.Text;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetById(int id);
        Restaurant Update(Restaurant updatedRestaurant);
        int Commit();
        Restaurant Add(Restaurant newRestaurant);
        Restaurant Delete(int id);
        int GetCountOfRestaurants();
    }
}

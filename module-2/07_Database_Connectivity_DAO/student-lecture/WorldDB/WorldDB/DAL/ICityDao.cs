using System;
using System.Collections.Generic;
using System.Text;
using WorldDB.Models;

namespace WorldDB.DAL
{
   public interface ICityDao
    {
        List<City> GetCities();
        List<City> GetCities(string countryCode);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using WorldDB.Models;

namespace WorldDB.DAL
{
    public interface ICityDAO
    {
        List<City> GetCities();
        List<City> GetCities(string countryCode);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using WorldDB.Models;
using System.Linq;

namespace WorldDB.DAL
{
    class CountryMockDAO : ICountryDAO
    {
        private List<Country> list = new List<Country>()
        {
            new Country()
            {
                Code = "USA",
                CapitalId = 001,
                Continent = "North America",
                Name = "United States"
            },
            new Country()
            {
                Code = "CAN",
                CapitalId = 002,
                Continent = "North America",
                Name = "Canada"
            },
            new Country()
            {
                Code = "MEX",
                CapitalId = 003,
                Continent = "North America",
                Name = "Mexico"
            },
        };
        public IList<Country> GetCountries()
        {
            return list.ToList();
        }

        public IList<Country> GetCountries(string continent)
        {
            return list.Where(c => c.Continent.Equals(continent, StringComparison.InvariantCultureIgnoreCase)).ToList();
        }

        public Country GetCountryByCode(string countryCode)
        {
            return list.Where(c => c.Code.Equals(countryCode, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
        }
    }
}

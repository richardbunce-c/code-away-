using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Threading;
using WorldDB.DAL;
using WorldDB.Models;
using WorldDB.Views;

namespace WorldDB
{
    class Program
    {
        static void Main(string[] args)
        {
            // This code reads the connection string from appsettings.json
            IConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                        IConfigurationRoot configuration = builder.Build();
            string connectionString = configuration.GetConnectionString("World");


            // TEMPORARY Create an example of reading a db (no DAO pattern)
            //ReadCities(connectionString);


            // TODO 04a: Create a Model for Country to go with the City model we already have
            // TODO 04b: Create a CountrySqlDAO class (GetCountries, GetCountries(continent), GetCountry(code))
            // TODO 04c: Create an ICountryDAO interface


            // TODO 10: Create a CitySqlDAO class (GetCitiesByCountryCode)
            // TODO 10a: Create an ICityDAO interface

            // TODO 14a: Create a Model for CountryLanguage
            // TODO 14b: Create a CountryLanguageSqlDAO class (GetLanguages(string countryCode))
            // TODO 14c: Create an ICountryLanguageDAO interface


            ICityDAO cityDAO = new CitySqlDAO(connectionString);
            ICountryDAO countryDAO = new CountrySqlDAO(connectionString);
            ICountryLanguageDAO countryLanguageDAO = new CountryLanguageSqlDAO(connectionString);


            // TODO 05b: Create a WorldDBMenu, passing in the country dao, and Run it
            WorldDBMenu menu = new WorldDBMenu(cityDAO, countryDAO, countryLanguageDAO);
            menu.Show();

            // Say goodbye to the user...
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("Goodbye...");
            Thread.Sleep(1500);
        }
        private static void ReadCities(string connectionString)
        {
            // TODO 01: Read cities from the database and list the results on the screen.
            // TODO 02: Add a parameter to the query to get the cities for a given country code.


            // Create a list to hold the new city objects
            List<City> list = new List<City>();

            // Create a DB Connection
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Open the connection
                conn.Open();

                // Create a command object for a sql statement
                SqlCommand cmd = new SqlCommand("Select * from City", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    City city = new City();
                    city.CityId = Convert.ToInt32(reader["CityId"]);
                    city.Population = Convert.ToInt32(reader["Population"]);
                    city.Name = Convert.ToString(reader["Name"]);
                    city.District = Convert.ToString(reader["District"]);
                    city.CountryCode = Convert.ToString(reader["CountryCode"]);
                    list.Add(city);
                }
            }

            foreach(City city in list)
            {
                Console.WriteLine(city.ToString());
            }

            Console.ReadLine();
        }

    }
}

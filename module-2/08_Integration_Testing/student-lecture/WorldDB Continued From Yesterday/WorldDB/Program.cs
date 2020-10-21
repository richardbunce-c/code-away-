using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
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

            // TEMPORARY: DB EXAMPLE (vanilla, no DAO)

            ReadCities(connectionString);


            // TODO 01a: Create a Model for Country to go with the City model we already have
            // TODO 01b: Create a CountrySqlDAO class (GetCountries, GetCountries(continent), GetCountry(code))
            // TODO 01c: Create an ICountryDAO interface


            // TODO 07: Create a CitySqlDAO class (GetCitiesByCountryCode)
            // TODO 07a: Create an ICityDAO interface

            // TODO 12a: Create a Model for CountryLanguage
            // TODO 12b: Create a CountryLanguageSqlDAO class (GetLanguages(string countryCode))
            // TODO 12c: Create an ICountryLanguageDAO interface


            // TODO 02b: Create a WorldDBMenu, passing in the country dao, and Run it
            WorldDBMenu menu = new WorldDBMenu();
            menu.Show();

            // Say goodbye to the user...
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("Goodbye...");
            Thread.Sleep(1500);
        }

        private static void ReadCities(string connectionString)
        {
            try
            {
                Console.Write("Enter country code:");
                string countryCode = Console.ReadLine();

                // Create a dao to get data from cities
                ICityDAO cityDAO = new CitySqlDAO(connectionString);

                List<City> cities;

                if (countryCode.Length == 0)
                {
                    cities = cityDAO.GetCities();
                }
                else
                {
                    cities = cityDAO.GetCities(countryCode);
                }

                #region The old way
                ////Create a list to hold all the cites
                //List<City> cities = new List<City>();
                //using (SqlConnection connection = new SqlConnection(connectionString))
                //{
                //    // Open the connection
                //    connection.Open();

                //    // Create a command to contain our SQL statement
                //    string sql = $"Select * from City Where CountryCode = @countryCode";
                //    SqlCommand cmd = new SqlCommand(sql, connection);
                //    cmd.Parameters.AddWithValue("@countryCode", countryCode);

                //    // Execute the command and save the reference to the *result set*
                //    SqlDataReader rdr = cmd.ExecuteReader();

                //    // Loop through each row in the result set
                //    while (rdr.Read())
                //    {
                //        // For this row, create a city object
                //        City city = new City();
                //        city.CityId      = Convert.ToInt32(rdr["CityId"]);
                //        city.CountryCode = Convert.ToString(rdr["CountryCode"]);
                //        city.District    = Convert.ToString(rdr["District"]);
                //        city.Name        = Convert.ToString(rdr["Name"]);
                //        city.Population  = Convert.ToInt32(rdr["Population"]);

                //        cities.Add(city);
                //    }

                //}
                #endregion

                // Now print the items in the list
                foreach (City city in cities)
                {
                    Console.WriteLine($"{city.Name}, {city.District}");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error accessing database: {ex.Message}");
            }
            Console.ReadLine();
        }
    }
}

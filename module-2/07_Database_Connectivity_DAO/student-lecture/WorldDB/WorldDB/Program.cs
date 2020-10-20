using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading;
using WorldDB.DAL;
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

            Console.ReadLine();
        }
    }
}

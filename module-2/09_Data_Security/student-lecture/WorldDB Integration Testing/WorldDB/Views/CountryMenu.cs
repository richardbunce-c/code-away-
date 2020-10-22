﻿using WorldDB.Models;
using System;
using System.Collections.Generic;
using System.Text;
using WorldDB.DAL;
using MenuFramework;

namespace WorldDB.Views
{
    /// <summary>
    /// The Country sub-menu
    /// </summary>
    public class CountryMenu : ConsoleMenu
    {
        private Country country = null;

        // TODO 09a: Store the Interfaces to our data objects
        protected ICityDAO cityDAO;
        protected ICountryDAO countryDAO;
        protected ICountryLanguageDAO countryLanguageDAO;


        /// <summary>
        /// Constructor adds items to the top-level menu
        /// </summary>
        public CountryMenu(Country country, ICityDAO cityDAO, ICountryDAO countryDAO, ICountryLanguageDAO countryLanguageDAO)
        {
            // TODO 09b: Update this constructor to accept appropriate daos, and save them in local variables.
            // TODO 15a: Change this constructor to require country-language dao

            this.cityDAO = cityDAO;
            this.countryDAO = countryDAO;
            this.countryLanguageDAO = countryLanguageDAO;


            // Save the country (which will be used for all country queries
            this.country = country;

            // This code is just protection because before we complete the code, Country may be null
            if (country == null)
            {
                country = new Country();
            }

            // Add options to this menu
            AddOption($"List Cities in {country.Name}", ListCities)
                .AddOption($"List Languages in {country.Name}", ListLanguages)
                .AddOption($"Add a city to {country.Name}", AddCity)
                .AddOption("Back", Exit);

            Configure(cfg =>
            {
                cfg.ItemForegroundColor = ConsoleColor.DarkGreen;
                cfg.SelectedItemForegroundColor = ConsoleColor.Green;
            });

        }

        private MenuOptionResult ListLanguages()
        {
            // TODO 16: Get the list of languages for this country (GetLanguages)
            IList<CountryLanguage> countryLanguages = countryLanguageDAO.GetLanguages(country.Code);
            SetColor(ConsoleColor.Blue);
            Console.WriteLine(CountryLanguage.GetHeader());
            foreach (CountryLanguage language in countryLanguages)
            {
                Console.WriteLine(language);
            }
            ResetColor();
            return MenuOptionResult.WaitAfterMenuSelection;
        }

        private MenuOptionResult ListCities()
        {
            // TODO 12: Get the list of cities (GetCitiesByCountryCode)
            IList<City> cities = cityDAO.GetCitiesByCountryCode(country.Code);

            SetColor(ConsoleColor.DarkYellow);
            Console.WriteLine(City.GetHeader());
            foreach (City city in cities)
            {
                Console.WriteLine(city);
            }
            ResetColor();
            return MenuOptionResult.WaitAfterMenuSelection;
        }

        private MenuOptionResult AddCity()
        {
            SetColor(ConsoleColor.Cyan);
            string name = GetString("Name of the city: ");
            string district = GetString($"District {name} is in: ");
            int population = GetInteger($"Population of {name}: ");

            // TODO 13a: Create a city object and set its properties
            City city = new City
            {
                CountryCode = country.Code,
                Name = name,
                District = district,
                Population = population
            };

            // TODO 13b: Add the city (AddCity)
            int newCityId = cityDAO.AddCity(city);
            if (newCityId > 0)
            {
                Console.WriteLine($"City was added with id {newCityId}.");
            }
            else
            {
                Console.WriteLine("City was not added");
            }
            ResetColor();
            return MenuOptionResult.WaitAfterMenuSelection;
        }


        protected override void OnBeforeShow()
        {
            SetColor(ConsoleColor.Magenta);

            // TODO 11: Print a header that shows Country information
            Console.WriteLine($"{country.Name,-39} Population: {country.Population:N0}");
            Console.WriteLine($"Head of State: {country.HeadOfState,-24} Capital: {country.CapitalId}");
            Console.WriteLine(new string('=', 70));

            ResetColor();
        }

    }
}

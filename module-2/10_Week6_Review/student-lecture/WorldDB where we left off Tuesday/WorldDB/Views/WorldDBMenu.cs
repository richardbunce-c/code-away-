﻿using WorldDB.Models;
using System;
using System.Collections.Generic;
using System.Text;
using WorldDB.DAL;
using MenuFramework;

namespace WorldDB.Views
{
    /// <summary>
    /// The top-level menu in our Market Application
    /// </summary>
    public class WorldDBMenu : ConsoleMenu
    {
        // TODO 02c: Store the Interfaces to our data objects



        /// <summary>
        /// Constructor adds items to the top-level menu
        /// </summary>
        public WorldDBMenu()
        {
            // TODO 02a: Change this constructor to require country dao
            // TODO 13a: Change this constructor to require country-language dao

            // TODO 02d: Assign the Interfaces to protected variables so we can use them later

            // Add options to this menu
            AddOption("List Countries", ListCountries)
                .AddOption("List Countries on a continent", ListCountriesForContinent)
                .AddOption("Select a country", SelectACountry)
                .AddOption("Quit", Exit);

            Configure(cfg =>
            {
                cfg.ItemForegroundColor = ConsoleColor.Yellow;
                cfg.SelectedItemForegroundColor = ConsoleColor.Green;
            });
        }

        private MenuOptionResult ListCountries()
        {
            // TODO 03: Get the list of countries for all continents (GetCountries)
            IList<Country> countries = new List<Country>();
            SetColor(ConsoleColor.Blue);
            Console.WriteLine(Country.GetHeader());
            foreach (Country country in countries)
            {
                Console.WriteLine(country);
            }
            ResetColor();
            return MenuOptionResult.WaitAfterMenuSelection;
        }

        private MenuOptionResult ListCountriesForContinent()
        {
            string continent = GetString("Continent: ", true);

            // TODO 04: Get the list of countries for a continent (GetCountries)
            IList<Country> countries = new List<Country>();

            SetColor(ConsoleColor.Green);
            Console.WriteLine(Country.GetHeader());
            foreach (Country country in countries)
            {
                Console.WriteLine(country);
            }
            ResetColor();
            return MenuOptionResult.WaitAfterMenuSelection;
        }

        private MenuOptionResult SelectACountry()
        {
            string countryCode = GetString("Enter the Country Code: ");

            // TODO 05: Lookup the country (GetCountryByCode) and pass that into the country submenu
            Country country = null;
            if (country == null)
            {
                Console.WriteLine($"Sorry, country '{countryCode}' does not exist.");
                return MenuOptionResult.WaitAfterMenuSelection;
            }

            // Code was found, invoke the Country menu
            // TODO 06: Pass countryDAO into country menu.  We are going to need a CityDAO also!
            CountryMenu menu = new CountryMenu(country);
            menu.Show();
            return MenuOptionResult.DoNotWaitAfterMenuSelection;

        }

        protected override void OnBeforeShow()
        {
            PrintHeader();
        }

        private void PrintHeader()
        {
            SetColor(ConsoleColor.Cyan);
            Console.WriteLine(@" _    _  _____ ______  _     ______     ______   ___   _____   ___  ______   ___   _____  _____ ");
            Console.WriteLine(@"| |  | ||  _  || ___ \| |    |  _  \    |  _  \ / _ \ |_   _| / _ \ | ___ \ / _ \ /  ___||  ___|");
            Console.WriteLine(@"| |  | || | | || |_/ /| |    | | | |    | | | |/ /_\ \  | |  / /_\ \| |_/ // /_\ \\ `--. | |__  ");
            Console.WriteLine(@"| |/\| || | | ||    / | |    | | | |    | | | ||  _  |  | |  |  _  || ___ \|  _  | `--. \|  __| ");
            Console.WriteLine(@"\  /\  /\ \_/ /| |\ \ | |____| |/ /     | |/ / | | | |  | |  | | | || |_/ /| | | |/\__/ /| |___ ");
            Console.WriteLine(@" \/  \/  \___/ \_| \_|\_____/|___/      |___/  \_| |_/  \_/  \_| |_/\____/ \_| |_/\____/ \____/ ");
            ResetColor();
        }
    }
}

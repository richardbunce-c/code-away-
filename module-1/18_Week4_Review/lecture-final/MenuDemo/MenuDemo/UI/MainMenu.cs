using MenuFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuDemo.UI
{
    public class MainMenu : ConsoleMenu
    {
        public MainMenu()
        {
            AddOption("Get Current Time", GetCurrentTime);
            AddOption("Get the Weather", GetWeather);
            AddOption("Sub-Menu", RunSubMenu);
            AddOption("Exit", Exit);

            Configure(cfg =>
            {
                cfg.ItemForegroundColor = ConsoleColor.Green;
                cfg.SelectedItemForegroundColor = ConsoleColor.DarkCyan;
                cfg.Title = "Main Menu";
            });

        }

        private MenuOptionResult RunSubMenu()
        {
            SubMenu subMenu = new SubMenu();
            subMenu.Show();
            return MenuOptionResult.DoNotWaitAfterMenuSelection;
        }

        private MenuOptionResult GetWeather()
        {
            Console.WriteLine("It's nice out");
            return MenuOptionResult.WaitAfterMenuSelection;
        }

        private MenuOptionResult GetCurrentTime()
        {
            Console.WriteLine(DateTime.UtcNow);
            return MenuOptionResult.WaitAfterMenuSelection;
        }

    }
}

using MenuDemo.UI;
using MenuFramework;
using System;

namespace MenuDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //This is a demo of the ConsoleMenuFramework package for creating menus

            //ConsoleMenu mainMenu = new ConsoleMenu();
            //mainMenu.AddOption("Get Current Time", GetCurrentTime);
            //mainMenu.AddOption("Get the Weather", GetWeather);
            //mainMenu.AddOption("Exit", Exit);

            //mainMenu.Configure(cfg =>
            //{
            //    cfg.ItemForegroundColor = ConsoleColor.Green;
            //    cfg.SelectedItemForegroundColor = ConsoleColor.Magenta;
            //    cfg.Title = "Main Menu";


            //});

            //mainMenu.Show();
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
            //}

            //private static MenuOptionResult Exit()
            //{
            //    return MenuOptionResult.CloseMenuAfterSelection;
            //}


            //private static MenuOptionResult GetWeather()
            //{
            //    Console.WriteLine($"Today it is 62 degrees and sunny");
            //    return MenuOptionResult.WaitAfterMenuSelection;
            //}

            //private static MenuOptionResult GetCurrentTime()
            //{
            //    Console.WriteLine($"The time is {DateTime.Now}");
            //    return MenuOptionResult.WaitAfterMenuSelection;
        }


    }
    }

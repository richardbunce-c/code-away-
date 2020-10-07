using Market.Classes;
using Market.Views;
using System;
using System.Collections.Generic;

namespace Market
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Product> products = ProductLoader.LoadProducts(@"Data\Products.txt");

            // Create a store that holds all the products
            Store store = new Store(products);

            // Create and launch the main menu
            MainMenu mainMenu = new MainMenu(store);
            mainMenu.Show();

            // Exit the program
            Console.WriteLine("Thank you for shopping with us!");
            Console.ReadKey();
        }
    }
}

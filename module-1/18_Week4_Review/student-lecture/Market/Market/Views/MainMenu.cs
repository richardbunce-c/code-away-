using Market.Classes;
using MenuFramework;
using System;

namespace Market.Views
{
    public class MainMenu : ConsoleMenu
    {
        private Store Store;
        private Cart Cart;

        public MainMenu(Store store)
        {
            Store = store;
            Cart = new Cart();

            AddOption("Shop Categories", ShopCategories);
            AddOption("Show Cart", ShowCart);
            AddOption("Print a Receipt and Checkout", Checkout);
            AddOption("Exit", Exit);

            Configure(cfg =>
            {
                cfg.Title = "*** Main Menu ***";
                cfg.ItemForegroundColor = ConsoleColor.Gray;
                cfg.SelectedItemForegroundColor = ConsoleColor.Green;
                cfg.Selector = "==>";
            });
        }

        private MenuOptionResult ShopCategories()
        {
            // Show the categories menu
            CategoriesMenu catMenu = new CategoriesMenu(this.Store, this.Cart);
            catMenu.Show();
            return MenuOptionResult.DoNotWaitAfterMenuSelection;
        }

        private MenuOptionResult ShowCart()
        {
            // Write the heading
            string[] headings = { "Item name", "Price", "Quantity", "Amount" };

            Console.WriteLine();
            Console.WriteLine("Your shopping cart");
            Console.WriteLine();
            Console.WriteLine($"{headings[0],-20} {headings[1],8} {headings[2],10} {headings[3],15}");
            Console.WriteLine($"{new string('_', 20)} {new string('_', 8)} {new string('_', 10)} {new string('_', 15)} ");
            // Display the items in the cart
            foreach (CartItem item in Cart.CartItems)
            {
                Console.WriteLine($"{item.Product.ProductName,-20} {item.Product.Price,8:C} {item.Quantity,10} {item.TotalAmount,15:C}");
            }
            Console.WriteLine($"{new string('_', 56)}");
            Console.WriteLine($"{new string(' ', 40)} {Cart.TotalAmount,15:C}");

            return MenuOptionResult.WaitAfterMenuSelection;
        }

        private MenuOptionResult Checkout()
        {
            const string fileName = @"data\receipt.txt";
            this.Cart.Checkout(fileName);
            Console.WriteLine($"Your receipt is available at {fileName}.");
            return MenuOptionResult.WaitAfterMenuSelection;
        }
    }
}

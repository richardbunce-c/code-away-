using Market.Classes;
using MenuFramework;
using System;

namespace Market.Views
{
    public class ProductsMenu : ConsoleMenu
    {
        private Store store;
        private Cart cart;
        private string category;
        public ProductsMenu(Store store, Cart cart, string category)
        {
            this.store = store;
            this.cart = cart;
            this.category = category;

            Configure(cfg =>
            {
                cfg.Title = $"{category} Menu";
            });
        }

        protected override void RebuildMenuOptions()
        {
            ClearOptions();
            foreach (Product product in store.GetProductsForCategory(category))
            {
                AddOption<Product>($"{product.ProductName,-40} {product.Price,10:C}", SelectProduct, product);
            }
            AddOption("Back to Categories", Exit);
        }

        private MenuOptionResult SelectProduct(Product product)
        {
            int qty = GetInteger($"Quantity of {product.ProductName}:", 1);
            if (qty > 0)
            {
                cart.Add(product, qty);
                Console.WriteLine();
                Console.WriteLine($"{product.ProductName} ({qty}) was added to your cart!");
                return MenuOptionResult.WaitAfterMenuSelection;
            }
            else
            {
                return MenuOptionResult.DoNotWaitAfterMenuSelection;
            }
        }

    }
}

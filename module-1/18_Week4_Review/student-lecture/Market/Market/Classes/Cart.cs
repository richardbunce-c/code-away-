using System;
using System.Collections.Generic;
using System.IO;

namespace Market.Classes
{
    public class Cart
    {
        // Cart is a dictionary of CartItems, keyed by Product
        private Dictionary<Product, CartItem> itemsDictionary = new Dictionary<Product, CartItem>();

        public CartItem[] CartItems
        {
            get
            {
                // Return a flat list of items
                List<CartItem> cartItems = new List<CartItem>();
                foreach (KeyValuePair<Product, CartItem> item in this.itemsDictionary)
                {
                    cartItems.Add(item.Value);
                }
                return cartItems.ToArray();
            }
        }

        public void Add( Product product, int quantity)
        {
            // To add items to the cart, look for the product. If it's already in the cart, add to the qty. Else, add it.
            // TODO 02: Implement add to either add or increase the qty of items in the cart.
        }

        public decimal TotalAmount
        {
            get
            {
                //Get the total value of the entire cart
                decimal amount = 0.00M;
                // TODO 03: Calculate this derived property

                return amount;
            }
        }

        public void Checkout(string fileName)
        {
            try
            {
                // TODO 08: Print the receipt into the given file name

                // If the receipt print succeeded, then clear the cart.
                this.itemsDictionary.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error {ex.Message} while printing receipt. Checkout failed.");
            }
        }
    }
}

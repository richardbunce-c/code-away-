using System.Runtime.CompilerServices;

namespace Market.Classes
{
    public class Product
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }

        //private int stock { get;  }


        public Product (string productName, decimal price, string category /*k/*int stoc**/)
        {
            this.ProductName = productName;
            this.Price = price;
            this.Category = category;
            //this.stock = stock;
        }
    }
}

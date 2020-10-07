using System.Collections.Generic;
using System.IO;

namespace Market.Classes
{
    public static class ProductLoader
    {
        public static IEnumerable<Product> LoadProducts(string filePath)
        {
            return new Product[]{
                        new Product("Apples", 6.99M, "Fruit"),
                        new Product("Bananas", 1.99M, "Fruit"),
                        new Product("Broccoli", 2.50M, "Vegetables"),
                        new Product("Cauliflower", 5.00M, "Vegetables"),
                        new Product("Cheese", 12.00M, "Dairy"),
            };

            // TODO 07: Load the products from the data file instead of a hard-coded array 
        }
    }
}

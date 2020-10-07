using System.Collections.Generic;

namespace Market.Classes
{
    public class Store
    {
        private SortedDictionary<string, List<Product>> inventory;

        public Store(IEnumerable<Product> productList)
        {
            // The constructor expects a collection of products, and then it loads its inventory Dictionary by catgory

            // TODO 04: Load the inventory Dictionary for lookup by category.  Each key (category) points to 
            // a list of products in that category.
            this.inventory = new SortedDictionary<string, List<Product>>();
        }

        public string[] Categories
        {
            // Return a string array of category names
            get
            {
                List<string> categories = new List<string>();
                // TODO 05: Use inventory.Keys to get all the categories

                return categories.ToArray();
            }
        }

        public Product[] GetProductsForCategory(string category)
        {
            // Return the list of products for a category

            // TODO 06: Lookup the category and return the list of products as an array



            return new List<Product>().ToArray();
        }
    }
}

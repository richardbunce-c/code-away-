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

            // Loop thru the products passed in
            foreach (Product product in productList)
            {
                // See if the category is already in our dictionary
                if (!inventory.ContainsKey(product.Category))
                {
                    // If not in dictionary, Add a kvp, with Category as the Key, and a new empty List<Product> as the value.
                    inventory[product.Category] = new List<Product>();
                }

                // Add the product to the product list
                List<Product> list = inventory[product.Category];
                list.Add(product);
            }
        }

        public string[] Categories
        {
            // Return a string array of category names
            get
            {
                List<string> categories = new List<string>();
                // TODO 05: Use inventory.Keys to get all the categories
                foreach (string category in inventory.Keys)
                {
                    categories.Add(category);
                }
                return categories.ToArray();
            }
        }

        public Product[] GetProductsForCategory(string category)
        {
            // Return the list of products for a category

            // TODO 06: Lookup the category and return the list of products as an array
            if (inventory.ContainsKey(category))
            {
                return inventory[category].ToArray();
            }

            // Falll back to an empty list of products
            return new List<Product>().ToArray();
        }
    }
}

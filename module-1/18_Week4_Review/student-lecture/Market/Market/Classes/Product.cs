namespace Market.Classes
{
    public class Product
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public Product (string productName, decimal price, string category)
        {
            this.ProductName = productName;
            this.Price = price;
            this.Category = category;
        }
    }
}

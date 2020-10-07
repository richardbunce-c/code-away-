namespace Market.Classes
{
    public class CartItem
    {
        public CartItem(Product product, int quantity)
        {
            this.Product = product;
            this.Quantity = quantity;
        }

        public Product Product { get; set; }
        public int Quantity { get; set; } = 0;
        public decimal TotalAmount
        {
            get
            {
                // TODO 01: Implement the derived property for the total value of this cart item

                return Quantity * Product.Price;
            }
        }
    }
}

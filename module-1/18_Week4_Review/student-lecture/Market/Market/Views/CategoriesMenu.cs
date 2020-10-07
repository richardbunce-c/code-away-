using Market.Classes;
using MenuFramework;

namespace Market.Views
{
    public class CategoriesMenu : ConsoleMenu
    {
        private Store store;
        private Cart cart;
        public CategoriesMenu(Store store, Cart cart)
        {
            this.store = store;
            this.cart = cart;

            Configure(cfg =>
            {
                cfg.Title = "*** Categories ***";
            });
        }

        protected override void RebuildMenuOptions()
        {
            ClearOptions();
            string[] categories = store.Categories;
            foreach (string category in store.Categories)
            {
                AddOption<string>(category, ShowProductsForCategory);
            }
            AddOption("Back to Main", Exit);
        }

        private MenuOptionResult ShowProductsForCategory(string category)
        {
            // Launch the products menu
            ProductsMenu prodMenu = new ProductsMenu(this.store, this.cart, category);
            prodMenu.Show();
            return MenuOptionResult.DoNotWaitAfterMenuSelection;
        }
    }
}

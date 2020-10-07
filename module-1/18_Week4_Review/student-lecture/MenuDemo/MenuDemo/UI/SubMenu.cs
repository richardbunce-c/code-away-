using MenuFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuDemo.UI
{
    public class SubMenu : ConsoleMenu
    {
        public SubMenu()
        {
            AddOption("Option 1", Method1)
                .AddOption("Option 2", Method2)
                .AddOption("Back to Main", Exit);
        }

        private MenuOptionResult Method2()
        {
            Console.WriteLine("Method2");
            return MenuOptionResult.WaitAfterMenuSelection;
        }

        private MenuOptionResult Method1()
        {
            Console.WriteLine("Method1");
            return MenuOptionResult.WaitAfterMenuSelection;
        }
    }
}

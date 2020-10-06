using System;
using System.Collections.Generic;
using Tasks.Models;

namespace Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskList tasks = new TaskList("Tasks.txt");
            tasks.Load();

            TaskMenu menu = new TaskMenu(tasks);
            menu.Show();
        }
    }
}

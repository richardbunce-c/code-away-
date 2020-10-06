using MenuFramework;
using System;
using System.Collections.Generic;
using System.Text;
using Tasks.Models;

namespace Tasks
{
    public class TaskMenu : ConsoleMenu
    {
        private TaskList tasks;
        public TaskMenu(TaskList tasks)
        {
            // Build the main menu
            this.tasks = tasks;
            AddOption("Add a Task", AddTask);
            AddOption("Complete a Task", CompleteTask);
            AddOption("Exit", Exit);

            Configure(config =>
            {
                config.ItemForegroundColor = ConsoleColor.White;
                config.SelectedItemForegroundColor = ConsoleColor.Cyan;
                config.Title = "Welcome to Task List!";
            });
        }

        protected override void OnBeforeShow()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            ListTasks();
            Console.WriteLine("===========================================================================");

        }

        private MenuOptionResult AddTask()
        {
            // Prompt the user to add a task
            Task task = GetTaskinfo();
            tasks.AddTask(task);
            return MenuOptionResult.DoNotWaitAfterMenuSelection;
        }
        private MenuOptionResult CompleteTask()
        {
            Task[] openTasks = tasks.OpenTasks;
            if (openTasks.Length == 0)
            {
                Console.WriteLine("There are no open tasks");
                return MenuOptionResult.WaitAfterMenuSelection;
            }

            ConsoleMenu cm = new ConsoleMenu()
                .AddOptionRange<Task>(tasks.OpenTasks, CompleteTask)
                .Configure(cfg =>
                {
                    cfg.Title = "Select a task to complete:";
                });

            cm.Show();
            return MenuOptionResult.DoNotWaitAfterMenuSelection;
        }

        private MenuOptionResult CompleteTask(Task selectedTask)
        {
            selectedTask.Completed = true;
            tasks.Save();
            return MenuOptionResult.CloseMenuAfterSelection;
        }

        private void ListTasks()
        {
            Task[] list = tasks.List;
            string[] headings = { "Number", "Task", "Due Date", "Completed" };
            Console.WriteLine($"{headings[0],6} {headings[1],-30} {headings[2],-15} {headings[3],-10}");
            for (int i = 0; i < list.Length; i++)
            {
                Task task = list[i];
                Console.WriteLine($"{i + 1,6} {task.TaskName,-30} {task.DueDate,-15:d} {task.Completed,-10}");
            }
        }

        private Task GetTaskinfo()
        {
            Console.WriteLine("\r\n*** Add a Task ***");
            string taskName = GetString("Task name");
            DateTime dueDate = GetDate("Due date", DateTime.Now + new TimeSpan(1, 0, 0, 0));
            return new Task(taskName, dueDate);
        }

    }
}

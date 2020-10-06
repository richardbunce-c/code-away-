using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Tasks.Models
{
    public class TaskList
    {
        public string Path { get; set; }
        private List<Task> taskList { get; set; }
        public int Count
        {
            get
            {
                return this.taskList.Count;
            }
        }
        public Task[] List
        {
            get
            {
                return this.taskList.ToArray();
            }
        }

        public Task[] OpenTasks
        {
            get
            {
                List<Task> openTasks = new List<Task>();
                foreach (Task t in taskList)
                {
                    if (!t.Completed) openTasks.Add(t);
                }
                return openTasks.ToArray();
            }
        }

        public TaskList(string path)
        {
            this.Path = path;
        }

        public void Load()
        {
            this.taskList = new List<Task>();

            // TODO 01: Load tasks from the file (in Path), parse and create Tasks, add them to the list

            // Open the task file for read
            try
            {
                using (StreamReader rdr = new StreamReader(Path))
                {
                    // Loop through the lines in the file (task data)
                    while (!rdr.EndOfStream)
                    {
                        // Parse the data and create a new task
                        string inputLine = rdr.ReadLine();
                        string[] fields = inputLine.Split("|");

                        string taskName = fields[0];
                        DateTime due = DateTime.Parse(fields[1]);
                        bool complete = bool.Parse(fields[2]);

                        Task task = new Task(taskName, due, complete);

                        // Add the task to the tasklist
                        taskList.Add(task);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Could not load tasks");
            }


        }

        public void Save()
        {
            // TODO 02: Open the file at Path, and write all the tasks there

            // Open a new file to write our entire task list to
            using (StreamWriter sw = new StreamWriter(Path, false))
            {
                // Loop thru each task in the list, and write a line in the file containing the task data
                foreach(Task task in taskList)
                {
                    string outputLine = string.Join("|", task.TaskName, task.DueDate, task.Completed);
                    sw.WriteLine(outputLine);
                }
            }
        }


        public void AddTask(Task newTask)
        {
            this.taskList.Add(newTask);
            this.Save();
        }

        public void RemoveTask(Task taskToRemove)
        {
            if (this.taskList.Contains(taskToRemove))
            {
                this.taskList.Remove(taskToRemove);
                this.Save();
            }
        }

    }

}

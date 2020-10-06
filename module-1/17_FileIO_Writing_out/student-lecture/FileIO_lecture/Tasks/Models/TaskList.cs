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

        }

        public void Save()
        {
            // TODO 02: Open the file at Path, and write all the tasks there
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

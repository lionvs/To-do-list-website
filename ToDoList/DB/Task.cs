using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ToDoList.DB
{
    public class Task
    {
        public int Id { get; set; }

       public DateTime Date { get; set; }
        public string TaskName { get; set; }
        public Category TaskCategory { get; set; }
        public bool IsFinished { get; set; }
        public virtual List<SubTask> subTasks { get; set; }

        public Task()
        {
        }

        public Task(DateTime date, string taskName, Category taskCategory, List<SubTask> subTasks)
        {
            Date = date;
            TaskName = taskName;
            TaskCategory = taskCategory;
            this.subTasks = subTasks;
            IsFinished = false;
        }
    }
}
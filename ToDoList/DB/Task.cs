using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Web;

namespace ToDoList.DB
{
    public class Task
    {
        [Key]
        public int Id { get; set; }

       public DateTime Date { get; set; }
        public string TaskName { get; set; }
        [ForeignKey("TaskCategory")]
        public int CategoryId { get; set; }
        public virtual Category TaskCategory { get; set; }
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
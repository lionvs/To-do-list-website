using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ToDoList.DB
{
    public class ToDoDB: DbContext
    {
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<SubTask> SubTasks { get; set; }
    }
}
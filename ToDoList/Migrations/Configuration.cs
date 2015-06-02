using System.Collections.Generic;
using ToDoList.DB;

namespace ToDoList.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ToDoList.DB.ToDoDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ToDoList.DB.ToDoDB context)
        {
            context.Tasks.AddOrUpdate(new Task(DateTime.Now, "First Task", new Category("My Cat"), new List<SubTask>() { new SubTask("Sub 1"), new SubTask("Sub 2"), new SubTask("Sub 3") })
                
                );

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}

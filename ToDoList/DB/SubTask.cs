using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoList.DB
{
    public class SubTask
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public string SubName { get; set; }
        public bool IsFinished { get; set; }

        public SubTask()
        {
        }

        public  SubTask(string subName)
        {
            SubName = subName;
        }
    }
}
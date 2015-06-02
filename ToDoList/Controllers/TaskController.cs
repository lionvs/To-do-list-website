using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoList.DB;

namespace ToDoList.Controllers
{
    public class TaskController : Controller
    {
        //
        // GET: /Task/
        ToDoDB db = new ToDoDB();
        public ActionResult Index()
        {
            var tasks = db.Tasks.ToList();
            return View(tasks);
        }

    }
}

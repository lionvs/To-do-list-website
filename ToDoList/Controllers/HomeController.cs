using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoList.DB;

namespace ToDoList.Controllers
{
    public static class smyg
    {
        public static string IntString(this int cur)
        {
            return "My own method";
        }
    }
    public class HomeController : Controller
    {
        ToDoDB db = new ToDoDB();
        public ActionResult Index()
        {
            int k = 0;
            //k.IntString();
            ViewBag.Message = k.IntString();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}

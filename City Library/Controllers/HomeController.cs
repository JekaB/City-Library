using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace City_Library.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Trainee .NET developer. Intouch Media.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Евгений Бочаров";

            return View();
        }

        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentACar.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult About()
        {
            ViewBag.Message = "We are RentACar Timisoara";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Where you can find us.";

            return View();
        }
    }
}
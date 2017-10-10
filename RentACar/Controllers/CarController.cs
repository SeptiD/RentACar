using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentACar.Controllers
{
    public class CarController : Controller
    {
        // GET: Car
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cars()
        {
            return View();
        }

        public ActionResult NewRent()
        {
            return View();
        }
    }
}
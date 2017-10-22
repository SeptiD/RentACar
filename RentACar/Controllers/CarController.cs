using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentACar.Models;

namespace RentACar.Controllers
{
    public class CarController : Controller
    {
        CarsEntities db = new CarsEntities();
        // GET: Car
        

        public ActionResult Cars()
        {
            var cars = from c in db.Tables
                where c.Available == true
                select c;
            return View(cars.ToList());
        }

        public ActionResult NewRent()
        {
            return View();
        }
    }
}
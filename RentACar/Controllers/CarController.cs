using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            var cars = from c in db.MyCars
                where c.Available == true
                select c;
            return View(cars.ToList());
        }

        public ActionResult Details(int id)
        {

            var thisCar = db.MyCars.Find(id);
            return View();
            //return Content(thisCar.ToString());

        }

        [Authorize]
        public ActionResult NewRent()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            var possibleCars = from c in db.MyCars
                where c.Available == true
                select c;

            foreach (var aCar in possibleCars)
            {
                items.Add(new SelectListItem {Text = aCar.Name + " " + aCar.Brand, Value = aCar.Id.ToString()});
            }
            ViewBag.PossibleCars = items;
            return View();
        }

        public ActionResult UserSelectedCar(string PossibleCars)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            int id = -1;
            id = int.Parse(PossibleCars);
            db.ChangeAvailability(id);
            db.SaveChanges();
            return RedirectToAction("Cars");
        }

        public ActionResult Create()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([Bind(Exclude = "Id")] MyCar carToCreate)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            db.AddToCarSet(carToCreate);
            db.SaveChanges();
            return RedirectToAction("Cars");

        }


    }
}
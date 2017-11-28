using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
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
           
            return View(thisCar);
            //return Content(thisCar.ToString());

        }

        [Authorize]
        public ActionResult MyRents()
        {
            string thisUserID = System.Web.HttpContext.Current.User.Identity.GetUserId();
            var myRents = from c in db.MyCars
                where c.Renter.Equals(thisUserID)
                select c;
            
            return View(myRents.ToList());
        }

        public ActionResult UserSelectedCar(string possibleCars)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            int id = -1;
            id = int.Parse(possibleCars);
            string thisUserId = System.Web.HttpContext.Current.User.Identity.GetUserId();
            db.SetUnavailable(id,thisUserId);
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

        [Authorize]
        public ActionResult Delete(int id)
        {
            db.MyCars.Remove(db.MyCars.Find(id));
            db.SaveChanges();
            return RedirectToAction("Cars");

        }

        public ActionResult Rent(int id)
        {
            if (HttpContext.User.Identity.IsAuthenticated == false)
            {
                return RedirectToAction("Login","Account");
            }
            UserSelectedCar(id.ToString());
            return RedirectToAction("MyRents", "Car");
        }

        public ActionResult ReturnCar(int id)
        {
            db.SetAvailable(id);
            db.SaveChanges();
            return RedirectToAction("MyRents", "Car");
        }

    }
}
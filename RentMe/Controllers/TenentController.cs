using RentMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentMe.Controllers
{
    public class TenentController : Controller
    {
        // GET: Tenent
        public ActionResult TenentMain()
        {
            return View();

        }

        [HttpPost]
        [ActionName("TenentMain")]
        public ActionResult TenentMain_Post(Tenent tenent)
        {

            return RedirectToAction("SearchRentals",tenent);

         //   return View(tenent);
        }


        public ActionResult SearchRentals(Tenent t)
        {
            RenterContext rentercontext = new RenterContext();
            RenterBusinessLayer renterBusinessLayer = new RenterBusinessLayer();
            List<Renter> rentals;
            rentals = renterBusinessLayer.GetRentPropertyInfo(t);

           return View(rentals);
         

        }
    }
}
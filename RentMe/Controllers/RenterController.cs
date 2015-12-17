using RentMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentMe.Controllers
{
    [HandleError(View = "DatabaseError")]
    public class RenterController : Controller
    {
        // GET: Renter
        public ActionResult Index()
        {
            RenterBusinessLayer renterBusinessLayer = new RenterBusinessLayer();
            List<Renter> rentals = renterBusinessLayer.Rentals.ToList();
            return View(rentals);
            
        }

        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create_Get()
        {
        //    RenterBusinessLayer rentterbusinesslayer = new RenterBusinessLayer();
          //  rentterbusinesslayer.AddRentPropertyInfo(renterinfo);
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post(Renter renterinfo)
        {
            if (ModelState.IsValid)
            {
                RenterBusinessLayer rentterbusinesslayer = new RenterBusinessLayer();
                try
                {
                    rentterbusinesslayer.AddRentPropertyInfo(renterinfo);
                }
                catch (Exception ex)
                {

                    TempData["Fail"] = "Add not posted Check the details and try again.";
                    return View("Create");
                }
                TempData["Success"] = "Congrats Your Add has been posted.";
                
              return RedirectToAction("Show",renterinfo);
            }
            return View();
        }
        public ActionResult Show(Renter renterinfo)
        {
            
            return View();
        }


        public ActionResult DisplayError(Exception message)
        {

            return View();
        }

    }
}
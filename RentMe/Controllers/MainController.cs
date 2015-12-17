using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentMe.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
        
        public ActionResult Index()
        {
            return View();
        }
    }
}
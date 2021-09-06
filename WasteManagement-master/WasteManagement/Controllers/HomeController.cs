using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WasteManagement.Controllers
{
    public class HomeController : Controller
    {
        BusinessLogic.Locations _l;


        public HomeController()
        {
            _l = new BusinessLogic.Locations();
        }


        [ActionName("Schedule")]
        public ActionResult Index()
        {
            return View();
        }

        [ActionName("Home")]
        public ActionResult Home()
        {
            ViewBag.datenow = $"{DateTime.Now:yyyy-MM-dd}";
            return View(_l.GetAllLocations());
        }

        public ActionResult AboutUs()
        {
            return View();
        }

        public ActionResult Map()
        {
            return View();
        }

    }
}
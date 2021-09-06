using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WasteManagement.Controllers
{
    public class LocationsController : Controller
    {
        BusinessLogic.Locations _l;

        public LocationsController()
        {
            _l = new BusinessLogic.Locations();
        }

        // GET: Locations
        public ActionResult Index()
        {
            Models.LocationsIndexViewModel l = new Models.LocationsIndexViewModel()
            {
                Locations = _l.GetAllLocations(),
                Location = new Models.Locations()
            };

            return View(l);
        }
    }
}
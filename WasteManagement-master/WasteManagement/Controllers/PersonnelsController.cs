using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WasteManagement.Models;

namespace WasteManagement.Controllers
{
    public class PersonnelsController : Controller
    {
        WasteManagement.BusinessLogic.Personnels _p;

        public PersonnelsController()
        {
            _p = new BusinessLogic.Personnels();
        }

        // GET: Personnels
        public ActionResult Index()
        {
            PersonnelsIndexViewModel p = new PersonnelsIndexViewModel()
            {
                Personnels = _p.GetAllPersonnels(),
                Personnel = new Personnels()
            };

            return View(p);
        }

        [HttpPost]
        public ActionResult Create(Personnels p)
        {
            return _p.InsertPersonnel(p) 
                ? RedirectToAction("Index", "Personnels")
                :RedirectToAction("Index", "Personnels");   // Should be an error message 
        }

        [HttpPost]
        public ActionResult Update(Personnels p)
        {
            return _p.UpdatePersonnel(p)
                ? RedirectToAction("Index", "Personnels")
                : RedirectToAction("Index", "Personnels");   // Should be an error message 
        }

        [HttpPost]
        public ActionResult Delete(Personnels p)
        {
            return _p.DeletePersonnel(p)
                ? RedirectToAction("Index", "Personnels")
                : RedirectToAction("Index", "Personnels");   // Should be an error message 
        }
    }
}
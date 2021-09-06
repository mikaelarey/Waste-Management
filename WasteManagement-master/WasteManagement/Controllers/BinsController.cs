using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WasteManagement.Models;

namespace WasteManagement.Controllers
{
    public class BinsController : Controller
    {
        BusinessLogic.Locations _l;


        public BinsController()
        {
            _l = new BusinessLogic.Locations();
        }

        public ActionResult Index()
        {
            return View(_l.GetAllLocations());
        }


        //tbl_Bin mod = new tbl_Bin();
        //public ActionResult Index(string Search = "")
        //{
        //    var list = mod.List_tbl_Bin();
        //    return View(list);
        //}
        //public ActionResult Create()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Create(tbl_Bin m)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        mod.Create(m);
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}
        //public ActionResult Edit(int ID)
        //{
        //    var item = mod.Find_tbl_Bin(ID);
        //    return View(item);
        //}
        //[HttpPost]
        //public ActionResult Edit(tbl_Bin m)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        mod.Update(m);
        //        return RedirectToAction("Index");
        //    }
        //    return View(m);
        //}
        //public ActionResult Detail(int ID)
        //{
        //    var item = mod.Find_tbl_Bin(ID);
        //    return View(item);
        //}
        //public ActionResult Delete(int ID)
        //{
        //    var item = mod.Find_tbl_Bin(ID);
        //    return View(item);
        //}
        //[HttpPost]
        //public ActionResult Delete(tbl_Bin m)
        //{
        //    m.Delete(m);
        //    return RedirectToAction("Index");
        //}


    }
}
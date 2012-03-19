using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yame.Core;
using Yame.Models.Domain;

namespace Yame.Web.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Admin/Home/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Admin/Home/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Admin/Home/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/Home/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Admin/Home/Edit/5

        public ActionResult Edit(Guid id)
        {
            return View();
        }

        //
        // POST: /Admin/Home/Edit/5

        [HttpPost]
        public ActionResult Edit(Product p)
        {
            try
            {
                if( !ModelState.IsValid )
                {
                    return View();
                }
                return Content(String.Format("{0}", p.Discontinued));
                // TODO: Add update logic here

                //return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Admin/Home/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Admin/Home/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

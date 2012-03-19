using System;
using System.Web.Mvc;
using System.Linq;
using Yame.Core;
using Yame.Models.Domain;
using Microsoft.Web.Mvc;
using System.Collections.Generic;

namespace Yame.Web.Controllers
{
    public class WorkController : Controller
    {
        private IProductRepository productRepository;

        public WorkController(IProductRepository workRepository)
        {
            this.productRepository = workRepository;
        }
        //
        // GET: /Work/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Work/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // POST: /Work/Create
        [AcceptAjax, AuthorizeUser]
        public ActionResult Create(Product product)
        {
            if( !ModelState.IsValid )
            {
                var d = new Dictionary<String, String>();
                foreach( KeyValuePair<string, ModelState> item in ModelState )
                {
                    var error = item.Value.Errors.FirstOrDefault();
                    if( error != null )
                    {
                        d.Add(item.Key, error.ErrorMessage);
                    }
                }
                return this.JsonNet(d);
            }
            product.Name += "|Json";
            return this.JsonNet(product);
        }

        //
        // GET: /Work/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Work/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Work/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Work/Delete/5

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

using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Yame.Core;
using Yame.Models.Domain;

namespace Yame.Web.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository productRepository;

        /// <summary>
        /// 
        /// </summary>
        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        //
        // GET: /Admin/Product/

        public ActionResult Index()
        {
            IList<Product> list = productRepository.GetAll();
            return View(list);
        }

        //
        // GET: /Admin/Product/Details/5

        public ActionResult Details(Guid id)
        {
            Product product = productRepository.GetById(id);
            if( product == null )
            {
                return View("ProductNotFound", id);
            }
            return View(product);
        }

        //
        // GET: /Admin/Product/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/Product/Create

        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
                //如果用户输入不正确
                if( !ModelState.IsValid )
                {
                    return View();
                }

                productRepository.Add(product);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Admin/Product/Edit/5

        public ActionResult Edit(Guid id)
        {
            Product product = productRepository.GetById(id);
            if( product == null )
            {
                return View("ProductNotFound", id);
            }

            return View(product);
        }

        //
        // POST: /Admin/Product/Edit/5

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            try
            {
                //如果用户输入不正确
                if( !ModelState.IsValid )
                {
                    return View();
                }

                Product productFromDb = productRepository.GetById(product.Id);
                if( productFromDb == null )
                {
                    return View("ProductNotFound", product.Id);
                }

                productFromDb.Name = product.Name;
                productFromDb.Category = product.Category;
                productFromDb.Discontinued = product.Discontinued;

                productRepository.Update(productFromDb);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // POST: /Admin/Product/Delete/5

        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            JsonResultModel jrm = this.HandlerInvokeMethod(r =>
            {
                Product product = this.productRepository.GetById(id);
                if( product == null )
                {
                    throw new InformationException("记录不存在，删除失败！");
                }

                productRepository.Delete(id);
            });

            return Json(jrm);
        }
    }
}

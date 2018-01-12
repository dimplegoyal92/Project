using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Models;
using Kendo.Mvc.UI;


namespace Project.Controllers
{
    public class ProductController : Controller
    {
        private ProjectContext projectContext = null;
        public ProductController()
        {
            projectContext = new ProjectContext();

        }
        // GET: Product
        public ActionResult Index()
        {
            List<Products> listProducts = projectContext.Products.ToList();
            ////ViewBag.Products = listProducts;
            //return Json(new { list = listProducts }, JsonRequestBehavior.AllowGet);
            return View(listProducts);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Products products)
        {
            if (ModelState.IsValid)
            {
                projectContext.Products.Add(products);
                projectContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                var errors = ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .Select(x => new { x.Key, x.Value.Errors })
                    .ToArray();
                return View("Index");
            }
        }


        public ActionResult Edit(int id)
        {
            var prod = (from products in projectContext.Products where products.ProductId == id select products).ToList().FirstOrDefault();
            return View(prod);
        }

        [HttpPost]
        public ActionResult Edit(int id, Products products)
        {
            if (ModelState.IsValid)
            {
                products.ProductId = id;
                //var prod = from prducts in projectContext.Products where prducts.ProductId == id select products;
                projectContext.Entry(products).State = System.Data.Entity.EntityState.Modified;

                projectContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Index");
            }
        }
        public ActionResult Delete(int id, Products product)
        {
            product.ProductId = id;
            projectContext.Entry(product).State = System.Data.Entity.EntityState.Deleted;
            projectContext.SaveChanges();
            List<Products> listProducts = projectContext.Products.ToList();
            return View("Index", listProducts);

        }


    }
}
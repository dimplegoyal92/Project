using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Models;

namespace Project.Controllers
{
    public class SubCategoryController : Controller
    {
        private ProjectContext projectContext = null;
        public SubCategoryController()
        {
            projectContext = new ProjectContext();
        }
        // GET: SubCategory
        public ActionResult Index()
        {
            List<SubCategory> subcat = projectContext.SubCategory.ToList();
            return View(subcat);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(SubCategory sc)
        {
            if (ModelState.IsValid)
            {
                projectContext.SubCategory.Add(sc);
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
            var prod = (from products in projectContext.SubCategory where products.SubCategoryId == id select products).ToList().FirstOrDefault();
            return View(prod);
        }

        [HttpPost]
        public ActionResult Edit(int id, SubCategory sc)
        {
            if (ModelState.IsValid)
            {
                sc.SubCategoryId = id;
                //var prod = from prducts in projectContext.Products where prducts.ProductId == id select products;
                projectContext.Entry(sc).State = System.Data.Entity.EntityState.Modified;
                projectContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View("Index");
        }

        public ActionResult Delete(int id, SubCategory sc)
        {
            if (!CheckValidation(id))
            {
                sc.SubCategoryId = id;
                projectContext.Entry(sc).State = System.Data.Entity.EntityState.Deleted;
                projectContext.SaveChanges();
                List<SubCategory> listSubCat = projectContext.SubCategory.ToList();
                return View("Index", listSubCat);
            }
            else
                return Content("Can't be deleted");
        }
        public bool CheckValidation(int id)
        {
            var vc = new ValidationsController();
            bool check = vc.DeleteSubCategory(id);
            return check;
        }
    }
}
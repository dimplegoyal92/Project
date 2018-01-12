using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class PrimaryController : Controller
    {
        private ProjectContext projectContext = null;
        public PrimaryController()
        {
            projectContext = new ProjectContext();
        }
        // GET: SubCategory
        public ActionResult Index()
        {
            List<PrimaryCategory> primarycat = projectContext.PrimaryCat.ToList();
            return View(primarycat);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(PrimaryCategory Pc)
        {
            if (ModelState.IsValid)
            {
                projectContext.PrimaryCat.Add(Pc);
                projectContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(int id, PrimaryCategory pc)
        {
            if (ModelState.IsValid)
            {
                pc.PrimaryCategoryId = id;
                projectContext.Entry(pc).State = System.Data.Entity.EntityState.Modified;
                projectContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Delete(int id, PrimaryCategory pc)
        {
            if (!CheckValidation(id))
            {
                pc.PrimaryCategoryId = id;
                projectContext.Entry(pc).State = System.Data.Entity.EntityState.Deleted;
                projectContext.SaveChanges();
                List<PrimaryCategory> PrimCat = projectContext.PrimaryCat.ToList();
                return View("Index", PrimCat);
            }
            else
                return Content("Can't be deleted");
        }
        public bool CheckValidation(int id)
        {
            var vc = new ValidationsController();
            bool check = vc.DeletePrimaryCategory(id);
            return check;
        }
    }
}
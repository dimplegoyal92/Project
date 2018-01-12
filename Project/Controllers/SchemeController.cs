using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Models;

namespace Project.Controllers
{
    public class SchemeController : Controller
    {
        private ProjectContext projectContext = null;
        public SchemeController()
        {
            projectContext = new ProjectContext();
        }
        // GET: Scheme
        public ActionResult Index()
        {
            List<Schemes> list = projectContext.Schemes.ToList();
            return View(list);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Schemes sc)
        {
            try
            {
                projectContext.Schemes.Add(sc);
                projectContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
    public class CheckSchemeLevel
    {
        private ProjectContext projectContext = null;
        public CheckSchemeLevel()
        {
            projectContext = new ProjectContext();
        }
        public void ApplyScheme(Schemes sc)
        {
            var list = sc.SchemeLevel;
            int schemeLevel = list.First();
            list.Remove(list[0]);
            if (schemeLevel == 1)
            {
                bool success = schemeforPrimary(list);
            }
            else if (schemeLevel == 2)
            {
                bool success = schemeforSubCategory(list);
            }
            else if (schemeLevel == 3)
            {
                bool success = schemeforproducts(list);
            }

        }
        public bool schemeforPrimary(List<int> pc)
        {
            foreach(var pID in pc)
            {
                var subcat = getSubcategory(pID);
                foreach(var sub in subcat)
                {
                    if(sub.SchemeId != null)
                    {
                        return true;
                    }
                }
            }
            return false;

        }
        public bool schemeforSubCategory(List<int> sc)
        {
            //foreach (var pID in sc)
            //{
            //    var subcat = getProducts(pID);
            //    foreach (var sub in subcat)
            //    {
            //        if (sub.SchemeId != null)
            //        {
            //            return true;
            //        }
            //    }
            //}
            return false;
        }
        public bool schemeforproducts(List<int> products)
        {
            return false;
        }

        public List<SubCategory> getSubcategory(int id)
        {
            var subList = (from cats in projectContext.SubCategory where cats.PrimaryCategoryId == id select cats).ToList();
            return subList;
        }


    }
}
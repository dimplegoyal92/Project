using Project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

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
                if (ModelState.IsValid)
                {
                    projectContext.Schemes.Add(sc);
                    projectContext.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public ActionResult Edit(int id)
        {
            var scheme = (from schemes in projectContext.Schemes where schemes.SchemeId == id select schemes).ToList().FirstOrDefault();
            return View(scheme);
        }

        [HttpPost]
        public ActionResult Edit(int id, Schemes scheme)
        {
            if (ModelState.IsValid)
            {
                var sch = (from schemes in projectContext.Schemes where schemes.SchemeId == id select schemes).ToList().FirstOrDefault();
                sch.SchemeLevel = scheme.SchemeLevel;
                projectContext.Entry(sch).State = EntityState.Modified;
                projectContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                var errors = ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .Select(x => new { x.Key, x.Value.Errors })
                    .ToArray();
                return View();
            }
        }

    }
    //public class CheckSchemeLevel
    //{
    //    private ProjectContext projectContext = null;
    //    public CheckSchemeLevel()
    //    {
    //        projectContext = new ProjectContext();
    //    }
    //    public void ApplyScheme(Schemes sc)
    //    {
    //        List<string> list = sc.SchemeLevel.Split(',').ToList();
    //        string schemeLevel = list.First();
    //        list.Remove(list[0]);
    //        if (schemeLevel == "1")
    //        {
    //            //bool success = schemeforPrimary(sc.SchemeLevel,list);
    //            //if (success)
    //            //{
    //            //    foreach (var pc in list)
    //            //    {
    //            //        var subcatList = (from subcat in projectContext.SubCategory
    //            //                          where subcat.PrimaryCategoryId == Convert.ToInt32(pc)
    //            //                          select subcat).ToList();
    //            //        foreach(var subcat in subcatList)
    //            //        {
    //            //            var prodlist = (from prods in projectContext.Products
    //            //                              where prods.SubCategoryId == Convert.ToInt32(pc)
    //            //                              select subcat).ToList();
    //            //        }

                        
    //            //    }
    //            //}
    //            foreach(var pc in list)
    //            {
    //                var primaryCat = (from prim in projectContext.SubCategory
    //                                  where prim.PrimaryCategoryId == Convert.ToInt32(pc)
    //                                  select prim).ToList();

    //            }
    //        }
    //        else if (schemeLevel == "2")
    //        {
    //            //bool success = schemeforSubCategory(sc.SchemeLevel, list);
    //        }
    //        else if (schemeLevel == "3")
    //        {
    //            //bool success = schemeforproducts(sc.SchemeLevel, list);
    //        }

    //    }
    //    //public bool schemeforPrimary(string id, List<string> list)
    //    //{
    //    //    var subcats = (from subcat in projectContext.SubCategory
    //    //                   where subcat.SchemeId == Convert.ToInt32(id)
    //    //                   select subcat.SubCategoryId).ToList();
    //    //    var prods = (from prod in projectContext.Products
    //    //                 where prod.SchemeId == Convert.ToInt32(id)
    //    //                 select prod.ProductId).ToList();
    //    //    if(subcats is null && prods is null)
    //    //    {
    //    //        return true;
    //    //    }
    //    //    else
    //    //    {
    //    //        return false;
    //    //    }

            

    //    //}
    //    //public bool schemeforSubCategory(string id, List<string> list)
    //    //{
    //    //    //foreach (var pID in sc)
    //    //    //{
    //    //    //    var subcat = getProducts(pID);
    //    //    //    foreach (var sub in subcat)
    //    //    //    {
    //    //    //        if (sub.SchemeId != null)
    //    //    //        {
    //    //    //            return true;
    //    //    //        }
    //    //    //    }
    //    //    //}
    //    //    return false;
    //    //}
    //    //public bool schemeforproducts(string id, List<string> list)
    //    //{
    //    //    return false;
    //    //}

    //    //public List<SubCategory> getSubcategory(int id)
    //    //{
    //    //    var subList = (from cats in projectContext.SubCategory where cats.PrimaryCategoryId == id select cats).ToList();
    //    //    return subList;
    //    //}


    //}
}
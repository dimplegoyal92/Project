using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class ValidationsController : Controller
    {
        private ProjectContext projectContext = null;
        public ValidationsController()
        {
            projectContext = new ProjectContext();

        }
        // GET: Validations
        public bool DeletePrimaryCategory(int id)
        {
            var pc = (from primCat in projectContext.SubCategory where primCat.PrimaryCategoryId == id select primCat).ToList().FirstOrDefault();
            if (pc==null)
            {
                return false;
            }
            return true;
        }
        public bool DeleteSubCategory(int id)
        {
            var sc = (from prod in projectContext.Products where prod.SubCategoryId == id select prod).ToList().FirstOrDefault();
            if (sc == null)
            {
                return false;
            }
            return true;
        }
    }
}
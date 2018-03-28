using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HDDecisionsPractical.Controllers
{
    public class DataBaseController : Controller
    {
        private DataBaseContext context = new DataBaseContext();
        // GET: DataBase
        public ActionResult DataBase()
        {
            //returns a view that will display the whole data base.
            var viewDataBase = context.Applicants.ToList();
            return View(viewDataBase);
        }
    }
}
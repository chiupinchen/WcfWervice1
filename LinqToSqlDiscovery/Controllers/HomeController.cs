using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinqToSqlDiscovery.Controllers
{
    public class HomeController : Controller
    {

        CoreDataContext context = new CoreDataContext();
        public ActionResult Index()
        {
            var persons = context.Persons.Where(p=>p.FirstName.Contains("chiupin"));

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
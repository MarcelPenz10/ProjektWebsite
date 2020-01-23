using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Projekt.Models.UserScripts;

namespace Projekt.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {          
            return View();
        }

        public ActionResult Contact()
        {
            Kontakt p = new Kontakt("Firma", "Funpark", new Address("Straße", 12, 36553, "IBK"), "firma@icloud.com"); 

            return View(p);           
        }
    }
}
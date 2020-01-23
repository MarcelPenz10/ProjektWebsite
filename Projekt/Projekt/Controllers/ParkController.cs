using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projekt.Controllers
{
    public class ParkController : Controller
    {
        public ActionResult Index()
        {
            return View ();
        }
        public ActionResult ShowOnePark()
        {
            return View();
        }
    }
}

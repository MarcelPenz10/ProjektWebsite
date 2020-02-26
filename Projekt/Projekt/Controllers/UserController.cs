using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projekt.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            return View ();
        }
        [HttpGet] 
        public ActionResult Login()
        {
            return View();
        }
    }
}

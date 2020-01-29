using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projekt.Models.DB;

namespace Projekt.Controllers
{
    public class ParkController : Controller
    {
        IUser user = new UserDB(); 

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

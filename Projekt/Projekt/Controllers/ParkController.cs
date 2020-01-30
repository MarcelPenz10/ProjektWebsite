using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projekt.Models.DB;
using Projekt.Models;

namespace Projekt.Controllers
{
    public class ParkController : Controller
    {
        IUser user = new UserDB();
        IPark park = new ParkDB();

        public ActionResult Index()
        {
            park.Open();
            List<Park> parks = park.GetAllSnowparks();
            park.Close();
            return View (parks);
        }
        public ActionResult ShowOnePark(int id)
        {
            park.Open();
            Park onepark = park.GetOneSnowpark(id);
            park.Close();
            return View(onepark);
        }
    }
}

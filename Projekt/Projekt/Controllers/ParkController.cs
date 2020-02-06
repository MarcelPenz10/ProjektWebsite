using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projekt.Models.DB;
using Projekt.Models;
using System.IO;

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
            DirectoryInfo Images = CountFiles(onepark.Name);
            FileInfo[] files = Images.GetFiles();

            ParkViewModel pVM = new ParkViewModel(onepark, Images, files);
            return View(pVM);
        }
        private static DirectoryInfo CountFiles(string path)
        {
            DirectoryInfo di = new DirectoryInfo("/Content/Media2/Images/" + path);
            return di;
        }
    }
}

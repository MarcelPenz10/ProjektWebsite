using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projekt.Models.DB;
using Projekt.Models;
using Projekt.Models.UserScripts;
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
        [HttpGet]
        public ActionResult ShowOnePark(int id)
        {
            park.Open();
            Park onepark = park.GetOneSnowpark(id);
            park.Close();
            DirectoryInfo Images = CountFiles(onepark.Name);
            FileInfo[] files = Images.GetFiles();

            ParkViewModel pVM = new ParkViewModel(onepark, Images, files, "");
            Session["ParkId"] = onepark.ParkId;
            return View(pVM);
        }
        private static DirectoryInfo CountFiles(string path)
        {
            DirectoryInfo di = new DirectoryInfo("Content/Media/Images/" + path);
            return di;
        }
        [HttpPost]
        public ActionResult ShowOnePark(ParkViewModel parkViewModel)
        {
            User u = Session["loggedInUser"] as User;
            Comments c = new Comments(null, (int)Session["ParkId"], u.UserId, parkViewModel.NewComment, u.Username);
            park.Open();
            park.AddComment(c);
            Park onepark = park.GetOneSnowpark((int)Session["ParkId"]);
            park.Close();
            DirectoryInfo Images = CountFiles(onepark.Name);
            FileInfo[] files = Images.GetFiles();

            ParkViewModel pVM = new ParkViewModel(onepark, Images, files, "");
            Session["ParkId"] = onepark.ParkId;
            return View(pVM);
        }
        [HttpPost]
        public ActionResult DeleteComment(int Commentid) 
        {
            park.Open();
            Park onepark = park.GetOneSnowpark((int)Session["ParkId"]);
            park.DeleteComment(Commentid);
            park.Close();
            DirectoryInfo Images = CountFiles(onepark.Name);
            FileInfo[] files = Images.GetFiles();

            ParkViewModel pVM = new ParkViewModel(onepark, Images, files, "");
            Session["ParkId"] = onepark.ParkId;
            return RedirectToAction("ShowOnePark", new { id = onepark.ParkId });
        }
    }
}

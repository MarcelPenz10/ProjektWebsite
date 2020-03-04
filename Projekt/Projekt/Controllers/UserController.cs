using System;
using System.Web.Mvc;
using Projekt.Models.UserScripts;
using Projekt.Models.DB;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Text;

namespace Projekt.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User u)
        {
            if (u == null)
            {
                return View(u);
            }
            UserDB repUsers = new UserDB();
            try
            {
                repUsers.Open();
                User user = repUsers.Login(u);
                if (user.UserId != 0)
                { 
                    Session["loggedInUser"] = user;
                    return RedirectToAction("Index", "Park");
                }
                repUsers.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return View();
        }
        [HttpGet]
        public ActionResult Registration()
        {
            User u = new User();
            return View(u);
        }

        [HttpPost]
        public ActionResult Registration(User personDataFromForm)
        {
            if (personDataFromForm != null)
            {
                if (ModelState.IsValid)
                {
                    UserDB repUsers = new UserDB();

                    try
                    {
                        repUsers.Open();
                        if (repUsers.Insert(personDataFromForm))
                        {
                            User user = repUsers.Login(personDataFromForm);
                            Session["loggedInUser"] = user;
                            return RedirectToAction("Index", "Park");
                        }
                    }
                    catch (MySqlException)
                    {
                        return View(personDataFromForm);
                    }
                    catch (Exception)
                    {
                        return View(personDataFromForm);
                    }
                    finally
                    {
                        repUsers.Close();
                    }
                }
                else
                {
                    return View(personDataFromForm);
                }
            }
            return View(personDataFromForm);
        }
    }
}

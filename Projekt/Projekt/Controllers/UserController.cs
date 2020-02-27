using System;
using System.Web.Mvc;
using Projekt.Models.UserScripts;
using Projekt.Models.DB;
using MySql.Data.MySqlClient;

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
                if (user != null)
                {
                    if (user.Password == u.Password)
                    {
                        Session["loggedInUser"] = u;
                        return View("Index", "Park");
                    }
                }
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
                            Session["loggedInUser"] = personDataFromForm;
                            return View("~/Views/Park/Index.cshtml");
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

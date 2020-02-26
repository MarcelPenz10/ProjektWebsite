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
            return View ();
        }
        public ActionResult Login()
        {
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
                            return View("Message", new Message("Registierung", "Sie wurden erfolgreich registriert."));
                        }
                        else
                        {
                            return View("Message", new Message("Registierung", "Sie konnten nicht registriert werden."));
                        }
                    }
                    catch (MySqlException)
                    {
                        return View("Message", new Message("Datenbankfehler", "Es gibt zur Zeit Probleme mit der Datenbank."));
                    }
                    catch (Exception)
                    {
                        return View("Message", new Message("Allgemeiner Fehler", "Es ist ein allgemeiner Fehler aufgetreten."));
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
        }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Projekt.Models;
using Projekt.Models.DB;
using Projekt.Models.UserScripts;

namespace Projekt.Controllers
{
    public class AdminController : Controller
    {

        IUser rep;

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Users()
        {
            List<User> users;

            rep = new UserDB();
            rep.Open();

            users = rep.GetAllUser();
            rep.Close();

            return View(users);
        }

        
        public ActionResult Delete(int UserId)
        {
            rep = new UserDB();
            rep.Open();

            if (rep.Delete(UserId))
            {
                rep.Close();
                return View("Message", new Message("User löschen", "Benutzer wurde erfolgreich gelöscht!"));
            }
            else
            {
                rep.Close();
                return View("Message", new Message("User löschen", "Benutzer konnte nicht gelöscht werden!"));
            }

        }

    }
}
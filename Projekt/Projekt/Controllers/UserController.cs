using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Projekt.Models.UserScripts;

namespace Projekt.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View(new User());
        }

        [HttpPost]
        public ActionResult Registration(User user)
        {
            
            if (user == null)
            {
                return RedirectToAction("Registration");
            }

            CheckUserData(user);

            if (!ModelState.IsValid)
            {
                return View(user);
            }
            else
            {
                return View("Message", new Message("Registrierung", "Ihre Daten wurden erfolgreich abgespeichert"));
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        private void CheckUserData(User user)
        {
            if (user == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(user.Lastname.Trim()))
            {
                ModelState.AddModelError("Lastname", "Nachname ist ein Pflichtfeld.");
            }

            if (user.Gender == Gender.notSpecified)
            {
                ModelState.AddModelError("Gender", "Bitte wählen Sie das Geschlecht aus.");
            }

            if (string.IsNullOrEmpty(user.Username.Trim()))
            {
                ModelState.AddModelError("Username", "Benutzername ist ein Pflichtfeld.");
            }

      
            if (!CheckPassword(user.Password))
            {
                ModelState.AddModelError("Passwort", "Passwort muss mind. 8 Zeichen lang sein und mind. 1 Kleinbuchstabe, mind. 1 Großbuchstabe, mind. 1  SOnderzeichen enthalten");
            }
           
        }
        private bool CheckPassword(string password)
        {
            string pwd = password.Trim();
            if (password.Trim().Length < 8)
            {
                return false;
            }

            if (!PasswordContainsCountLowercaseCharacters(pwd, 1))
            {
                return false;
            }
            if (!PasswordContainsCountUppercaseCharacters(pwd, 1))
            {
                return false;
            }
            if (!PasswordContainsCountSpecialCharacters(pwd, 1))
            {
                return false;
            }
            return true;
        }

        private bool PasswordContainsCountLowercaseCharacters(string text, int minCount)
        {
            int count = 0;
            foreach (char c in text)
            {
                
                if (char.IsLower(c))
                {
                    
                    count++;
                }

            }
            return count >= minCount;
        }

        private bool PasswordContainsCountUppercaseCharacters(string text, int minCount)
        {
            int count = 0;
            foreach (char c in text)
            {
                
                if (char.IsUpper(c))
                {
                    
                    count++;
                }

            }
            return count >= minCount;
        }

        private bool PasswordContainsCountSpecialCharacters(string text, int minCount)
        {
            string allowedChars = "!§$%&/()[]{}=?'*+#€^°;:,.-_\"'\\";
            int count = 0;
            foreach (char c in text)
            {
                
                if (allowedChars.Contains(c))
                {
                   
                    count++;
                }

            }
            return count >= minCount;
        }


    


    }
}
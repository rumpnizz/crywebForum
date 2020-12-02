using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using cryWeb.ViewModels;
using cryWeb.DataContext;
using cryWeb.Extensions;
using cryWeb.Models;

namespace cryWeb.Controllers
{
    public class AccountController : Controller
    {
        [HttpPost]
        public ActionResult LogOn(string Username, string Password, string url)
        {
            AuthenticationExtensions.SignIn(Username, Password);

            return Redirect(url);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            AuthenticationExtensions.Register(user);

            return RedirectToAction("Index", "Home");
        }

    }
}

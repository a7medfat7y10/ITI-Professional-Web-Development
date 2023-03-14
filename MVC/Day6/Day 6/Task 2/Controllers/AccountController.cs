using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Task_2.Models;

namespace Task_2.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Client Client)
        {
            if (ModelState.IsValid)
            {
                MainDbContext context = new MainDbContext();
                context.Clients.Add(Client);
                context.SaveChanges();

                var ClientIdentity = new ClaimsIdentity(new List<Claim>()
                {
                    new Claim("Name", Client.Name),
                    new Claim(ClaimTypes.Email, Client.Email),
                    new Claim("Password", Client.Password)
                }, "AppCookie");

                // Owin authentication manager
                Request.GetOwinContext().Authentication.SignIn(ClientIdentity);

                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Client Client)
        {
            MainDbContext context = new MainDbContext();
            var loggedClient = context.Clients.FirstOrDefault(c => c.Email == Client.Email && c.Password == Client.Password);
            if(loggedClient != null) 
            {
                var signInIdentity = new ClaimsIdentity(new List<Claim>()
                {
                    new Claim(ClaimTypes.Email, Client.Email),
                    new Claim("Password", Client.Password)
                }, "AppCookie");

                // Owin authentication manager
                Request.GetOwinContext().Authentication.SignIn(signInIdentity);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("Name", "Client is not exsisted");
                return View();
            }
        }

        public ActionResult Logout()
        {
            Request.GetOwinContext().Authentication.SignOut("AppCookie");
            return RedirectToAction("Login");
        }
    }
}
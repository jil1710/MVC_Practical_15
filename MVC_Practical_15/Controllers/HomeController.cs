
using MVC_Practical_15.DataContext;
using MVC_Practical_15.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC_Practical_15.Controllers
{
    
    public class HomeController : Controller
    {
        UserDbContext _userDbContext = new UserDbContext();

        [HttpGet]
        public ActionResult Index()
        {
            return View(new Login());
        }

        [HttpPost]
        public ActionResult Index(Login user)
        {
            if(ModelState.IsValid)
            {
                var user1 = _userDbContext.Users.FirstOrDefault(x=> x.Email == user.Email && x.Password == user.Password);
                if(user1!=null)
                {
                    FormsAuthentication.SetAuthCookie(user.Email, user.RememberMe);
                    var ticket = new FormsAuthenticationTicket(1, user1.Email, DateTime.Now, DateTime.Now.AddSeconds(10),user.RememberMe,user1.Role);
                    var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));
                    HttpContext.Response.Cookies.Add(cookie);
                    if(user1.Role.Split(',').Contains("User")) {
                        return RedirectToAction("Users");
                    }
                    else
                    {
                        return RedirectToAction("Admin");
                    }
                }

            }
            ModelState.AddModelError("", "All fields are required!");
            return View(user);
        }


        [Authorize(Roles = "Admin")]
        public ActionResult Admin()
        {
            return View();
        }


        [Authorize(Roles = "User")]
        public ActionResult Users()
        {
            return View();
        }
        
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}
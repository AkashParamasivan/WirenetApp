using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WirenetApp.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        ElectricianServiceBookingEntities db = new ElectricianServiceBookingEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginI login)
        {
            try
            {
                ViewBag.Msg = "Username or password is incorrect";
                ServiceProvider user = db.ServiceProviders.SingleOrDefault(u => u.username == login.Username && u.Password == login.Password);
                User user1 = db.Users.SingleOrDefault(u=>u.Username==login.Username && u.Password==login.Password);

                if (user != null)
                {

                    if (user.username.StartsWith("SP"))
                    {
                        TempData["UserId"] = user1.Uid;
                        return RedirectToAction("ViewUserBookedDetails", "ProviderView");
                    }


                }
                else if (user1 != null)
                {
                    if (user1.Username.StartsWith("UI"))
                    {
                        TempData["UserId"] = user1.Uid;
                        return RedirectToAction( "ViewServiceProvider", "ServiceProviderDetails");
                    }
                }
            }
            catch
            {
                ViewBag.Message = "User Not Found !! Please Enter the correct Username and Password !!";
            }
            return View();
        }

       


    }
}
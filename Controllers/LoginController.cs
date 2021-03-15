using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WirenetApp.Controllers
{
    //[RoutePrefix("LoginAll")]
    public class LoginController : Controller
    {
        // GET: Login
        ElectricianServiceBookingEntities db = new ElectricianServiceBookingEntities();
        public ActionResult Index()
        {
            return View();
        }
        // [Route("LoginRoute")]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginI login)
        {
            if(login!=null)
            {
                try
                {
                    
                    ViewBag.Msg = "Username or password is incorrect";
                    ServiceProvider user = db.ServiceProviders.SingleOrDefault(u => u.username == login.Username && u.Password == login.Password);
                    User user1 = db.Users.SingleOrDefault(u => u.Username == login.Username && u.Password == login.Password);
                    adminE admin = db.adminEs.SingleOrDefault(u => u.Username == login.Username && u.Password == login.Password);
                    // TempData["UserIdU"] = user1.Uid;

                    if (user != null)
                    {

                        if (user.username.StartsWith("SP"))
                        {
                            Session["Serviceid"] = user.Sid;
                            //TempData["ServiceId"] = user.Sid;
                            Session["Username"] = user.FullName;
                            return RedirectToAction("ViewUserBookedDetails", "ProviderView", new { id = user.Sid });
                        }


                    }
                    else if (user1 != null)
                    {
                        if (user1.Username.StartsWith("UI"))
                        {
                            Session["Userid"] = user1.Uid;
                            TempData["UserId"] = user1.Uid;
                            Session["Username"] = user1.FullName;
                           
                            return RedirectToAction("ViewServiceProvider", "ServiceProviderDetails");
                        }
                    }
                    else if(admin!=null)
                    {
                        return RedirectToAction("Index","Admin");
                    }
                }
                catch
                {
                    ViewBag.Message = "User Not Found !! Please Enter the correct Username and Password !!";
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }




    }
}
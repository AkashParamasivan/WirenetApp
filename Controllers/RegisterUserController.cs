using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WirenetApp.Controllers
{
    public class RegisterUserController : Controller
    {
        // GET: RegisterUser

        ElectricianServiceBookingEntities db = new ElectricianServiceBookingEntities();
        public ActionResult Index()
        {
            return View();
        }

     
        public ActionResult RegisterUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterUser(User regs)
        {
            try
            {
                db.Users.Add(regs);
                db.SaveChanges();
                ViewBag.Message = "Successfully registered!";

            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }
            return View();
        }
    }
}
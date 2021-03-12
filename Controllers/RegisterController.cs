using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WirenetApp.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        ElectricianServiceBookingEntities db = new ElectricianServiceBookingEntities();
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(ServiceProvider service)
        {
            try
            {
                db.ServiceProviders.Add(service);
                db.SaveChanges();
                ViewBag.Message= "Successfully registered!";
               
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }
            return View();
        }
    }
}

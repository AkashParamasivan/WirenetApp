using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WirenetApp.Controllers
{
    public class UserServiceController : Controller
    {
        ElectricianServiceBookingEntities db = new ElectricianServiceBookingEntities();
        // GET: UserService
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UserService(int Sid, int Uid)
        {
            UserService service = new UserService();
            service.Uid = Uid;
            service.sid = Sid;
            return View(service);
        }
        [HttpPost]
        public ActionResult UserService(UserService service)
        {



            try
            {
                
                db.UserServices.Add(service);
                db.SaveChanges();
                ViewBag.Message = "Successfully booked!";

            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }
            return View();
        }
    }
}
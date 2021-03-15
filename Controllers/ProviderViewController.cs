using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WirenetApp.Controllers
{
    public class ProviderViewController : Controller
    {
        ElectricianServiceBookingEntities db = new ElectricianServiceBookingEntities();
        // GET: ProviderView
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewUserBookedDetails(int id)
        {
            if (Session["Serviceid"] != null)
            {
                List<User> users = new List<User>();
                UserService userservice = db.UserServices.SingleOrDefault(u => u.sid == id);
                if (userservice != null)
                {
                    users = db.Users.Where(u => u.Uid == userservice.Uid).ToList();
                    ViewBag.message = Session["Username"];
                    return View(users);
                }


                /* else
                 {
                     ViewBag.show = "No one has booked you";
                 }*/
                return View(users);
            }
            else
            {

                return RedirectToAction("Index", "Home");
            }
        }

    }
}
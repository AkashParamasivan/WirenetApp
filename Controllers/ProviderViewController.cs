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
        //public ActionResult ViewUserBookedDetails()
        //{
        //    return View();
        //}
        //[HttpGet]
        //public ActionResult ViewUserBookedDetails(UserService user)
        //{
        //    if (user.Uid == Convert.ToInt32(@TempData.Peek("UserId")))
        //    {
        //        var Data = db.Users.ToList();
        //        return View(Data);
               
        //    }
            
        //}
    }
}
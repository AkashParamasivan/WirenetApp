using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WirenetApp.Controllers
{
    public class ServiceProviderDetailsController : Controller
    {
        ElectricianServiceBookingEntities db = new ElectricianServiceBookingEntities();
        // GET: ServiceProviderDetails
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public  ActionResult ViewServiceProvider()
        {
            if (Session["Userid"] != null)
            {
                var Data = db.ServiceProviders.ToList();
                return View(Data);
            }
            else
            {

                return RedirectToAction("Index", "Home");
            }
        }
    }
}
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

        //public JsonResult GetSearchingData(string SearchBy,string SearchValue)
        //{
        //    List<ServiceProvider> services = new List<ServiceProvider>();
        //    if(SearchBy=="ID")
        //    {
        //        try
        //        {
        //            int Id = Convert.ToInt32(SearchValue);
        //            services = db.ServiceProviders.Where(x => x.Sid == Id || SearchValue == null).ToList();
        //        }
        //        catch(FormatException)
        //        {
        //            Console.WriteLine("{0} is Not a ID",SearchValue);
        //        }
        //        return Json(services, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        services = db.ServiceProviders.Where(x => x.Specialization.Contains(SearchValue)).ToList();
        //        return Json(services,JsonRequestBehavior.AllowGet);
        //    }
        //}
    }
}
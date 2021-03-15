using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WirenetApp.Controllers
{
    public class UniqueEIDController : Controller
    {
        ElectricianServiceBookingEntities db = new ElectricianServiceBookingEntities();
        // GET: UniqueEID
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult IsElectricianIDNameExist(string ElectricianID, int? id)
        {
            var validateName = db.ServiceProviders.FirstOrDefault(x => x.ElectricianID == ElectricianID && x.Sid != id);
            if (validateName != null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
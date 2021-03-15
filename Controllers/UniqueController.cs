using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WirenetApp.Controllers
{
    public class UniqueController : Controller
    {
        ElectricianServiceBookingEntities db = new ElectricianServiceBookingEntities();
        // GET: Unique
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult IsUserNameExist(string UserName, int? Id)
        {
            var validateName = db.Users.FirstOrDefault(x => x.Username == UserName && x.Uid != Id);
            if (validateName != null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult IsElectricianUserNameExist(string UserName, int? Id)
        {
            var validateName = db.ServiceProviders.FirstOrDefault(x => x.username == UserName && x.Sid != Id);
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WirenetApp.Controllers
{
    public class UpdateStatusController : Controller
    {
        ElectricianServiceBookingEntities db = new ElectricianServiceBookingEntities();
        // GET: Update
        public ActionResult Index()
        {
            return View();
        }
       
        public ActionResult UpdateBookingStatus(int id)
        {
            try
            {
                var data = db.UserServices.Where(x => x.Uid == id).SingleOrDefault();
                return View(data);
            }
            catch(Exception ex)
            {
                ViewBag.msg = ex.Message;
                return View();
            }
           
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateBookingStatus(int id, UserService model)
        {
            
           
                var data = db.UserServices.FirstOrDefault(x => x.Uid == id);

         
                if (data != null)
                {
                    data.BookingStatus = model.BookingStatus;
                    db.SaveChanges();

                    return RedirectToAction("UpdateBookingStatus","UpdateStatus");
                }
                else
                    return View();
            
        }
    }
}
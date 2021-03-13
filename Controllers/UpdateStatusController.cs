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

                var data = db.UserServices.Where(x => x.Uid == id).SingleOrDefault();
                return View(data);
           
        }

        // To specify that this will be  
        // invoked when post method is called 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateBookingStatus(int id, UserService model)
        {
            
                // Use of lambda expression to access 
                // particular record from a database 
                var data = db.UserServices.FirstOrDefault(x => x.Uid == id);

                // Checking if any such record exist  
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
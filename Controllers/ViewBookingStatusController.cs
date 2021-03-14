using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WirenetApp.Controllers
{
    
    public class ViewBookingStatusController : Controller
    {
        ElectricianServiceBookingEntities db = new ElectricianServiceBookingEntities();
        // GET: ViewBookingStatus
        public ActionResult Index()
        {
            return View();
        }
        //[HttpGet]
        //public ActionResult ViewBookingStatus()
        //{
        //    var data = db.UserServices.ToList();
        //    return View(data);

        //}

        public ActionResult ViewBookingStatus(int id)
        {
            
             UserService data = db.UserServices.Where(x => x.sid == id).SingleOrDefault();
            ViewBag.msg = "Updated Successfully!";
            return View(data);

        }

      
        
      /*
        public ActionResult ViewBookingStatus(int id, UserService model)
        {

            // Use of lambda expression to access 
            // particular record from a database 
            var data = db.UserServices.FirstOrDefault(x => x.sid == id);

            // Checking if any such record exist  
            if (data != null)
            {
                var data1 = db.UserServices.ToString();
                return View(data1);
            }
            else
                return View();

        }*/
    }
}
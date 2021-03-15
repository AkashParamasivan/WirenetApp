using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WirenetApp.Controllers
{
    //[RoutePrefix("Administrator")]
    public class AdminController : Controller
    {
        ElectricianServiceBookingEntities db = new ElectricianServiceBookingEntities();
        // GET: Admin
        [Route("Adminpage")]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AdminViewElectricain()
        {
            var Data = db.ServiceProviders.ToList();
            return View(Data);
        }
        public ActionResult AdminDeleteElectrician()
        {
            return View();
        }

        
    [HttpPost]
    //[ValidateAntiForgeryToken]
    public ActionResult AdminDeleteElectrician(int eid)
    {

        var data = db.ServiceProviders.FirstOrDefault(x => x.Sid == eid);
        if (data != null)
        {
            db.ServiceProviders.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        else
            return View();

    }

    [HttpGet]
        public ActionResult AdminViewUser()
        {
            var Data = db.Users.ToList();
            return View(Data);
        }

        public ActionResult AdminDeleteUser()
        {
            return View();
        }

        [HttpPost]
        
        public ActionResult AdminDeleteUser(int uid)
        {

            var data = db.Users.FirstOrDefault(x => x.Uid == uid);
            if (data != null)
            {
                db.Users.Remove(data);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View();

        }

        [HttpGet]
        public ActionResult AdminViewUserService()
        {
            var Data = db.UserServices.ToList();
            return View(Data);
        }

        public ActionResult AdminDeleteUserService()
        {
            return View();
        }

        [HttpPost]

        public ActionResult AdminDeleteUserService(int Sid)
        {

            var data = db.UserServices.FirstOrDefault(x => x.sid == Sid);
            if (data != null)
            {
                db.UserServices.Remove(data);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View();

        }

        public ActionResult UpdateElectricianDetails(int seid)
        {

            var data = db.ServiceProviders.Where(x => x.Sid == seid).SingleOrDefault();
            return View(data);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateElectricianDetails(int seid, ServiceProvider model)
        {

            var data = db.ServiceProviders.FirstOrDefault(x => x.Sid == seid);


            if (data != null)
            {
                data.FullName = model.FullName;
                data.Phoneno = model.Phoneno;
                data.Emailid = model.Emailid;
                data.Specialization = model.Specialization;
                data.experience = model.experience;
                data.rangeperhour = model.rangeperhour;
                db.SaveChanges();


                return RedirectToAction("Index");
            }
            else
                return View();
        }
    
}
}
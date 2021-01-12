using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xlkdma.Models;

namespace Xlkdma.Controllers
{
    public class registerController : Controller
    {
        // GET: register
        XlkhdmaContext db = new XlkhdmaContext();

        public ActionResult register()
        {

            return View();
        }
        [HttpPost]
        public ActionResult register(Customer c)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(c);
                db.SaveChanges();
                return RedirectToAction("test", "home");
            }
            else
            {

                return View(c);

            }
        }

        //public ActionResult registerW()
        //{
        //    List<Job> jb = db.Jobs.ToList();
        //    ViewBag.jobss = jb;
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult registerW(Worker w, HttpPostedFileBase photo)
        //{
        //    //if (ModelState.IsValid)
        //    //{
        //        photo.SaveAs(Server.MapPath("~/attach/" + photo.FileName));
        //         //var x = db.Workers.Max().workerId + 1;
        //        w.workerImage = photo.FileName;
        //        //w.workerId = x;
        //    db.Workers.Add(w);
        //        db.SaveChanges();
        //        return RedirectToAction("test","home");
        //    //}
        //    //else
        //    //{
        //    //    List<Job> jb = db.Jobs.ToList();
        //    //    ViewBag.jobss = jb;
        //    //return View(w);

        //}


        public ActionResult ChectexistCustomerPhone(long CustomerPhone)
        {
            Customer w = db.Customers.Where(n => n.customerPhone == CustomerPhone).FirstOrDefault();
            if (w == null)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);

            }
        }
        public ActionResult ChectexistcustomerEmail(string customerEmail)
        {
            Customer w = db.Customers.Where(n => n.customerEmail == customerEmail).FirstOrDefault();
            if (w == null)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);

            }
        }

        public ActionResult registerW()
        {
            List<Job> jb = db.Jobs.ToList();
            ViewBag.jobss = jb;
            return View();
        }
        [HttpPost]
        public ActionResult registerW(Worker w, HttpPostedFileBase photo)
        {

            if (ModelState.IsValid)
            {
                photo.SaveAs(Server.MapPath("~/attach/" + photo.FileName));
                //var x = db.Workers.Max().workerId + 1;
                w.workerImage = photo.FileName;
                //w.workerId = x;
                db.Workers.Add(w);
                db.SaveChanges();
                return RedirectToAction("test", "home");
            }
            else
            {
                List<Job> jb = db.Jobs.ToList();
                ViewBag.jobss = jb;
                return View(w);

            }
        }
        public ActionResult ChectexistWorkerSsn(long WorkerSsn)
        {
            Worker w = db.Workers.Where(n => n.workerSsn == WorkerSsn).FirstOrDefault();
            if (w == null)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);

            }
        }

        public ActionResult ChectexistWorkerPhone(long WorkerPhone)
        {
            Worker w = db.Workers.Where(n => n.workerPhone == WorkerPhone).FirstOrDefault();
            if (w == null)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);

            }
        }

    }
    }

using MVCLoginApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xlkdma.Models;

namespace Xlkdma.Controllers
{
    public class operationController : Controller
    {
        XlkhdmaContext db = new XlkhdmaContext();


        public ActionResult showorder(int id)
        {
            Worker w = db.Workers.Where(n => n.workerId == id).FirstOrDefault();
            List<Wait> lstwait = db.Waits.Where(n => n.workerSSN == w.workerSsn && n.accept != true && n.done != true).ToList();

            return View(lstwait);
        }
        public ActionResult confirmOrder()
        {
            return View();
        }
        [HttpPost]
        public ActionResult confirmOrder(int id, Wait waiting)
        {
            Wait w = db.Waits.Where(n => n.waitId == id).FirstOrDefault();
            w.waitAchievingTime = waiting.waitAchievingTime;
            w.accept = true;
            Order o = new Order();
            o.orderName = w.waitName;
            o.orderDesc = w.waitDesc;
            o.orderDate = w.waitDate;
            o.acheivingTime = w.waitAchievingTime;
            o.customerSsn = w.customerSSN;
            o.workerSsn = w.workerSSN;
            CustomerWorker cw = new CustomerWorker();
            cw.workerSsn = w.workerSSN;
            cw.customerSsn = w.customerSSN;
            cw.skill = w.waitName;
            db.Orders.Add(o);
            db.CustomerWorkers.Add(cw);
            //try
            //{
                db.SaveChanges();

            //}
            //catch(DbEntityValidationException e)
            //{
            //    Console.WriteLine(e);
            //}

            return RedirectToAction("showprofile", "operation", new { id = w.Worker.workerId });
        }
        public ActionResult executing(int id)
        {
            Worker w = db.Workers.Where(n => n.workerId == id).FirstOrDefault();
            Wait waiting = db.Waits.Where(n => n.workerSSN == w.workerSsn).FirstOrDefault();
            List<Wait> lstWait = db.Waits.Where(n => n.workerSSN == w.workerSsn && n.accept == true && n.done != true).ToList();
            return View(lstWait);

        }
        public ActionResult done(int id)
        {
            Done d = new Done();

            //Wait waiting = db.Waits.Where(n => n.workerSSN == w.workerSsn && n.accept == true).FirstOrDefault();
            Wait waiting = db.Waits.Where(n => n.waitId == id).FirstOrDefault();
            //ViewBag.workerid=w.workerId;
            waiting.done = true;
            int x = int.Parse(Session["userId"].ToString());
            Worker w = db.Workers.Where(n => n.workerId == x).FirstOrDefault();
            ViewBag.exeid = w.workerId;
            d.waitId = waiting.waitId;
            d.workerId = x;
            db.Dones.Add(d);
            db.SaveChanges();
            List<Done> ds = db.Dones.Where(n => n.workerId == x ).ToList();
            return View(ds);
            //done.waitId=waiting.waitId;
            //done.WID=x;
            //db.dones.Add(done);
            //db.SaveChanges();
            //list=>
            //List<Wait> lstWait = db.Waits.Where(n => n.Worker.workerId == x  && n.done==true).ToList();
            //return View(lstWait);

        }
        public ActionResult loginC()
        {
            if (Request.Cookies["kdma"] != null)
            {
                Session["userId"] = Request.Cookies["kdma"].Values["id"];
                return RedirectToAction("test", "home", new { id = Session["userId"].ToString() });
            }
            return View();
        }
        [HttpPost]
        public ActionResult loginC(loginDataCustomer loc, bool remember)
        {
            Customer c = db.Customers.Where(n => n.customerEmail == loc.userName && n.customerPassword == loc.password).FirstOrDefault();
            if (c != null)
            {
                if (remember)
                {
                    HttpCookie co = new HttpCookie("kdma");
                    co.Values.Add("id", c.customerId.ToString());
                    co.Values.Add("name", c.customerName);
                    co.Expires = DateTime.Now.AddDays(30);
                    Response.Cookies.Add(co);
                }
                Session["userId"] = c.customerId;
                return RedirectToAction("Cprofile", "operation", new {id=c.customerId });

            }
            else
            {
                ViewBag.mess = "الإسم أو كلمة المرور غير صحيحة";
                return View();

            }
        }

        public ActionResult Cprofile(int id)
        {
            Customer c = db.Customers.Where(n => n.customerId == id).FirstOrDefault();
            return View(c);
        }
        public ActionResult showprofile(int id)
        {
            Worker w = db.Workers.Where(n => n.workerId == id).FirstOrDefault();

            Job j = db.Jobs.Where(n => n.jobId == w.jobId).FirstOrDefault();
            ViewBag.dd = j.jobName;
            return View(w);
        }

        public ActionResult addkhdma()
        {
            return View();
        }
        [HttpPost]
        public ActionResult addkhdma(WorkerSkill ws, int id)
        {
            Worker w = db.Workers.Where(n => n.workerId == id).FirstOrDefault();
            ws.workerSsn = w.workerSsn;
                db.WorkerSkills.Add(ws);
                db.SaveChanges();
                return RedirectToAction("showprofile", "operation",new { id=w.workerId});


            
        }
        public ActionResult loginW()
        {

            if (Request.Cookies["kdma"] != null)
            {
                Session["userId"] = Request.Cookies["kdma"].Values["id"];
                return RedirectToAction("showprofile", "operation", new { id = Session["userId"].ToString() });
            }
            return View();
        }
        [HttpPost]
        public ActionResult loginW(loginData low, bool remember)
        {
            Worker w = db.Workers.Where(n => n.workerName == low.userName && n.workerPassword == low.password).FirstOrDefault();
            if (w != null)
            {
                if (remember)
                {
                    HttpCookie co = new HttpCookie("kdma");
                    co.Values.Add("id", w.workerId.ToString());
                    co.Values.Add("name", w.workerName);
                    co.Expires = DateTime.Now.AddDays(30);
                    Response.Cookies.Add(co);
                }

                Session["userId"] = w.workerId;
                return RedirectToAction("showprofile", "operation",new { id=w.workerId});

            }
            else
            {
                ViewBag.mess = "إسم المستخدم أو كلمة المرور غير صحيحة";
                return View();

            }
        }

        public ActionResult logout()
        {
            Session["userid"] = null;
            HttpCookie c = new HttpCookie("kdma");
            c.Expires = DateTime.Now.AddDays(-30);
            Response.Cookies.Add(c);
            return RedirectToAction("index", "home");
        }
        public ActionResult logoutW()
        {
            Session["userid"] = null;
            HttpCookie c = new HttpCookie("kdma");
            c.Expires = DateTime.Now.AddDays(-30);
            Response.Cookies.Add(c);
            return RedirectToAction("index","home");
        }

        public ActionResult editName()
        {
            return View();
        }

        [HttpPost]
        public ActionResult editName(EditedData ED)
        {

            int userid = int.Parse(Session["userid"].ToString());
            Customer ct = db.Customers.Where(n => n.customerId == userid).FirstOrDefault();
            ct.customerName = ED.customerName;
            ct.customerCity = ED.customerCity;
            ct.customerEmail = ED.customerEmail;
            ct.customerPhone = ED.customerPhone;
            db.SaveChanges();
            return RedirectToAction("Cprofile", "operation", new { id = Session["userId"].ToString() });

        }
        public ActionResult changedPassword()
        {

            return View();
        }
        [HttpPost]
        public ActionResult changedPassword(ChangePassword change)
        {
            int userid = int.Parse(Session["userId"].ToString());
            Customer c = db.Customers.Where(n => n.customerId == userid).FirstOrDefault();
            if (change.oldPassword== c.customerPassword)
            {
                c.customerPassword = change.newPassword;
                db.SaveChanges();
                return RedirectToAction("Cprofile", "operation", new { id = Session["userId"].ToString() });
            }

            else
            {
                ViewBag.mess = "كلمة المرور غير صحيحة";

                return View();
            }


        }
        public ActionResult WeditName()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WeditName(WeditedData wed)
        {

            int userid = int.Parse(Session["userid"].ToString());
            Worker wt = db.Workers.Where(n => n.workerId == userid).FirstOrDefault();
            wt.workerName = wed.workerName;
            wt.workerCity = wed.workerCity;
            wt.workerPhone = wed.workerPhone;
            wt.jobPrice = wed.jobPrice;
            wt.jobId = wed.jobId;
            db.SaveChanges();
            return RedirectToAction("showprofile", "operation", new { id = Session["userId"].ToString() });

        }
        public ActionResult WchangedPassword()
        {

            return View();
        }
        [HttpPost]
        public ActionResult WchangedPassword(ChangePassword change)
        {
            int userid = int.Parse(Session["userid"].ToString());
            Worker c = db.Workers.Where(n => n.workerId == userid).FirstOrDefault();
            if (int.Parse(change.oldPassword) == int.Parse(c.workerPassword))
            {
                c.workerPassword = change.newPassword;
                db.SaveChanges();
                return RedirectToAction("Cprofile", "operation", new { id = Session["userId"].ToString() });
            }

            else
            {
                ViewBag.mess = "كلمة المرور غير صحيحة";

                return View();
            }


        }
        public ActionResult WUploadedImage()
        {
            return View();
        }
        [HttpPost]

        public ActionResult WUploadedImage(HttpPostedFileBase photo)
        {
            photo.SaveAs(Server.MapPath("~/attach/" + photo.FileName));
            int userid = int.Parse(Session["userid"].ToString());
            Worker c = db.Workers.Where(n => n.workerId == userid).FirstOrDefault();
            c.workerImage = photo.FileName;
            db.SaveChanges();
            return RedirectToAction("showprofile", "operation", new { id = Session["userId"].ToString() });
        }




        public ActionResult showDoneWithCustomer(int id)
        {
            int x = int.Parse(Session["userId"].ToString());
            Customer c = db.Customers.Where(n => n.customerId == x).FirstOrDefault();
            List<Wait> waiting = db.Waits.Where(n => n.customerSSN == c.customerSsn && n.accept == true).ToList();
            return View(waiting);
        }
        public ActionResult showNotDoneYetWithCustomer(int id)
        {
            int x = int.Parse(Session["userId"].ToString());
            Customer c = db.Customers.Where(n => n.customerId == x).FirstOrDefault();
            List<Wait> waiting = db.Waits.Where(n => n.customerSSN == c.customerSsn && n.accept != true).ToList();
            return View(waiting);
        }
    }
}
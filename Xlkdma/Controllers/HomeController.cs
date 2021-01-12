using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Xlkdma.Models;
using System.Web.Mvc;
using System.Data.Entity.Validation;

namespace Xlkdma.Controllers
{

    public class HomeController : Controller
    {
        XlkhdmaContext db = new XlkhdmaContext();
        public ActionResult Index()
        {
            List<Job> jobs = db.Jobs.ToList();
            return View(jobs);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Work(int id)
        {
            List<Worker> workers = db.Workers.Where(n => n.jobId == id).ToList();
            return View(workers);
        }
        public ActionResult details(int id)
        {
            Worker w = db.Workers.Where(n => n.workerId == id).FirstOrDefault();
            List<WorkerSkill> workerSkills = db.WorkerSkills.Where(n => n.workerSsn == w.workerSsn).ToList();
            return View(workerSkills);
        }
        //public ActionResult order(int id)
        //{
        //    Worker w = db.Workers.Where(n => n.workerId == id).FirstOrDefault();
        //    List<WorkerSkill> skills = db.WorkerSkills.Where(n => n.workerSsn == w.workerSsn).ToList();
        //    SelectList workerSkill = new SelectList(skills, "workerSkill1", "workerSkill1");
        //    ViewBag.skill = workerSkill;
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult order(int id, Order o)
        //{
        //    Worker w = db.Workers.Where(n => n.workerId == id).FirstOrDefault();
        //    int x = int.Parse(Session["userId"].ToString());
        //    Customer c = db.Customers.Where(n => n.customerId == x).FirstOrDefault();
        //    CustomerWorker cW = new CustomerWorker();
        //    o.workerSsn = w.workerSsn;
        //    o.orderDate = DateTime.Now;
        //    o.customerSsn = x;
        //    cW.skill = o.orderName;
        //    cW.workerSsn = w.workerSsn;
        //    cW.customerSsn = x;
        //    ViewBag.wId = id;
        //    db.Orders.Add(o);
        //    db.CustomerWorkers.Add(cW);
        //    db.SaveChanges();
        //    return RedirectToAction("getNumber",new { id = ViewBag.wId});
        //}




        public ActionResult order(int id)
        {
            Worker w = db.Workers.Where(n => n.workerId == id).FirstOrDefault();
            List<WorkerSkill> skills = db.WorkerSkills.Where(n => n.workerSsn == w.workerSsn).ToList();
            SelectList workerSkill = new SelectList(skills, "workerSkill1", "workerSkill1");
            ViewBag.skill = workerSkill;
            return View();
        }





        [HttpPost]
        public ActionResult order(int id, Wait waiting)
        {


            Worker w = db.Workers.Where(n => n.workerId == id).FirstOrDefault();
            int x = int.Parse(Session["userId"].ToString());
            Customer c = db.Customers.Where(n => n.customerId == x).FirstOrDefault();
            waiting.waitDate = DateTime.Now;
            waiting.customerSSN = c.customerSsn;
            waiting.workerSSN = w.workerSsn;


            ViewBag.wId = id;
            db.Waits.Add(waiting);
            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }
            return RedirectToAction("getNumber", new { id = ViewBag.wId });

        }


        public ActionResult getNumber(int id )
        {
            Worker w = db.Workers.Where(n => n.workerId == id).FirstOrDefault();
            return View(w);
        }
        public ActionResult test()
        {
            return View();
        }

        public ActionResult log()
        {
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xlkdma.Models;

namespace Xlkdma.Controllers
{
    public class searchBoxController : Controller
    {
        XlkhdmaContext db = new XlkhdmaContext();
        // GET: searchBox
        public ActionResult search(string search)
        {
            
            List<Order> lor = db.Orders.Where(n => n.orderName.StartsWith(search)||search == null).ToList();
            //foreach (var item in lor)
            //{
            //    w
            //}
            //ViewBag.id=
            return View(lor);
        }
    }
}
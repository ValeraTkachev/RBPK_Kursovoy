using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TattooConsultant.Models;

namespace TattooConsultant.Controllers
{
    public class FullAccManController : Controller
    {
        //
        // GET: /FullAccMan/
        AccesoriesContext db = new AccesoriesContext();
        public ActionResult Index()
        {
            IEnumerable<Item> item = db.Items;
            ViewBag.Items = item;
            return View("Index");
        }

    }
}

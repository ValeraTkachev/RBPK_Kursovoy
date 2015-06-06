using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TattooConsultant.Models;

namespace TattooConsultant.Controllers
{
    public class FullAccWomanController : Controller
    {
        //
        // GET: /FullAccWoman/
        AccesoriesContext db = new AccesoriesContext();
        public ActionResult Index()
        {
            IEnumerable<Item> item = db.Items;
            ViewBag.Items = item;
            return View("Index");
        }

    }
}

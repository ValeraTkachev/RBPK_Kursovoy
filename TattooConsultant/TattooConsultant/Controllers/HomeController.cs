using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TattooConsultant.Models;

namespace TattooConsultant.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        AccesoriesContext db = new AccesoriesContext();
        public ActionResult Index()
        {
            IEnumerable<Item> acc = db.Items;
            ViewBag.Items = acc;
            return View();
        }

    }
}

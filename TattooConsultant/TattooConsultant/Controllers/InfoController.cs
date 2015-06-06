using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TattooConsultant.Models;

namespace TattooConsultant.Controllers
{
    public class InfoController : Controller
    {
        AccesoriesContext sh = new AccesoriesContext();
        //
        // GET: /AccInfo/
        [HttpGet]
        public ActionResult GoToUserWall(int id)
        {
            Item i = sh.Items.Find(id);

            if (i != null)
            {

                ViewBag.CurItem = i;

                return View("../Info/Info");
            }
            else
                return new HttpStatusCodeResult(404);
        }
    }
}

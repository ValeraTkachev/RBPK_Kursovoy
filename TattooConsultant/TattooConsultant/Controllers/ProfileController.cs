using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TattooConsultant.Models;
using System.Data;
using System.IO;
using System.Data.Entity;

namespace TattooConsultant.Controllers
{
    public class ProfileController : Controller
    {
        //
        // GET: /Profile/

        public ActionResult Index()
        {
            return View("Profile");
        }
        AccesoriesContext Sh = new AccesoriesContext();
        [HttpPost]
        public ActionResult Register(string name, string surname, string login, string oldpassword, string confirmpassword, string newpassword)
        {
            ViewBag.login = login;
            int id = Convert.ToInt32(Session["id"]);
            User U = Sh.Users.Where(u => u.Id == id).FirstOrDefault();
            if (oldpassword != "")
            {
                if (oldpassword == U.Password && oldpassword != "" && newpassword == confirmpassword)
                {
                    U.Password = newpassword;
                }
                else
                {
                    ViewBag.pass = "Passwords mismaatch!!!";
                    return View("User");
                }
            }

            if (name != "")
               U.Name = name;
            if (surname != "")
                U.Surname = surname;
            if (login != "")
             U.Login =login;
            Sh.Entry(U).State = EntityState.Modified;
            Sh.SaveChanges();
            return Index();
        }

        [HttpPost]
        public ActionResult LoadAvatar(HttpPostedFileBase file)
        {
            // Verify that the user selected a file
            if (file != null && file.ContentLength > 0)
            {
                // extract only the fielname
                var fileName = Path.GetFileName(file.FileName);
                // store the file inside ~/App_Data/uploads folder
                var path = Path.Combine(Server.MapPath("~/Content/avatar"), fileName);
                file.SaveAs(path);
                User U = Sh.Users.Find(Convert.ToInt32(Session["id"]));
                U.Photo = "/Content/avatar/" + Convert.ToString(fileName);
                Sh.Entry(U).State = EntityState.Modified;
                Sh.SaveChanges();
            }
            return Index();
        }

        [HttpPost]
        public ActionResult AddtoProfile()
        {
            User U = Sh.Users.Find(Convert.ToInt32(Session["id"]));
            ViewBag.User = U;

            return View("Profile");
        }
        public ActionResult Enter(string Login, string Password)
        {
            string l = Login;
            User U = Sh.Users.Where(u => u.Login == l).FirstOrDefault();
            if (U.Password == Password)
            {
                Session["id"] = U.Id;
                Session["curId"] = U.Id;
                return AddtoProfile();
            }
            else
            {
                ViewBag.password = "Email or password you entered is incorrect!";
                return View("../Home/Index");
            }
          
        }
    }
}

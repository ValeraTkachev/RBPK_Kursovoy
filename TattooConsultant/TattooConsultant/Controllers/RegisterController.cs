using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TattooConsultant.Models;

namespace TattooConsultant.Controllers
{
    public class RegisterController : Controller
    {
        //
        // GET: /Register/

        public ActionResult Index()
        {
            return View("Register");
        }
         [HttpPost]
        public ActionResult Register(string Login, string Password, string Name, string Surname, string Photo)
        {
            AccesoriesContext Tc = new AccesoriesContext();

            User UN = new User();
           
                UN.Login = Login;
                UN.Password = Password;
                UN.Name = Name;
                UN.Surname = Surname;
                UN.Photo = Photo;
          
            
            Tc.Users.Add(UN);
            Tc.SaveChanges();
            string a = Login;
            UN = Tc.Users.Where(u => u.Login == a).First();
            Session["id"] = UN.Id;
            return View("Register");
        }
    }
}

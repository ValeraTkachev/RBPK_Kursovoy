using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TattooConsultant.Models;

namespace TattooConsultant.Controllers
{
    public class SearchController : Controller
    {
        //
        // GET: /Search/
        AccesoriesContext Tc = new AccesoriesContext();
        public ActionResult Index()
        {
            return View();
        }
         [HttpPost]
        public ActionResult Search(string name, string color, string up, string down, string sex)
        {
            List<Item> I = new List<Item>();
            List<Item> I1 = new List<Item>();
            List<Item> I2 = new List<Item>();
            List<Item> I3 = new List<Item>();
            List<Item> I4 = new List<Item>();
            List<Item> I5 = new List<Item>();
            int a1 = 0, b1 = 0, c1 = 0, d1 = 0, e1 = 0;
            if (name != "")//заполняем начальный список
            {
               I= Tc.Items.Where(b => b.Name == name).ToList();
            }
            else
            {
                if (color != "")
                {
                    I = Tc.Items.Where(b => b.Color == color).ToList();
                }
                else
                {
                    if (up != "")
                    {
                        
                        I= Tc.Items.Where(b => b.Up == up).ToList();
                    }
                    else
                    {
                        if (down != "")
                        {
                            I = Tc.Items.Where(b => b.Down == down).ToList();
                        }
                        else
                        {
                            if (sex != "")
                            {
                                I = Tc.Items.Where(b => b.Sex == sex).ToList();
                            }
                        }
                    }
                }
            }

            if (name != "" && name != null)
            {
                foreach (var a in I)
                {
                    if (a.Name == name)
                        a1++;
                }
                foreach (var a2 in I)
                {
                    if (a2.Name == name)
                        I1.Add(a2);
                }
            }
            else
                I1 = I;

            if (color != "" && color != null)
            {
                foreach (var z in I1)
                {
                    if (z.Color == color)
                        b1++;
                }
                foreach (var b2 in I1)
                {
                    if (b2.Color == color)
                        I2.Add(b2);
                }
            }
            else
                I2 = I1;

            if (up != "" && up != null)
            {
                foreach (var c in I2)
                {
                    if (c.Up == up)
                        c1++;
                }
                foreach (var c2 in I2)
                {
                    if (c2.Up == up)
                        I3.Add(c2);
                }
            }
            else
                I3 = I2;
            if (down != "" && down != null)
            {
                foreach (var d in I3)
                {
                    if (d.Down == down)
                        d1++;
                }
                foreach (var d2 in I3)
                {
                    if (d2.Down == down)
                        I4.Add(d2);
                }
            }
            else
                I4 = I3;

            if (sex != "" && sex != null)
            {
                foreach (var e in I4)
                {
                    if (e.Sex == sex)
                        e1++;
                }
                foreach (var e2 in I4)
                {
                    if (e2.Sex == sex)
                        I5.Add(e2);
                }
            }
            else
                I5 = I4;
            @ViewBag.Result = I5;
            return View("Search");
        }
    }
    }


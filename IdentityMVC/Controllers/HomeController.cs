using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentityMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            if (Session["Id"] != null)
            {
                ViewBag.Message = "Your application description page.";

                return View();
            }
            else
            {
                //return RedirectToAction("Login#about");
                return Content("<script language='javascript' type='text/javascript'>alert('You must login first!');window.location.href='/Account/Login';</script>");
            }

            //ViewBag.Message = "Your application description page.";

            //return View();
        }

        public ActionResult Contact()
        {
            if (Session["Id"] != null)
            {
                ViewBag.Message = "Your contact page.";

                return View();
            }
            else
            {
                ViewBag.Message = string.Format("You must login first.");
                return Content("<script language='javascript' type='text/javascript'>alert('You must login first!');window.location.href='/Account/Login';</script>");
                //return RedirectToAction("Login#contact");
            }

            //ViewBag.Message = "Your contact page.";

            //return View();
        }

        public ActionResult Role()
        {
            ViewBag.Message = "Your role page.";

            return View();
        }
    }
}
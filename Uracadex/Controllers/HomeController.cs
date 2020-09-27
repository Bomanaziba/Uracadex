using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Uracadex.Models;

namespace Uracadex.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string message)
        {
            return View(new HomeViewModel { Message = message });
        }

        public ActionResult ThinkPad()
        {
            ViewBag.Message = "";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "";

            return View();
        }
    }
}
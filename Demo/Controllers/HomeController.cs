using Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly SettingService _setting = new SettingService();

        public ActionResult Index()
        {
            ViewBag.Title = _setting.Get("Website.Title");
            ViewBag.Desction = _setting.Get("Website.Desction");
            ViewBag.Company = _setting.Get("Website.Company");
            ViewBag.Tel = _setting.Get("Website.Tel");
            ViewBag.Email = _setting.Get("Website.Email");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
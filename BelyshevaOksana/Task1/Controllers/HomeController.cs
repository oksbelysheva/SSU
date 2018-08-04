using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Task1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Task1.Models.HomeViewModel model = new Models.HomeViewModel();
            model.MaxPay = 100000;
            model.PeopleCount = 1000;
            model.Now = DateTime.Now;
            return View(model);
        }

        public ActionResult Rules()
        {
            return View();
        }

        public ActionResult Game()
        {
            return View();
        }
    }
}
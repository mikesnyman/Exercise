using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExercisePlanner.Data;

namespace ExercisePlanner.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //GET:
        public ActionResult Login()
        {
            // validates username and password

            return View();
        }

        // POST: /Client/Add
        [HttpPost]
        public ActionResult Login(string name, string passw)
        {
            return RedirectToAction("Index", "Trainer");
        }

        public ActionResult Search()
        {
            // validates username and password

            return View();
        }

        public ActionResult Talk()
        {
            // validates username and password

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

    }
}

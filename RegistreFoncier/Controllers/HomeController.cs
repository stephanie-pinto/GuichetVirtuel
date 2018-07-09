using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegistreFoncier.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title="Guichet virtuel";
            return View();
        }

        public ActionResult Mission()
        {
            ViewBag.Title = "Notre mission";
            return View();
        }

        public ActionResult Centrale()
        {
            ViewBag.Title = "Centrale des testaments";
            return View();
        }

        public ActionResult RF2020()
        {
            ViewBag.Title = "Registre foncier 2020";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Title = "Contactez-nous";
            return View();
        }

        public ActionResult RF()
        {
            ViewBag.Title = "Registre foncier";
            return View();
        }

        public ActionResult FAQ()
        {
            ViewBag.Title = "Foire aux questions";
            return View();
        }
    }
}
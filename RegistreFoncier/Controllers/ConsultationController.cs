using RegistreFoncier.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegistreFoncier.Controllers
{
    public class ConsultationController : Controller
    {
        // GET: Consultation
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index2()
        {
            return View();
        }

        public ActionResult Intercapi()
        {
            ViewBag.Title = "Intercapi";
            return View();
        }

        public ActionResult Complet()
        {
            ViewBag.Title = "Extrait complet du registre foncier";
            return View();
        }

        public ActionResult Public()
        {
            ViewBag.Title = "Extrait public du registre foncier";

            List<string> communesList = new List<string>();
            communesList.Add("Dog");
            communesList.Add("Cat");
            communesList.Add("Hamster");
            communesList.Add("Parrot");
            communesList.Add("Gold fish");
            communesList.Add("Mountain lion");
            communesList.Add("Elephant");

            ViewData["Communes"] = new SelectList(communesList);

            return View();
        }

        [HttpPost]
        public ActionResult HandleFormPublic(PublicViewModels publicViewModels)
        {
            if (ModelState.IsValid)
            {
                //MemberManager.AddMember(registerVM.Firstname, registerVM.Lastname, registerVM.Gender, registerVM.Email, registerVM.Password);
                return RedirectToAction("Login");
            }

            return View();
        }



        // GET: Consultation/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Consultation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Consultation/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Consultation/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Consultation/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Consultation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Consultation/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

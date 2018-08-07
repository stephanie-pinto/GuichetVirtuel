using RegistreFoncier.ViewModels;
using RegistreFoncier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using System.IO;
using System.Net;
using Microsoft.Owin.Logging;

namespace RegistreFoncier.Controllers
{
    public class ConsultationController : MyController
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

            // Let's get all states that we need for a DropDownList
            var communes2 = GetAllStates();

            var model2 = new CompletViewModels();

            // Create a list of SelectListItems so these can be rendered on the page
            model2.Communes = GetSelectListItems(communes2);

            return View(model2);
        }

        public ActionResult Public()
        {
            ViewBag.Title = "Extrait public du registre foncier";

            // Let's get all states that we need for a DropDownList
            var communes = GetAllStates();

            var model = new PublicViewModels();

            // Create a list of SelectListItems so these can be rendered on the page
            model.Communes = GetSelectListItems(communes);

            return View(model);
        }


        //
        // 1. Action method for displaying 'Sign Up' page
        //
        [HttpPost]
        public ActionResult Public(PublicViewModels model)
        {
            // Get all states again
            var communes = GetAllStates();

            // Set these states on the model. We need to do this because
            // only the selected value from the DropDownList is posted back, not the whole
            // list of states.
            model.Communes = GetSelectListItems(communes);

            // Increment the id Public
            Random rnd = new Random();
            model.IdPublic = rnd.Next(1, 9999);

            // recovery of the ip address
            string hote = Dns.GetHostName();
            IPHostEntry iphe = Dns.Resolve(hote);
            string ip = iphe.AddressList[0].ToString();

            if (ModelState.IsValid)
            {

                Session["PublicViewModels"] = model;
                Boolean result = true;
                result = Logs.Logs.ReadLog(model.Email, ip);
                if (result == true)
                {
                    PublicManager.GetExtraitPublic(model.IdPublic, model.Name, model.Firstname, model.Email, model.Commune, model.Parcelle);
                    Logs.Logs.LogExtraitPublic(model.IdPublic + " - " + model.Name + " " + model.Firstname + ", Commune de " + model.Commune + " Parcelle n° " + model.Parcelle, model.Email, ip);
                    ViewBag.Success = true;
                    ViewBag.Message = "La demande a été transmise !";
                    return RedirectToAction("Done");
                }
                else
                {
                    TempData["msg"] = "<script>alert('Vous avez atteint le nombre de demandes maximum. Revenez demain.');</script>";

                    return View("Public", model);
                }

            }
            else
            {
                ViewBag.Message = "Erreur dans la transmission de la demande !";
                return View("Public", model);
            }
        }


        [HttpPost]
        public ActionResult Complet(CompletViewModels model)
        {
            // Get all states again
            var communes = GetAllStates();

            // Set these states on the model. We need to do this because
            // only the selected value from the DropDownList is posted back, not the whole
            // list of states.
            model.Communes = GetSelectListItems(communes);

            Random rnd = new Random();
            model.IdComplet = rnd.Next(1, 9999);

            // recovery of the ip address
            string hote = Dns.GetHostName();
            IPHostEntry iphe = Dns.Resolve(hote);
            string ip = iphe.AddressList[0].ToString();

            if (ModelState.IsValid)
            {
                Session["CompletViewModels"] = model;
                CompletManager.GetExtraitComplet(model.IdComplet, model.Name, model.Firstname, model.Adress, model.Email, model.Tel, model.Commune, model.Parcelle, model.Proprietaire, model.NameProprietaire, model.FirstnameProprietaire, model.Annexe, model.Remarque);
                Logs.Logs.LogExtraitComplet(model.IdComplet + " - " + model.Name + " " + model.Firstname + ", Tél : " + model.Tel + ", Commune de " + model.Commune + " Parcelle n° " + model.Parcelle, model.Email, ip);
                ViewBag.Success = true;
                ViewBag.Message = "La commande a été transmise !";
                return RedirectToAction("Done");
            }
            else
            {
                ViewBag.Message = "La transmission de la demande a échouée";
                return View("Complet", model);
            }
        }

        public ActionResult Done()
        {
            ViewBag.Title = "Success";

            return View();
        }

        public ActionResult DemandeIntercapi()
        {
            ViewBag.Title = "DemandeIntercapi";

            var types = GetAllTypes();
            var usersGroups = GetAllUsersGroups();

            var model = new IntercapiViewModels();

            model.Types = GetSelectListItems(types);
            model.Groups = GetSelectListItems(usersGroups);

            return View(model);
        }

        [HttpPost]
        public ActionResult DemandeIntercapi(IntercapiViewModels model)
        {
            var types = GetAllTypes();
            var usersGroups = GetAllUsersGroups();

            model.Types = GetSelectListItems(types);
            model.Groups = GetSelectListItems(usersGroups);

            // Increment the id Public
            Random rnd = new Random();
            model.IdIntercapi = rnd.Next(1, 9999);

            if (ModelState.IsValid)
            {

                Session["IntercapiViewModels"] = model;
                IntercapiManager.SendRequestIntercapi(model.IdIntercapi, model.Name, model.Firstname, model.Email, model.Type, model.Group, model.Message);
                Logs.Logs.LogDemandeIntercapi(model.IdIntercapi + " - " + model.Name + " " + model.Firstname + ", Type : " + model.Type + ", Groupe d'utilisateur : " + model.Group + ", Message : " + model.Message, model.Email);
                TempData["msg"] = "<script>alert('Demande transmise avec succès.');</script>";
                return RedirectToAction("DemandeIntercapi");
            }
            else
            {
                TempData["msg"] = "<script>alert('La transmission de la demande a échouée.');</script>";
                return View("DemandeIntercapi", model);
            }
        }

        // Just return a list of states - in a real-world application this would call
        // into data access layer to retrieve states from a database.
        private IEnumerable<string> GetAllStates()
        {
            return new List<string>
            {

                "Agarn",
                "Albinen",
                "Anniviers",
                "Arbaz",
                "Ardon",
                "Ausserberg",
                "Ayent",
                "Bagnes",
                "Baltschieder",
                "Bellwald",
                "Bettmeralp",
                "Binn",
                "Bister",
                "Bitsch",
                "Blatten",
                "Bourg-Saint-Pierre",
                "Bovernier",
                "Brig-Glis",
                "Bürchen",
                "Chalais",
                "Chamoson",
                "Champéry",
                "Charrat",
                "Chippis",
                "Collombey-Muraz",
                "Collonges",
                "Conthey",
                "Crans-Montana",
                "Dorénaz",
                "Eggerberg",
                "Eischoll",
                "Eisten",
                "Embd",
                "Ergisch",
                "Ernen",
                "Evolène",
                "Ferden",
                "Fiesch",
                "Fieschertal",
                "Finhaut",
                "Fully",
                "Gampel-Bratsch",
                "Goms",
                "Grengiols",
                "Grimisuat",
                "Grône",
                "Grächen",
                "Guttet-Feschel",
                "Hérémence",
                "Icogne",
                "Inden",
                "Isérables",
                "Kippel",
                "Lalden",
                "Lax",
                "Lens",
                "Lextron",
                "Liddes",
                "Leuk",
                "Leukerbad",
                "Martigny",
                "Martigny-Combe",
                "Massongex",
                "Miège",
                "Mont-Noble",
                "Monthey",
                "Mörel-Filet",
                "Naters",
                "Nendaz",
                "Niedergesteln",
                "Oberems",
                "Obergoms",
                "Orsières",
                "Port-Valais",
                "Randa",
                "Rarogne",
                "Riddes",
                "Ried-Brig",
                "Riederalp",
                "Saas-Almagell",
                "Saas-Balen",
                "Saas-Fee",
                "Saas-Grund",
                "Saillon",
                "Saint-Gingolph",
                "Saint-Léonard",
                "Saint-Martin",
                "Saint-Maurice",
                "Saint-Nicolas",
                "Salquenen",
                "Salvan",
                "Savièse",
                "Saxon",
                "Sembrancher",
                "Sierre",
                "Simplon",
                "Sion",
                "Stalden",
                "Staldenried",
                "Steg-Hohtenn",
                "Termen",
                "Trient",
                "Troistorrents",
                "Turtmann-Unterems",
                "Täsch",
                "Törbel",
                "Unterbäch",
                "Val-d'Illiez",
                "Varonne",
                "Venthône",
                "Vernayaz",
                "Vérossaz",
                "Vétroz",
                "Vex",
                "Veyras",
                "Veysonnaz",
                "Viège",
                "Vionnaz",
                "Visperterminen",
                "Vollèges",
                "Vouvry",
                "Wiler",
                "Zeneggen",
                "Zermatt",
                "Zwischbergen",
        };
        }

        // This is one of the most important parts in the whole example.
        // This function takes a list of strings and returns a list of SelectListItem objects.
        // These objects are going to be used later in the SignUp.html template to render the
        // DropDownList.
        private IEnumerable<SelectListItem> GetSelectListItems(IEnumerable<string> elements)
        {
            // Create an empty list to hold result of the operation
            var selectList = new List<SelectListItem>();

            // For each string in the 'elements' variable, create a new SelectListItem object
            // that has both its Value and Text properties set to a particular value.
            // This will result in MVC rendering each item as:
            //     <option value="State Name">State Name</option>
            foreach (var element in elements)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element,
                    Text = element
                });
            }

            return selectList;
        }

        public ActionResult ChangeLanguage(string lang)
        {
            new LanguageMang().SetLanguage(lang);
            return Redirect(Request.UrlReferrer.PathAndQuery);
        }

        //List of types of object for a request Intercapi
        private IEnumerable<string> GetAllTypes()
        {
            return new List<string>
            {

                "Nouvelles demandes d'accès",
                "Mot-de-passe oublié",
                "Problèmes de connexion",
                "Autres problèmes",
        };
        }

        //List of types of object for a request Intercapi
        private IEnumerable<string> GetAllUsersGroups()
        {
            return new List<string>
            {

                "Notaires",
                "Teneurs de cadastre",
                "Géomètres",
                "Administrations cantonales",
                "Administrations communales",
                "Autre",
        };
        }
    }
}

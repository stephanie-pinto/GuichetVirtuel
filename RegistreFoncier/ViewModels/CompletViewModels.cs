using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegistreFoncier.ViewModels
{

    public class CompletViewModels
    {
        public int IdComplet { get; set; }

        [Required(ErrorMessage = "Insérez votre nom.")]
        [Display(Name = "Name", ResourceType = typeof(Resources.Consultation.Complet))]
        public string Name { get; set; }

        [Required(ErrorMessage = "Insérez votre prénom.")]
        [Display(Name = "Firstname", ResourceType = typeof(Resources.Consultation.Complet))]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Insérez votre adresse.")]
        [Display(Name = "Adress", ResourceType = typeof(Resources.Consultation.Complet))]
        public string Adress { get; set; }

        [Required(ErrorMessage = "Insérez votre e-mail.")]
        [DataType(DataType.EmailAddress), Display(Name = "Email", ResourceType = typeof(Resources.Consultation.Complet))]
        public string Email { get; set; }

        [Required(ErrorMessage = "Insérez votre numéro de téléphone.")]
        [Display(Name = "Tel", ResourceType = typeof(Resources.Consultation.Complet))]
        public string Tel { get; set; }

        [Display(Name = "Commune", ResourceType = typeof(Resources.Consultation.Complet))]
        public string Commune { get; set; }

        public IEnumerable<SelectListItem> Communes { get; set; }

        [Required(ErrorMessage = "Insérez la parcelle.")]
        [Display(Name = "Parcelle", ResourceType = typeof(Resources.Consultation.Complet))]
        public string Parcelle { get; set; }

        [Display(Name = "Proprietaire", ResourceType = typeof(Resources.Consultation.Complet))]
        public bool Proprietaire { get; set; }

        [Display(Name = "NameProprietaire", ResourceType = typeof(Resources.Consultation.Complet))]
        public string NameProprietaire { get; set; }

        [Display(Name = "FirstnameProprietaire", ResourceType = typeof(Resources.Consultation.Complet))]
        public string FirstnameProprietaire { get; set; }

        [Display(Name = "Annexe", ResourceType = typeof(Resources.Consultation.Complet))]
        public HttpPostedFileBase Annexe { get; set; }

        [Display(Name = "Remarque", ResourceType = typeof(Resources.Consultation.Complet))]
        public string Remarque { get; set; }

    }

}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegistreFoncier.ViewModels
{

    public class PublicViewModels
    {
        [Key]
        public int IdPublic { get; set; }

        [Required(ErrorMessage = "Insérez votre nom.")]
        [Display(Name = "Name", ResourceType = typeof(Resources.Consultation.Public))]
        public string Name { get; set; }

        [Required(ErrorMessage = "Insérez votre prénom.")]
        [Display(Name = "Firstname", ResourceType = typeof(Resources.Consultation.Public))]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Insérez votre e-mail.")]
        [DataType(DataType.EmailAddress), Display(Name = "Email", ResourceType = typeof(Resources.Consultation.Public))]
        public string Email { get; set; }

        [Display(Name = "Commune", ResourceType = typeof(Resources.Consultation.Public))]
        public string Commune { get; set; }

        public IEnumerable<SelectListItem> Communes { get; set; }

        [Required(ErrorMessage = "Insérez la parcelle.")]
        [Display(Name = "Parcelle", ResourceType = typeof(Resources.Consultation.Public))]
        public string Parcelle { get; set; }
    }

}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegistreFoncier.ViewModels
{

    public class IntercapiViewModels
    {
        [Key]
        public int IdIntercapi { get; set; }

        [Required(ErrorMessage = "Insérez votre nom.")]
        [Display(Name = "Name", ResourceType = typeof(Resources.Consultation.DemandeIntercapi))]
        public string Name { get; set; }

        [Required(ErrorMessage = "Insérez votre prénom.")]
        [Display(Name = "Firstname", ResourceType = typeof(Resources.Consultation.DemandeIntercapi))]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Insérez votre e-mail.")]
        [DataType(DataType.EmailAddress), Display(Name = "Email", ResourceType = typeof(Resources.Consultation.DemandeIntercapi))]
        public string Email { get; set; }

        [Display(Name = "Type", ResourceType = typeof(Resources.Consultation.DemandeIntercapi))]
        public string Type { get; set; }

        public IEnumerable<SelectListItem> Types { get; set; }

        [Display(Name = "Group", ResourceType = typeof(Resources.Consultation.DemandeIntercapi))]
        public string Group { get; set; }

        public IEnumerable<SelectListItem> Groups { get; set; }

        [Display(Name = "Message", ResourceType = typeof(Resources.Consultation.DemandeIntercapi))]
        public string Message { get; set; }
    }

}
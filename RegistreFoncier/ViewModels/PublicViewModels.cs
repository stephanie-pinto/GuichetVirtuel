using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RegistreFoncier.ViewModels
{

    public class PublicViewModels
    {
        public int IdPublic { get; set; }

        [Required(ErrorMessage = "Insérez votre nom.")]
        [Display(Name = "Nom :")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Insérez votre prénom.")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Insérez votre e-mail.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Sélectionnez la commune.")]
        public string Commune { get; set; }

        [Required(ErrorMessage = "Insérez la parcelle.")]
        public string Parcelle { get; set; }
    }

}
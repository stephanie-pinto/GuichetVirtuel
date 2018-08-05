using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DTO
{
    public class ExtraitComplet
    {
        public int IdExtraitComplet { get; set; }
        public string Name { get; set; }
        public string Firstname { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
        public string Commune { get; set; }
        public int Parcelle { get; set; }
        public bool Proprietaire { get; set; }
        public string NameProprietaire { get; set; }
        public string FirstnameProprietaire { get; set; }
        public HttpPostedFileBase Annexe { get; set; }
        public string Remarque { get; set; }

    }
}

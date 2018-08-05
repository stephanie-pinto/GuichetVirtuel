using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Web;

namespace BLL
{
    public class CompletManager
    {
        public static ExtraitComplet GetExtraitComplet(int IdComplet, String Name, String Firstname, String Adress, String Email, String Tel, String Commune, String Parcelle, Boolean Proprietaire, String NameProprietaire, String FirstnameProprietaire, HttpPostedFileBase Annexe, String Remarque)
        {
            return ExtraitCompletDB.GetExtraitComplet(IdComplet, Name, Firstname, Adress, Email, Tel, Commune, Parcelle, Proprietaire, NameProprietaire, FirstnameProprietaire, Annexe, Remarque);
        }
    }
}

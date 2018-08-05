using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PublicManager
    {
        public static ExtraitPublic GetExtraitPublic(int IdPublic, String Name, String Firstname, String Email, String Commune, String Parcelle)
        {
            return ExtraitPublicDB.GetExtraitPublic(IdPublic, Name, Firstname, Email, Commune, Parcelle);
        } 

    }
}

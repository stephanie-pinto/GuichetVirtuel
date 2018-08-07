using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class IntercapiManager
    {
        public static DemandeIntercapi SendRequestIntercapi(int IdIntercapi, String Name, String Firstname, String Email, String Type, String Group, String Message)
        {
            return IntercapiDB.SendRequestIntercapi(IdIntercapi, Name, Firstname, Email, Type, Group, Message);
        } 

    }
}

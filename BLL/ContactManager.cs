using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ContactManager
    {
        public static Contact SendContactEmail(int IdContact, String Name, String Email, String Objet, String Message)
        {
            return ContactDB.SendContactEmail(IdContact, Name, Email, Objet, Message);
        } 

    }
}

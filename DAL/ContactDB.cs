using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Net.Mail;

namespace DAL
{
    public class ContactDB
    {
            
        public static Contact SendContactEmail(int IdContact, String Name, String Email, String Objet, String Message)
        {
            //SEND MAIL
            try
            {
                string ToEmail = null;

                MailMessage mailMessage = new MailMessage();

                MailAddress fromAddress = new MailAddress(Email);

                mailMessage.From = fromAddress;

                mailMessage.To.Add(ToEmail);

                String date = DateTime.Now.ToString();

                String emailBody = "Bonjour " +
                    "</br>" + ""
                   ;

                mailMessage.Body = emailBody;

                mailMessage.IsBodyHtml = true;

                String objet = IdContact + " - Commande d'extrait public du registre foncier";

                mailMessage.Subject = objet;

                SmtpClient smtpClient = new SmtpClient();

                smtpClient.Host = "localhost";

                smtpClient.Send(mailMessage);

            }

            catch (Exception)
            {

            }



            return null;
        }
    }
}

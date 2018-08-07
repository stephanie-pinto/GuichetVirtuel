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
    public class IntercapiDB
    {
        //Dim cn As New MySqlConnection;

        public static DemandeIntercapi SendRequestIntercapi(int IdIntercapi, String Name, String Firstname, String Email, String Type, String Group, String Message)
        {
            //SEND MAIL
            try
            {
                String code;
                
                if (Type == "Nouvelles demandes d'accès")
                {
                    code = "[NEW]";
                }else if(Type == "Mot-de-passe oublié")
                {
                    code = "[PASSWORD]";
                }else if(Type == "Problèmes de connexion")
                {
                    code = "[CONNEXION]";
                }
                else
                {
                    code = "[OTHER]";
                }

                MailMessage mailMessage = new MailMessage();

                MailAddress fromAddress = new MailAddress(Email);

                mailMessage.From = fromAddress;

                mailMessage.To.Add("srf-intercapi@admin.vs.ch");

                String date = DateTime.Now.ToString();

                String emailBody = "Bonjour </br>" +
                    "</br>" +
                    Name + " " + Firstname + " a déposé une demande Intercapi sur le site le " + date + " pour une demande de type " + Type + ".</br>" +
                    "</br>" +
                    "Voici ces coordonnées </br>" +
                    "</br>" +
                    "</br>" +
                    "Son email : " + Email + "</br>" +
                    "Son groupe d'utilisateur : " + Group + "</br>" +
                    "Message : " + Message + "</br" +
                    "</br>" +
                    "Message envoyé depuis le formulaire automatique de demande Intercapi.";

                mailMessage.Body = emailBody;

                mailMessage.IsBodyHtml = true;

                String objet = code + " - " + IdIntercapi;

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

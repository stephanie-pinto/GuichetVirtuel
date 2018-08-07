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
    public class ExtraitPublicDB
    {
        //Dim cn As New MySqlConnection;
            
        public static ExtraitPublic GetExtraitPublic(int IdPublic, String Name, String Firstname, String Email, String Commune, String Parcelle)
        {
            //Connection à la DB
            //ExtraitPublic extraitPublic = ConfigurationManager.ConnextionStrings["DatabaseDataAccess"].ConnectionString;


            //SEND MAIL
            try
            {

                MailMessage mailMessage = new MailMessage();

                MailAddress fromAddress = new MailAddress("SRF-DGB@admin.vs.ch");

                mailMessage.From = fromAddress;

                mailMessage.To.Add(Email);

                String date = DateTime.Now.ToString();

                String emailBody = "Bonjour " + Name + " " + Firstname + "</br>" +
                    "</br>" +
                    "Voici la demande d'extrait public du registre foncier que vous avez faite." +
                    "</br>" +
                    "Date de la demande : " + date + "</br>" +
                    "</br>" +
                    "Commune : " + Commune + "</br>" +
                    "Immeuble n° : " + Parcelle + "</br>" +
                    "Plan n° : " + "</br>" +
                    "Nom Local : " + "</br>" +
                    "Surface (m2) : " + "</br>" +
                    "<h3>BATIMENT(S)</h3>" +
                    "N° : " + "</br>" +
                    "Surface (m2 sur parcelle) : " + "</br>" +
                    "Surface totale (m2) : " + "</br>" +
                    "Destination : " + "</br>" +
                    "<h3>ETAT DE LA PROPRIETE</h3>" +
                    "<p><strong>Pour des informations plus précises concernant le régime de propriété, les types d'immeubles et leurs propriétaires, voir le registre foncier.</strong></p> </br>" +
                    "Immeuble " + "</br>" +
                    " " + ", " + "." + "." + ", né(e) " +
                    "</br>" +
                    "Service du Registre foncier du Canton du Valais."; ;

                mailMessage.Body = emailBody;

                mailMessage.IsBodyHtml = true;

                String objet = IdPublic + " - Commande d'extrait public du registre foncier";

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

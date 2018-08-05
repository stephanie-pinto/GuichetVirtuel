using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Web;

namespace DAL
{
    public class ExtraitCompletDB
    {

        public static  ExtraitComplet GetExtraitComplet(int IdComplet, String Name, String Firstname, String Adress, String Email, String Tel, String Commune, String Parcelle, Boolean Proprietaire, String NameProprietaire, String FirstnameProprietaire, HttpPostedFileBase Annexe, String Remarque)
        {

            //ExtraitPublic extraitPublic = ConfigurationManager.ConnextionStrings["DatabaseDataAccess"].ConnectionString;


            //return extraitPublic;

            String Rf;
            String TC = null;

            //Communes de Loèche en RFF
            if(Commune == "Agarn" || Commune == "Albinen" || Commune == "Bürchen" || Commune == "Eischoll" || Commune == "Ergisch" || Commune == "Ferden" || 
                Commune == "Gampel-Bratsch" || Commune == "Guttet-Feschel" || Commune == "Inden" || Commune == "Kippel" || Commune == "Leuk" || 
                Commune == "Niedergesteln" || Commune == "Salgesch" || Commune == "Steg-Hohtenn" || Commune == "Turtmann-Unterems" || Commune == "Varen" || 
                Commune == "Wiler")
            {
                Rf = "GB-LEUK@admin.vs.ch";

            //Communes de Brig en RFF
            }else if (Commune == "Baltschieder" || Commune == "Bellwald" || Commune == "Bettmeralp" || Commune == "Bister" || Commune == "Bitsch" || Commune == "Blitzingen" ||
                Commune == "Brig-Glis" || Commune == "Eggerberg" || Commune == "Embd" || Commune == "Fiesch" || Commune == "Fieschertal" || Commune == "Lalden" || Commune == "Lax" ||
                Commune == "Mörel-Filet" || Commune == "Naters" || Commune == "Randa" || Commune == "Ried-Brig" || Commune == "Saas Fee" || Commune == "Simplon" || Commune == "Saint-Nicolas" ||
                Commune == "Stalden" || Commune == "Visp" || Commune == "Zwischbergen")
            {
                Rf = "GB-BRIG@admin.vs.ch";

            //Communes de Sierre en RFF
            }else if (Commune == "Anniviers" || Commune == "Chippis" || Commune == "Crans-Montana" || Commune == "Grône" || Commune == "Icogne" || Commune == "Miège" || Commune == "Saint-Léonard" ||
                Commune == "Sierre" || Commune == "Venthône" || Commune == "Veyras")
            {
                Rf = "RF-SIERRE@admin.vs.ch";

            //Communes de Sion en RFF
            }else if(Commune == "Ardon" || Commune == "Ayent" || Commune == "Conthey" || Commune == "Grimisuat" || Commune == "Hérémence" || Commune == "Mont-Noble" || Commune == "Sion" || Commune == "Vétroz" ||
                Commune == "Vex" || Commune == "Veysonnaz")
            {
                Rf = "RF-SION@admin.vs.ch";

            //Communes de Martigny en RFF
            } else if(Commune == "Bagnes" || Commune == "Bourg-Saint-Pierre" || Commune == "Bovernier" || Commune == "Charrat" || Commune == "Fully" || Commune == "Isérables" || Commune == "Leytron" || 
                Commune == "Martigny" || Commune == "Orsières" || Commune == "Riddes" || Commune == "Saillon" || Commune == "Saxon" || Commune == "Sembrancher" || Commune == "Trient" || Commune == "Vernayaz" ||
                Commune == "Vollèges")
            {
                Rf = "RF-MARTIGNY@admin.vs.ch";

            //Communes de Monthey en RFF
            }else if (Commune == "Collombey-Muraz" || Commune == "Collonges" || Commune == "Dorénaz" || Commune == "Evionnaz" || Commune == "Monthey" || Commune == "Port-Valais" || Commune == "Saint-Maurice" ||
                Commune == "Troistorrents" || Commune == "Vionnaz")
            {
                Rf = "RF-MONTHEY@admin.vs.ch";
            }else if (Commune == "Arbaz")
            {
                Rf = "RF-SION@admin.vs.ch";
                TC = "cadastre@arbaz.ch";
            }else if (Commune == "Ausserberg")
            {
                Rf = "GB-LEUK@admin.vs.ch";
                TC = "leiggener.ludi@bluewin.ch";
            }else if(Commune == "Binn")
            {
                Rf = "GB-BRIG@admin.vs.ch";
                TC = "beat.tenisch@binn.ch";
            }else if(Commune == "Blatten")
            {
                Rf = "GB-LEUK@admin.vs.ch";
                TC = "registeramt@blatten-vs.ch";
            }else if(Commune == "Chalais")
            {
                Rf = "RF-SIERRE@admin.vs.ch";
                TC = "nathalie.grichting@chalais.ch";
            }else if(Commune == "Chamoson")
            {
                Rf = "RF-SION@admin.vs.ch";
                TC = "cadastre@chamoson.net";
            }else if(Commune == "Champéry")
            {
                Rf = "RF-MONTHEY@admin.vs.ch";
                TC = "cecoeur@champery.ch";
            }else if(Commune == "Eisten")
            {
                Rf = "GB-BRIG@admin.vs.ch";
                TC = "gemeinde@eisten.ch";
            }else if(Commune == "Ernen")
            {
                Rf = "GB-BRIG@admin.vs.ch";
                TC = "gemeinde@ernen.ch";
            }else if(Commune == "Evolène")
            {
                Rf = "RF-SION@admin.vs.ch";
                TC = "Rumpf@admin-evolene.ch";
            }else if(Commune == "Finhaut")
            {
                Rf = "RF-MARTIGNY@admin.vs.ch";
                TC = "cadastre@finhaut.ch";
            }else if(Commune == "Grächen")
            {
                Rf = "GB-BRIG@admin.vs.ch";
                TC = "silvio.walter@graechen.ch";
            }else if(Commune == "Grengiols")
            {
                Rf = "GB-BRIG@admin.vs.ch";
                TC = "gemeinde@grengiols.ch";
            }else if (Commune == "Lens")
            {
                Rf = "RF-SIERRE@admin.vs.ch";
                TC = "constant.bonvin@lens.ch";
            }else if (Commune == "Leukerbad")
            {
                Rf = "GB-LEUK@admin.vs.ch";
                TC = "rudi.allet@leukerbad.org";
            }else if(Commune == "Liddes")
            {
                Rf = "RF-MARTIGNY@admin.vs.ch";
                TC = "cadastre@liddes.ch";
            }else if(Commune == "Martigny-Combe")
            {
                Rf = "RF-MARTIGNY@admin.vs.ch";
                TC = "cadastre@martigny-combe.ch";
            }else if(Commune == "Massongex")
            {
                Rf = "RF-MONTHEY@admin.vs.ch";
                TC = "info@massongex.ch";
            }else if(Commune == "Nendaz")
            {
                Rf = "RF-SION@admin.vs.ch";
                TC = "cadastre@nendaz.org";
            }else if(Commune == "Oberems")
            {
                Rf = "GB-LEUK@admin.vs.ch";
                TC = "gemeinde@oberems.ch";
            }else if(Commune == "Obergoms")
            {
                Rf = "GB-BRIG@admin.vs.ch";
                TC = "gemeinde@obergoms.ch";
            }else if(Commune == "Raron")
            {
                Rf = "GB-LEUK@admin.vs.ch";
                TC = "gemeinde@raron.ch";
            }else if(Commune == "Riederalp")
            {
                Rf = "GB-BRIG@admin.vs.ch";
                TC = "info@gemeinde-riederalp.ch";
            }else if(Commune == "Saas-Almagell")
            {
                Rf = "GB-BRIG@admin.vs.ch";
                TC = "d.andenmatten@bluewin.ch";
            }else if(Commune == "Saas-Balen")
            {
                Rf = "GB-BRIG@admin.vs.ch";
                TC = "saas-balen@bluewin.ch";
            }else if(Commune == "Saas-Grund")
            {
                Rf = "GB-BRIG@admin.vs.ch";
                TC = "louis.zurbriggen@3906.ch";
            }else if(Commune == "Saint-Gingolph")
            {
                Rf = "RF-MONTHEY@admin.vs.ch";
                TC = "carine.crettenand@st-gingolph.ch";
            }else if(Commune == "Saint-Martin")
            {
                Rf = "RF-SION@admin.vs.ch";
                TC = "cadastre@saint-martin.ch";
            }else if(Commune == "Salvan")
            {
                Rf = "RF-MARTIGNY@admin.vs.ch";
                TC = "cadastre@salvan.ch";
            }else if(Commune == "Savièse")
            {
                Rf = "RF-SION@admin.vs.ch";
                TC = "christophe.dumoulin@saviese.ch";
            }else if(Commune == "Staldenried")
            {
                Rf = "GB-BRIG@admin.vs.ch";
                TC = "registerhalter@staldenried.ch";
            }else if(Commune == "Täsch")
            {
                Rf = "GB-BRIG@admin.vs.ch";
                TC = "registerhalter@gemeinde-taesch.ch";
            }else if(Commune == "Termen")
            {
                Rf = "GB-BRIG@admin.vs.ch";
                TC = "hans.michlig@admin.vs.ch";
            }else if(Commune == "Törbel")
            {
                Rf = "GB-BRIG@admin.vs.ch";
                TC = "registerhalter@toerbel.ch";
            }else if(Commune == "Unterbäch")
            {
                Rf = "GB-LEUK@admin.vs.ch";
                TC = "rgh.unterbaech@gmx.ch";
            }else if(Commune == "Val-d'Illiez")
            {
                Rf = "RF-MONTHEY@admin.vs.ch";
                TC = "technique@illiez.ch";
            }else if(Commune == "Vérossaz")
            {
                Rf = "RF-MONTHEY@admin.vs.ch";
                TC = "info@verossaz.ch";
            }else if(Commune == "Visperterminen")
            {
                Rf = "GB-BRIG@admin.vs.ch";
                TC = "h.zimmermann@rudaz.ch";
            }else if(Commune == "Vouvry") { Rf = "RF-MONTHEY@admin.vs.ch"; TC = "office@vouvry.ch";
            }else if (Commune == "Zeneggen") { Rf = "GB-BRIG@admin.vs.ch"; TC = "registerhalterEmail@zeneggen.ch"; }
            else if (Commune == "Zermatt") { Rf = "GB-BRIG@admin.vs.ch"; TC = "registerhalter@zermatt.ch"; }
            else { Rf = null; TC = null; }

            //SEND MAIL
            try
            {

                //SEND EMAIL TO THE RF
                MailMessage mailMessageRF = new MailMessage();

                MailAddress fromAddressToRF = new MailAddress(Email);

                mailMessageRF.From = fromAddressToRF;

                mailMessageRF.To.Add(Rf);

                String date = DateTime.Now.ToString();

                String emailBodyRF = "Bonjour," + "</br>" +
                    "</br>" +
                    "La commande n° " + IdComplet + " a été faite aujourd'hui selon les coordonnées suivantes : </br>" +
                    "</br>" +
                    "</br>" +
                    "Date de la demande : " + date + "</br>" +
                    "</br>" +
                    "<strong>Coordonnées du Demandeur : </strong> </br>" +
                    "Nom : " + Name + "</br>" +
                    "Prénom : " + Firstname + "</br>" +
                    "Adresse : " + Adress + "</br>" +
                    "Email : " + Email + "</br>" +
                    "Téléphone : " + Tel + "</br>" +
                    "</br>" +
                    "<strong> Pour l'immeuble : </strong></br>" +
                    "Commune : " + Commune + "</br>" +
                    "Immeuble n° : " + Parcelle + "</br>" +
                    "</br>" +
                    "Êtes-vous propriétaire ? " + Proprietaire.ToString() + "</br>" +
                    "Si ce n'est pas le cas voici les coordonnées du propriétaite : </br>" +
                    "Nom : " + NameProprietaire + "</br>" +
                    "Prénom : " + FirstnameProprietaire + "</br>" +
                    "</br>" +
                    "Remarque : " + Remarque + "</br>";

                if(TC != null)
                {
                    emailBodyRF = emailBodyRF +
                        "Une demande a été faite au teneur de cadastre de la commune de " + Commune;
                }

                mailMessageRF.Body = emailBodyRF;

                mailMessageRF.IsBodyHtml = true;

                String objetRF = IdComplet + " - Commande web d'extrait complet du RF";

                mailMessageRF.Subject = objetRF;

                if (Annexe != null)
                {
                    /**var attachment = new Attachment(Annexe.InputStream, Path.GetFileName(Annexe.FileName));
                    mailMessageRF.Attachments.Add(attachment);**/
                    mailMessageRF.Attachments.Add(new Attachment(Annexe.InputStream, Path.GetFileName(Annexe.FileName)));
                }

                SmtpClient smtpRF = new SmtpClient();

                smtpRF.Host = "localhost";

                smtpRF.Send(mailMessageRF);


                //SEND EMAIL au TC si c'est une commnune cadastrale
                if(TC != null)
                {
                    MailMessage mailMessageTC = new MailMessage();

                    mailMessageTC.From = fromAddressToRF;

                    mailMessageTC.To.Add(TC);

                    String emailBodyTC = "Bonjour," +
                        "</br>" +
                        Name + " " + Firstname + " a fait une demande sur notre site pour une déclaration des charges. Pour la produire, nous avons besoin d'un extrait de cadastre original.</br>" +
                        "Pouvez-vous le produire et nous le transmettre au registre foncier compétent avec la facturation qui sera transmise au client." +
                        "</br>" +
                        "</br>" +
                        "Voici les informations de la demande : </br>" +
                        "</br>" +
                        "Date de la demande : " + date + "</br>" +
                        "</br>" +
                        "<strong>Coordonnées du Demandeur : </strong> </br>" +
                        "Nom : " + Name + "</br>" +
                        "Prénom : " + Firstname + "</br>" +
                        "Adresse : " + Adress + "</br>" +
                        "Email : " + Email + "</br>" +
                        "Téléphone : " + Tel + "</br>" +
                        "</br>" +
                        "<strong>Pour l'immeuble : </strong></br>" +
                        "Commune : " + Commune + "</br>" +
                        "Immeuble n° : " + Parcelle + "</br>" +
                        "Registre foncier concerné : " + Rf + "</br>" +
                        "</br>" +
                        "Le demandeur est-il le propriétaire ? " + Proprietaire.ToString() + "</br>" +
                        "Si ce n'est pas le cas voici les coordonnées du propriétaite : </br>" +
                        "Nom : " + NameProprietaire + "</br>" +
                        "Prénom : " + FirstnameProprietaire + "</br>" +
                        "</br>" +
                        "La remarque du demandeur : " + Remarque + "</br>" +
                        "</br>" +
                        "Service du Registre foncier du Canton du Valais.";

                    mailMessageTC.Body = emailBodyTC;

                    mailMessageTC.IsBodyHtml = true;

                    String objetTC = IdComplet + " - Commande web d'extrait complet du RF";

                    mailMessageTC.Subject = objetTC;

                    SmtpClient smtpTC = new SmtpClient();

                    smtpTC.Host = "localhost";

                    smtpTC.Send(mailMessageTC);
                }
                
                //SEND EMAIL TO THE CLIENT
                MailMessage mailMessageClient = new MailMessage();

                MailAddress fromAddressToClient = new MailAddress("SRF-DGB@admin.vs.ch");

                mailMessageClient.From = fromAddressToClient;

                mailMessageClient.To.Add(Email);

                String emailBodyClient = "Bonjour " + Name + " " + Firstname + "</br>" +
                    "</br>" +
                    "Nous vous remercions de votre commande d'extrait complet du registre foncier qui est en cours de traitement selon les données suivantes : " +
                    "</br>" +
                    "</br>" +
                    "Date de la demande : " + date + "</br>" +
                    "</br>" +
                    "<strong>Coordonnées du Demandeur : </strong> </br>" +
                    "Adresse : " + Adress + "</br>" +
                    "Email : " + Email + "</br>" +
                    "Téléphone : " + Tel + "</br>" +
                    "</br>" +
                    "<strong>Pour l'immeuble : </strong> </br>" +
                    "Commune : " + Commune + "</br>" +
                    "Immeuble n° : " + Parcelle + "</br>" +
                    "</br>" +
                    "Êtes-vous propriétaire ? " + Proprietaire.ToString() + "</br>" +
                    "Si ce n'est pas le cas voici les coordonnées du propriétaite : </br> " +
                    "Nom : " + NameProprietaire + "</br>" +
                    "Prénom : " + FirstnameProprietaire + "</br>" +
                    "</br>" +
                    "Votre remarque : " + Remarque + "</br>" +
                    "</br>" +
                    "Service du Registre foncier du Canton du Valais.";

                mailMessageClient.Body = emailBodyClient;

                mailMessageClient.IsBodyHtml = true;

                String objetClient = IdComplet + " - Commande d'extrait complet du registre foncier";

                mailMessageClient.Subject = objetClient;

                SmtpClient smtpClient = new SmtpClient();

                smtpClient.Host = "localhost";

                smtpClient.Send(mailMessageClient);

            }
            catch (Exception)
            {

            }

            return null;
        }
    }
}

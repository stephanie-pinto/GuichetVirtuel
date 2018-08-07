using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace RegistreFoncier.Logs
{
    public class Logs
    {
        public static void LogExtraitPublic(string commande, string email, string ip)
        {
            FileStream fileStream;
            FileInfo logFileInfo;

            string date = DateTime.Now.ToString();
            string[] lines = { date, commande, email, ip };

            string repertoire = DateTime.Now.ToString("yyyyMM");
            string filename = DateTime.Now.ToString("yyyyMMdd");
            string docpath = "C:/Users/Stéphanie Pinto/source/repos/RegistreFoncier/RegistreFoncier/Logs/Public/" + repertoire + "/" + filename + ".txt";

            logFileInfo = new FileInfo(docpath);
            DirectoryInfo logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);
            if (!logDirInfo.Exists) logDirInfo.Create();
            if (!logFileInfo.Exists)
            {
                fileStream = logFileInfo.Create();
                fileStream.Close();
            }
            else
            {
                fileStream = new FileStream(docpath, FileMode.Append);
                fileStream.Close();
            }

            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(docpath, true))
            {
                for (int i = 0; i < lines.Length; i++)
                {
                    file.Write(String.Format(lines[i] + " \t"));
                }
                file.Write(Environment.NewLine);
            }
        }

        public static Boolean ReadLog(string Email, string ip)
        {
            Boolean result = true;
            int nbreEmail = 0;
            int nbreIP = 0;

            FileInfo logFileInfo;

            string date = DateTime.Now.ToString();

            string repertoire = DateTime.Now.ToString("yyyyMM");
            string filename = DateTime.Now.ToString("yyyyMMdd");
            string docpath = "C:/Users/Stéphanie Pinto/source/repos/RegistreFoncier/RegistreFoncier/Logs/Public/" + repertoire + "/" + filename + ".txt";

            logFileInfo = new FileInfo(docpath);
            DirectoryInfo logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);
            if (logDirInfo.Exists)
            {
                if (logFileInfo.Exists) {
                    using (System.IO.StreamReader file =
                    new System.IO.StreamReader(docpath))
                    {
                        string ligne = file.ReadLine();

                        // Lecture de toutes les lignes et affichage de chacune sur la page 
                        while (ligne != null)
                        {
                            if (ligne.Contains(Email))
                            {
                                nbreEmail++;
                            }
                            if (ligne.Contains(ip))
                            {
                                nbreIP++;
                            }
                            ligne = file.ReadLine();
                        }
                        // Fermeture du StreamReader (attention très important) 
                        file.Close();
                            
                    }
                }
            }
            

            if (nbreEmail <= 5 && nbreIP <=5)
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }

        public static void LogExtraitComplet(string commande, string email, string ip)
        {
            FileStream fileStream;
            FileInfo logFileInfo;

            string date = DateTime.Now.ToString();
            string[] lines = { date, commande, email, ip };

            string repertoire = DateTime.Now.ToString("yyyyMM");
            string filename = DateTime.Now.ToString("yyyyMMdd");
            string docpath = "C:/Users/Stéphanie Pinto/source/repos/RegistreFoncier/RegistreFoncier/Logs/Complet/" + repertoire + "/" + filename + ".txt";

            logFileInfo = new FileInfo(docpath);
            DirectoryInfo logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);
            if (!logDirInfo.Exists) logDirInfo.Create();
            if (!logFileInfo.Exists)
            {
                fileStream = logFileInfo.Create();
                fileStream.Close();
            }
            else
            {
                fileStream = new FileStream(docpath, FileMode.Append);
                fileStream.Close();
            }

            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(docpath, true))
            {
                for (int i = 0; i < lines.Length; i++)
                {
                    file.Write(String.Format(lines[i] + " \t"));
                }
                file.Write(Environment.NewLine);
            }
        }

        public static void LogDemandeIntercapi(string demande, string email)
        {
            FileStream fileStream;
            FileInfo logFileInfo;

            string date = DateTime.Now.ToString();
            string[] lines = { date, demande, email };

            string repertoire = DateTime.Now.ToString("yyyyMM");
            string filename = DateTime.Now.ToString("yyyyMMdd");
            string docpath = "C:/Users/Stéphanie Pinto/source/repos/RegistreFoncier/RegistreFoncier/Logs/Intercapi/" + repertoire + "/" + filename + ".txt";

            logFileInfo = new FileInfo(docpath);
            DirectoryInfo logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);
            if (!logDirInfo.Exists) logDirInfo.Create();
            if (!logFileInfo.Exists)
            {
                fileStream = logFileInfo.Create();
                fileStream.Close();
            }
            else
            {
                fileStream = new FileStream(docpath, FileMode.Append);
                fileStream.Close();
            }

            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(docpath, true))
            {
                for (int i = 0; i < lines.Length; i++)
                {
                    file.Write(String.Format(lines[i] + " \t"));
                }
                file.Write(Environment.NewLine);
            }
        }
    }
}
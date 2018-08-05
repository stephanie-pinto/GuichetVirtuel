using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace RegistreFoncier.Logs
{
    public class Logs
    {
        public static void LogExtraitPublic(string commande, string email)
        {
            FileStream fileStream;
            FileInfo logFileInfo;

            string date = DateTime.Now.ToString();
            string[] lines = { date, commande, email };

            string repertoire = DateTime.Now.ToString("yyyyMM");
            string filename = DateTime.Now.ToString("yyyyMMdd");
            string docpath = "C:/Users/Stéphanie Pinto/source/repos/RegistreFoncier/RegistreFoncier/Logs/" + repertoire + "/" + filename + ".txt";

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
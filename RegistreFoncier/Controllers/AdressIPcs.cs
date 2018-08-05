using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace RegistreFoncier.Controllers
{
    public static class AdressIPcs
    {
        public static IPAddress GetIp(this HttpRequest request)
        {
            string ipString;
            if (string.IsNullOrEmpty(request.ServerVariables["HTTP_X_FORWARDED_FOR"]))
            {
                ipString = request.ServerVariables["REMOTE_ADDR"];
            }
            else
            {
                ipString = request
                    .ServerVariables["HTTP_X_FORWARDED_FOR"]
                    .Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .FirstOrDefault();
            }

            IPAddress result;
            if (!IPAddress.TryParse(ipString, out result))
            {
                result = IPAddress.None;
            }

            return result;
        }
    }
}
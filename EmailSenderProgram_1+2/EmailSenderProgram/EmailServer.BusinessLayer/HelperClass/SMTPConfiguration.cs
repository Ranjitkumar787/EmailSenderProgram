using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EmailServer.BusinessLayer.HelperClass
{
    public class SMTPConfiguration
    {
        public static SmtpClient ConfigureSMTP(string Host, int Port, string senderEmail, string senderPassword)
        {
            SmtpClient smtpClient = new SmtpClient(Host, Port)
            {
                UseDefaultCredentials = false,
                EnableSsl = true,
                Credentials = new NetworkCredential(senderEmail, senderPassword)
            };
            return smtpClient;

        }
    }
}

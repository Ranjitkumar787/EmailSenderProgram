using EmailServer.BusinessLayer.Utility;
using System;
using System.Net;
using System.Net.Mail;

namespace EmailServer.BusinessLayer.HelperClass
{
    #region Configure SMTP

    /// <summary>
    /// Comfigure SMTP Mail Settings To Send Mail
    /// </summary>
    public class SMTPConfiguration
    {
        public static SmtpClient ConfigureSMTP(string host, int port, string senderEmail, string senderPassword)
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient(host, port)
                {
                    UseDefaultCredentials = false,
                    EnableSsl = true,
                    Credentials = new NetworkCredential(senderEmail, senderPassword)
                };
                return smtpClient;
            }
            catch (Exception ex)
            {
                Logger.ExceptionLog("SMTPConfiguration.txt", "ConfigureSMTP", ex);
                return null;
            }
        }
    }

    #endregion
}

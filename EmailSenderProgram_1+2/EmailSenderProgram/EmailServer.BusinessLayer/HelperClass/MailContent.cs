using EmailServer.BusinessLayer.Utility;
using EmailServer.Data;
using System;
using System.Net.Mail;

namespace EmailServer.BusinessLayer.HelperClass
{
    #region Mail Content 

    /// <summary>
    /// Create Mail Content Using System.Net.Mail.MailMessage
    /// </summary>
    public static class MailContent
    {
        public static MailMessage mailMessage(string receiverMailID,string subject,string messageBody)
        {
            try
            {
                MailMessage message = new MailMessage();
                //Add customer to reciever list
                message.To.Add(receiverMailID);
                //Add subject
                message.Subject = subject;
                //Send mail from info@EO.com
                message.From = new System.Net.Mail.MailAddress(SMTPConfigurationFields.SenderEmail);
                //Add body to mail
                message.Body = messageBody;
                //Need to enable this we are using HTML in message body
                message.IsBodyHtml = true;

                return message;
            }
            catch(Exception ex)
            {
                Logger.ExceptionLog("MailContent.txt", "MailMessage", ex);
                return null;

            }
        }
    }
    
    #endregion
}

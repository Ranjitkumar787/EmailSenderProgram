using EmailServer.BusinessLayer.Utility;
using EmailServer.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EmailServer.BusinessLayer.HelperClass
{
    public static class CreateMailContent
    {
        public static MailMessage mailMessage(string ReceiverMailID,string Subject,string MessageBody)
        {
            try
            {
                System.Net.Mail.MailMessage m = new System.Net.Mail.MailMessage();
                //Add customer to reciever list
                m.To.Add(ReceiverMailID);
                //Add subject
                m.Subject = Subject;
                //Send mail from info@EO.com
                m.From = new System.Net.Mail.MailAddress(SMTPConfigurationFields.SenderEmail);
                //Add body to mail
                m.Body = MessageBody;
                //Need to enable this we are using HTML in message body
                m.IsBodyHtml = true;

                return m;
            }
            catch(Exception ex)
            {
                Logger.ExceptionLog("CreateMailContent.txt", "MailMessage", ex);
                return null;

            }
        }
    }
}

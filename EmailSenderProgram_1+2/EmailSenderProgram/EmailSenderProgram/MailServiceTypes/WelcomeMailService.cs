using EmailSenderProgram.DataModels;
using EmailSenderProgram.IMailServiceTypes;
using EmailSenderProgram.Utilities;
using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace EmailSenderProgram.Mail_Service
{
    /// <summary>
    /// This class represents a fields related to Welcome Mail Service Type
    /// </summary>
    public class WelcomeMailService : IMailService
    {

        /// <summary>
		/// Send a Welcome mail to Newly Registered Customers
		/// </summary>
		/// <returns></returns>
		public  bool sendMail()
        {
            try
            {
                //List all customers
                List<Customer> e = DataLayer.ListCustomers();

                //loop through list of new customers
                for (int i = 0; i < e.Count; i++)
                {
                    //If the customer is newly registered, one day back in time
                    if (e[i].CreatedDateTime > DateTime.Now.AddDays(-1))
                    {
                        //Create a new MailMessage
                        System.Net.Mail.MailMessage m = new System.Net.Mail.MailMessage();
                        //Add customer to reciever list
                        m.To.Add(e[i].Email);
                        //Add subject
                        m.Subject = "Welcome as a new customer at EO!";
                        //Send mail from info@EO.com
                        m.From = new System.Net.Mail.MailAddress(SMTPConfigurationFields.SenderEmail);
                        //Add body to mail
                        m.Body = "Hi " + e[i].Email +
                                 "<br>We would like to welcome you as customer on our site!<br><br>Best Regards,<br>EO Team";
                        //Need to enable this we are using HTML in message body
                        m.IsBodyHtml = true;
#if DEBUG
                        //Don't send mails in debug mode, just write the emails in console
                        Console.WriteLine("Send mail to:" + e[i].Email);                      

#else
                        //Create a SmtpClient to our smtphost: yoursmtphost                      
                        SmtpClient smtp = SMTPConfiguration.ConfigureSMTP(SMTPConfigurationFields.HostName, SMTPConfigurationFields.Port, SMTPConfigurationFields.SenderEmail, SMTPConfigurationFields.SenderPassword);
                    //Send mail
                        smtp.Send(m);
#endif
                    }
                }
                //All mails are sent! Success!
                return true;
            }
            catch (Exception)
            {
                //Something went wrong :(
                return false;
            }
        }

    }
}

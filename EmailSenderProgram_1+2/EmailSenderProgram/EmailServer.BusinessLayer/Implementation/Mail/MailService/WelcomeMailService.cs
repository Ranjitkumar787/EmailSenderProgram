using EmailServer.BusinessLayer.HelperClass;
using EmailServer.BusinessLayer.Interface.IMail.IMailService;
using EmailServer.BusinessLayer.Utility;
using EmailServer.DataAccessLayer;
using EmailServer.Data;
using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace EmailServer.BusinessLayer.Implementation.Mail.MailService
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
		public bool sendMail()
        {
            try
            {
                //List all customers
                List<Customer> Customers = DataLayer.ListCustomers();

                //loop through list of new customers
                for (int i = 0; i < Customers.Count; i++)
                {
                    //If the customer is newly registered, one day back in time
                    if (Customers[i].CreatedDateTime.ToString("ddMMyyyy") == DateTime.Now.AddDays(-1).ToString("ddMMyyyy"))
                    {
                        System.Net.Mail.MailMessage message = MailContent.mailMessage(Customers[i].Email, CustomerEmailTemplate.GetWelcomeMailSubject(), CustomerEmailTemplate.GetWelcomeMailMessage(Customers[i].Email));
                        
#if DEBUG
                        //Don't send mails in debug mode, just write the emails in console
                        Console.WriteLine("Send mail to:" + Customers[i].Email);

#else
                        //Create a SmtpClient to our smtphost: yoursmtphost                      
                        SmtpClient smtp = SMTPConfiguration.ConfigureSMTP(SMTPConfigurationFields.HostName, SMTPConfigurationFields.Port, SMTPConfigurationFields.SenderEmail, SMTPConfigurationFields.SenderPassword);
                    //Send mail
                        smtp.Send(message);
#endif
                    }
                }
                //All mails are sent! Success!
                return true;
            }
            catch (Exception ex)
            {
                Logger.ExceptionLog("WelcomeMailService.txt", "sendMail",ex);
                //Something went wrong :(
                return false;
            }
        }

    }
}

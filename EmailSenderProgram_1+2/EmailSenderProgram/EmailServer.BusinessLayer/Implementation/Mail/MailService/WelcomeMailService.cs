using EmailServer.BusinessLayer.HelperClass;
using EmailServer.BusinessLayer.Interface.IMail.IMailService;
using EmailServer.DataAccessLayer;
using EmailServer.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

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
                List<Customer> e = DataLayer.ListCustomers();

                //loop through list of new customers
                for (int i = 0; i < e.Count; i++)
                {
                    //If the customer is newly registered, one day back in time
                    if (e[i].CreatedDateTime > DateTime.Now.AddDays(-1))
                    {
                        System.Net.Mail.MailMessage m = CreateMailContent.mailMessage(e[i].Email, CustomerEmailTemplate.GetWelcomeMailSubject(), CustomerEmailTemplate.GetWelcomeMailMessage(e[i].Email));
                        
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

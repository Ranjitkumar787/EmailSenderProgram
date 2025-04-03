using EmailServer.BusinessLayer.HelperClass;
using EmailServer.BusinessLayer.Interface.IMail.IMailService;
using EmailServer.BusinessLayer.Utility;
using EmailServer.DataAccessLayer;
using EmailServer.Data;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Linq;

namespace EmailServer.BusinessLayer.Implementation.Mail.MailService
{
    #region ComeBack Mail Service

    /// <summary>
    /// This class represents a fields related to ComeBack Mail Service Type
    /// </summary>
    public class ComeBackMailService : IMailService
    {        

        /// <summary>
        /// Send Mail Implementation
        /// </summary>
        /// <returns></returns>
        public bool sendMail()
        {
            try
            {
                //List all customers 
                List<Customer> customersList = DataLayer.ListCustomers();
                
                //Get Ordered customer emails from order list
                List<string> orderedCustomersEmails = DataLayer.ListOrders().Select(order => order.CustomerEmail).ToList();

                //Get Customers not ordered from ordered emails.
                var CoustomersNotPlacedOrder = customersList.Where(customer => !orderedCustomersEmails.Contains(customer.Email));
                

                    //Send if customer hasn't put order
                    foreach(var customer in CoustomersNotPlacedOrder)
                    {
                        System.Net.Mail.MailMessage message = MailContent.mailMessage(customer.Email, CustomerEmailTemplate.GetWelcomeMailSubject(), CustomerEmailTemplate.GetWelcomeMailMessage(customer.Email));                        
#if DEBUG
                        //Don't send mails in debug mode, just write the emails in console
                        Console.WriteLine("Send mail to:" + customer.Email);
#else
                        //Create a SmtpClient to our smtphost: yoursmtphost
                        SmtpClient smtp = SMTPConfiguration.ConfigureSMTP(SMTPConfigurationFields.HostName, SMTPConfigurationFields.Port, SMTPConfigurationFields.SenderEmail, SMTPConfigurationFields.SenderPassword);
                        //Send mail
                        smtp.Send(message);
#endif
                    }
                
                //All mails are sent! Success!
                return true;
            }
            catch (Exception ex)
            {
                Logger.ExceptionLog("ComeBackMailService.txt", "sendMail", ex);                
                return false;
            }
        }
    }

    #endregion
}

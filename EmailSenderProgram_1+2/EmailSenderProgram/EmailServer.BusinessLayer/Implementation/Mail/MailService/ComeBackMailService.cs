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
{ /// <summary>
  /// This class represents a fields related to ComeBack Mail Service Type
  /// </summary>
    public class ComeBackMailService : IMailService
    {

        /// <summary>
        /// Send Customer ComebackMail
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public bool sendMail()
        {
            try
            {
                //List all customers 
                List<Customer> e = DataLayer.ListCustomers();
                //List all orders
                List<Order> f = DataLayer.ListOrders();

                //loop through list of customers
                foreach (Customer c in e)
                {
                    // We send mail if customer hasn't put an order
                    bool Send = true;
                    //loop through list of orders to see if customer don't exist in that list
                    foreach (Order o in f)
                    {
                        // Email exists in order list
                        if (c.Email == o.CustomerEmail)
                        {
                            //We don't send email to that customer
                            Send = false;
                        }
                    }

                    //Send if customer hasn't put order
                    if (Send == true)
                    {
                        System.Net.Mail.MailMessage m = CreateMailContent.mailMessage(c.Email, CustomerEmailTemplate.GetWelcomeMailSubject(), CustomerEmailTemplate.GetWelcomeMailMessage(c.Email));                        
#if DEBUG
                        //Don't send mails in debug mode, just write the emails in console
                        Console.WriteLine("Send mail to:" + c.Email);                        
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
            catch (Exception ex)
            {
                //Something went wrong :(
                return false;
            }
        }
    }
}

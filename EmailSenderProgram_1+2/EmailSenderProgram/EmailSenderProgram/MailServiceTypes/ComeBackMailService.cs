using EmailSenderProgram.DataModels;
using EmailSenderProgram.IMailServiceTypes;
using EmailSenderProgram.Utilities;
using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace EmailSenderProgram.Mail_Service
{
    /// <summary>
    /// This class represents a fields related to ComeBack Mail Service Type
    /// </summary>
    public class ComeBackMailService : IMailService
    {
        
        /// <summary>
		/// Send Customer ComebackMail
		/// </summary>
		/// <param name="v"></param>
		/// <returns></returns>
		public  bool sendMail()
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
                        //Create a new MailMessage
                        System.Net.Mail.MailMessage m = new System.Net.Mail.MailMessage();
                        //Add customer to reciever list
                        m.To.Add(c.Email);
                        //Add subject
                        m.Subject = "We miss you as a customer";
                        //Send mail from info@EO.com
                        m.From = new System.Net.Mail.MailAddress(SMTPConfigurationFields.SenderEmail);
                        //Add body to mail
                        m.Body = "Hi " + c.Email +
                                 "<br>We miss you as a customer. Our shop is filled with nice products. Here is a voucher that gives you 50 kr to shop for." +
                                 "<br>Voucher: " + GlobalVariables.VoucherCode + //Changed Hardcore Voucher Code Value to configurable value 
                                 "<br><br>Best Regards,<br>EO Team";
                        //Need to enable this we are using HTML in message body
                        m.IsBodyHtml = true;
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

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailServer.DataModels
{
    public static class CustomerEmailTemplate
    {
        public static string GetWelcomeMailSubject()
        {
            return "Welcome as a new customer at EO!";
        }
        public static string GetWelcomeMailMessage(String ReceiverName)
        {
            return "Hi "+ ReceiverName + " <br>We would like to welcome you as customer on our site!<br><br>Best Regards,<br>EO Team";
        }
        public static string GetComeBackMailSubject()
        {
            return "We miss you as a customer";
        }

        public static string GetComeBackMailMesssage(String ReceiverName)
        {
            return "Hi "+ReceiverName+" <br>We miss you as a customer. Our shop is filled with nice products. Here is a voucher that gives you 50 kr to shop for.<br>Voucher: " + GlobalVariables.VoucherCode + //Changed Hardcore Voucher Code Value to configurable value 
                                 "<br><br>Best Regards,<br>EO Team";
        }
    }
}

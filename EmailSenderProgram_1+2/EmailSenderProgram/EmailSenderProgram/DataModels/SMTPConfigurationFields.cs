using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSenderProgram.DataModels
{
    public class SMTPConfigurationFields
    {
        public static string HostName { get; set; }
        public static int Port { get; set; }
        public static string SenderEmail { get; set; }
        public static string SenderPassword { get; set; }

        public SMTPConfigurationFields()
        {
            HostName = ConfigurationSettings.AppSettings["HostName"];
            Port =Convert.ToInt32( ConfigurationSettings.AppSettings["Port"]);
            SenderEmail = ConfigurationSettings.AppSettings["SenderEmail"];
            SenderPassword = ConfigurationSettings.AppSettings["SenderPassword"];
        }  
    }
}

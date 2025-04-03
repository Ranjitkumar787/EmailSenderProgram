using System;
using System.Configuration;

namespace EmailServer.Data
{
    #region  SMTP Mail Configuration Variables
    /// <summary>
    /// Declare and Initialse SMTP Mail Configuration Variables
    /// </summary>
    public class SMTPConfigurationFields
    {
        public static string HostName { get; set; }
        public static int Port { get; set; }
        public static string SenderEmail { get; set; }
        public static string SenderPassword { get; set; }

        public SMTPConfigurationFields()
        {
                HostName = ConfigurationSettings.AppSettings["HostName"];
                Port = Convert.ToInt32(ConfigurationSettings.AppSettings["Port"]);
                SenderEmail = ConfigurationSettings.AppSettings["SenderEmail"];
                SenderPassword = ConfigurationSettings.AppSettings["SenderPassword"];
            
        }
    }
    #endregion
}
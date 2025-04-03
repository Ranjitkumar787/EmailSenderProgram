using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailServer.DataModels
{
    public class GlobalVariables
    {
        public static string VoucherCode { get; set; }
        public static string LogFilePath { get; set; }

        public GlobalVariables()
        {
            VoucherCode = ConfigurationSettings.AppSettings["VoucherCode"];
            LogFilePath = ConfigurationSettings.AppSettings["LogFilePath"];
        }
    }
}

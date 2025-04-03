using System.Configuration;

namespace EmailSenderProgram.DataModels
{
    public class GlobalVariables
    {
        public static string VoucherCode { get; set; }
        public static string LogFilePath { get; set; }

        public GlobalVariables()
        {
            VoucherCode= ConfigurationSettings.AppSettings["VoucherCode"];
            LogFilePath = ConfigurationSettings.AppSettings["LogFilePath"];
        }
    }
}

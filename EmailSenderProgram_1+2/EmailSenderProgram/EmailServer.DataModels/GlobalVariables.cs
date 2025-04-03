using System.Configuration;

namespace EmailServer.Data
{
    #region Global Variables

    /// <summary>
    /// Declare and Initialise Global Variables
    /// </summary>
    public class GlobalVariables
    {
        public static string VoucherCode { get; set; }
        public static string LogFilePath { get; set; }
        public static string LastExecutionDate { get; set; }

        public GlobalVariables()
        {
            VoucherCode = ConfigurationSettings.AppSettings["VoucherCode"];
            LogFilePath = ConfigurationSettings.AppSettings["LogFilePath"];
            LastExecutionDate = ConfigurationSettings.AppSettings["LastExecutionDate"];
        }
    }

    #endregion
}

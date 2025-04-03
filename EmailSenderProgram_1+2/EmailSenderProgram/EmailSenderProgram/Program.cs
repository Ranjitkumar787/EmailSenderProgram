using EmailServer.BusinessLayer.HelperClass;
using EmailServer.BusinessLayer.Implementation.Mail.MailService;
using EmailServer.BusinessLayer.Utility;
using EmailServer.Data;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EmailSenderProgram
{
    internal class Program
	{
        #region Main Method
        /// <summary>
        /// This application is run everyday
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            try {
                
                //Initialize Global Values
                GlobalVariables objGV = new GlobalVariables();
                SMTPConfigurationFields objSCF = new SMTPConfigurationFields();

                // Initialize Cancellation Token
                CancellationTokenSource cancelToken = new CancellationTokenSource();
                
                //Cancel token on any key press to stop the task
                Task.Run(() =>
                {
                    Console.ReadKey();
                    cancelToken.Cancel();
                });

                EmailScheduler.MailScheduler(cancelToken.Token).Wait();                
               
            }
            catch(Exception ex)
            {                
                Logger.ExceptionLog("Program.txt","Main",ex);
            }
			
		}

        #endregion        
    }
}
using EmailServer.BusinessLayer.HelperClass;
using EmailServer.BusinessLayer.Implementation.Mail.MailService;
using EmailServer.DataModels;
using System;

namespace EmailSenderProgram
{
    internal class Program
	{
		/// <summary>
		/// This application is run everyday
		/// </summary>
		/// <param name="args"></param>
		public static void Main(string[] args)
		{
            try {

                //Initialize Global Values
                GlobalVariables objGV = new GlobalVariables();
                SMTPConfigurationFields objSCF = new SMTPConfigurationFields();

                //Dependency Injection injecting WelcomeMailService
                var objSendWelcomeMail = new ProcessMailBasedOnType(new WelcomeMailService());

                //Dependency Injection injecting ComeBackMailService
                var objSendComeBackMail = new ProcessMailBasedOnType(new ComeBackMailService());

                
                //Call the method that do the work for me, I.E. sending the mails
                Console.WriteLine("Send Welcomemail");
                
                var success=objSendWelcomeMail.ProcessMailService();
#if DEBUG
                //Debug mode, always send Comeback mail
                Console.WriteLine("Send Comebackmail");
                success = objSendComeBackMail.ProcessMailService(); //ComeBackMail.DoEmailWork2();
#else
			//Every Sunday run Comeback mail
			if (DateTime.Now.DayOfWeek.Equals(DayOfWeek.Monday))
			{
				Console.WriteLine("Send Comebackmail");
				success = objSendComeBackMail.ProcessMailService();
                }
#endif

                //Check if the sending went OK
                if (success == true)
                {
                    Console.WriteLine("All mails are sent, I hope...");
                }
                //Check if the sending was not going well...
                if (success == false)
                {
                    Console.WriteLine("Oops, something went wrong when sending mail (I think...)");
                }
                //int i = Convert.ToInt32("a");
                Console.ReadKey();
            }
            catch(Exception ex)
            {
                //Logger.ExceptionLog("Program.txt","Main",ex);
            }
			
		}
		
		
		
	}
}
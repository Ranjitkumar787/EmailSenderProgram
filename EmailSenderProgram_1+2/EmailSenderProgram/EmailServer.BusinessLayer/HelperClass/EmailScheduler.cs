using EmailServer.BusinessLayer.Implementation.Mail.MailService;
using EmailServer.BusinessLayer.Utility;
using EmailServer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EmailServer.BusinessLayer.HelperClass
{
    public class EmailScheduler
    {
        /// <summary>
        /// Helper class to execute the program once a day
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task MailScheduler(CancellationToken token)
        {
            try
            {
                //Dependency Injection injecting WelcomeMailService
                var objSendWelcomeMail = new MailService(new WelcomeMailService());

                //Dependency Injection injecting ComeBackMailService
                var objSendComeBackMail = new MailService(new ComeBackMailService());


                while (!token.IsCancellationRequested)
                {
                    try
                    {
                        if (Convert.ToDateTime(GlobalVariables.LastExecutionDate).AddDays(1) < DateTime.Now)
                        {
                            //Call the method that do the work for me, I.E. sending the mails
                            Console.WriteLine("Send Welcomemail");

                            var success = objSendWelcomeMail.ProcessMailService();
#if DEBUG
                            //Debug mode, always send Comeback mail
                            //Console.WriteLine("Send Comebackmail");
                            //success = objSendComeBackMail.ProcessMailService();  //Comment this

#else
                            //Every Sunday run Comeback mail
                            
                            if (DateTime.Now.DayOfWeek.Equals(DayOfWeek.Sunday))
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

                            UpdateAppConfig.UpdateLastExecutionDate();
                            GlobalVariables.LastExecutionDate = DateTime.Now.ToString("yyyy-MM-dd ") + "07:00:00";
                            Console.WriteLine("Last Mail Sent Date Time : {0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        }

                        await Task.Delay(500, token);
                    }
                    catch (Exception ex)
                    { Logger.ExceptionLog("EmailScheduler.txt", "MailScheduler", ex); }
                }



            }
            catch (Exception ex)
            {
                Logger.ExceptionLog("EmailScheduler.txt", "MailScheduler", ex);

            }
        }

    }
}

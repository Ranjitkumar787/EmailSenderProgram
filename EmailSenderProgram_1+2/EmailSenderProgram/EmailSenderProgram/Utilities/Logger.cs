using EmailSenderProgram.DataModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSenderProgram.Utilities
{
    public static class Logger
    {
        private static object _lock=new object();


        public static void ExceptionLog(string FileName,string MethodName,Exception ex)
        {
            lock (_lock)
                try
                {
                    using (StreamWriter sw = new StreamWriter(GlobalVariables.LogFilePath+"//"+FileName, true))
                    {
                        sw.WriteLine($"DateTime : {DateTime.Now}");
                        sw.WriteLine("Method Name : "+MethodName);
                        sw.WriteLine($"Stack Trace :{ex.StackTrace}");
                        sw.WriteLine("-=============================================");
                    }

                }
                catch (Exception e)
                { ExceptionLog("Logger.txt", "ExceptioLog", e); }
        }
    }
}

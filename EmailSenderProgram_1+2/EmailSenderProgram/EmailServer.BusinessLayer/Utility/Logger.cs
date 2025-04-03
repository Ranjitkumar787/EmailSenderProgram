using EmailServer.DataModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailServer.BusinessLayer.Utility
{
    public static class Logger
    {
        private static object _lock = new object();


        public static void ExceptionLog(string FileName, string MethodName, Exception ex)
        {
            lock (_lock)
                try
                {
                    string DirectoryPath = GlobalVariables.LogFilePath + DateTime.Now.ToString("yyyyMMdd");
                    string FilePath = GlobalVariables.LogFilePath + DateTime.Now.ToString("yyyyMMdd") + "//" + FileName;

                    if (!Directory.Exists(DirectoryPath))
                        Directory.CreateDirectory(DirectoryPath);

                    string errorMessage = $"\nDateTime : {DateTime.Now}\n Method Name : " + MethodName + $"\n Stack Trace :{ex.StackTrace}";
                    File.AppendAllText(FilePath, errorMessage);

                }
                catch (Exception e)
                { ExceptionLog("Logger.txt", "ExceptioLog", e); }
        }

    }
}

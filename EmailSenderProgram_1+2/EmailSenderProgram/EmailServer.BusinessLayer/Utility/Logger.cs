using System;
using System.IO;

namespace EmailServer.BusinessLayer.Utility
{
    #region Class Logger 

    public static class Logger
    {
        private static object _lock = new object();

        /// <summary>
        /// Write Exception as Log in Configured File Path.
        /// </summary>
        /// <param name="FileName"></param>
        /// <param name="MethodName"></param>
        /// <param name="ex"></param>
        public static void ExceptionLog(string fileName, string methodName, Exception ex)
        {
            lock (_lock)
                try
                {
                    string DirectoryPath = AppDomain.CurrentDomain.BaseDirectory+"Log//" + DateTime.Now.ToString("yyyyMMdd");
                    string FilePath = AppDomain.CurrentDomain.BaseDirectory + "Log//" + DateTime.Now.ToString("yyyyMMdd") + "//" + fileName;

                    if (!Directory.Exists(DirectoryPath))
                        Directory.CreateDirectory(DirectoryPath);

                    string errorMessage = $"\nDateTime : {DateTime.Now}\n Method Name : " + methodName + $"\n Stack Trace :{ex.StackTrace}";
                    File.AppendAllText(FilePath, errorMessage);

                }
                catch (Exception e)
                { ExceptionLog("Logger.txt", "ExceptioLog", e); }
        }

    }

    #endregion
}

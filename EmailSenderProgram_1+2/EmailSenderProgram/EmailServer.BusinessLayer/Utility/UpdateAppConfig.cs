using System;
using System.Xml;

namespace EmailServer.BusinessLayer.Utility
{
    public static class UpdateAppConfig
    {
        /// <summary>
        /// Update the Last executed time 
        /// </summary>
        public static void UpdateLastExecutionDate()
        {
            try
            {
                string configFilePath = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(configFilePath);

                XmlNode node = xmlDoc.SelectSingleNode("//appSettings");
                if (node != null)
                {
                    XmlElement element = (XmlElement)node.SelectSingleNode("add[@key='LastExecutionDate']");
                    if (element != null)
                    {
                        element.SetAttribute("value", DateTime.Now.ToString("yyyy-MM-dd 07:00:00"));
                    }
                }

                xmlDoc.Save(configFilePath);              
            }
            catch (Exception ex)
            {
                Logger.ExceptionLog("UpdateAppConfig.txt", "UpdateLastExecutionDate", ex);
            }
        }

    }
}

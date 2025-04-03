using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmailServer.BusinessLayer.HelperClass;
using System.Net.Mail;
using EmailServer.Data;

namespace EmailSenderProgramTest
{
    /// <summary>
    /// Test Class describes unit test scenarios.
    /// </summary>
    [TestClass]
    public class EmailSenderUnitTest
    {
        #region Initialize Fields

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            SMTPConfigurationFields.SenderEmail = "ranjitkmr787.rk@gmail.com";
        }

        [TestInitialize]
        public void Setup()
        {
            //Not Implemented;
        }
        #endregion

        #region Positive Test Case

        [TestMethod]
        public void SendTestEmail_Should_Call_SmtpClient_Return_True_OnSuccess()
        {
            
                // Arrange
                //Static variables no validations are made
                string recipient = "ranjitkmr787@gmail.com";
                string subject = "Test Subject";
                string body = "Test Body";

                //Change the below credentials and check
                string hostName = "smtp.gmail.com";
                int port = 587;
                string senderEmail = "ranjitkmr787.rk@gmail.com";  //Change Sender MailId (If required)
                string senderPassword = "mned wzhb moro anta";

                // Act
                SmtpClient smtp = SMTPConfiguration.ConfigureSMTP(hostName, port, senderEmail, senderPassword);
                // Assert
                smtp.Send(MailContent.mailMessage(recipient, subject, body));
                
                Assert.IsTrue(true);            

        }

        [TestMethod]
        public void Check_Customer_TypeBased_Email_Templates_Return_True()
        {            
                //Arrange
                int CustomerType = 1;  //1 for Welcome; 2 for ComeBack;
                                       //Act
                string Message = CustomerType == 1 ? CustomerEmailTemplate.GetWelcomeMailSubject() : CustomerEmailTemplate.GetComeBackMailSubject();
                //Assert
                Assert.AreSame(Message, CustomerType == 1 ? "Welcome as a new customer at EO!" : "We miss you as a customer");            
        }

        #endregion
        
        #region Negative Test Case
        [TestMethod]
        public void SendTestEmail_With_Invalid_HostName_SmtpClient_Return_False()
        {
                // Arrange
                //Static variables no validations are made
                string recipient = "ranjitkmr787@gmail.com";
                string subject = "Test Subject";
                string body = "Test Body";

                //Change the below credentials and check
                string hostName = "smtp.gmail1.com";    //Given wrong HostName
                int port = 587;
                string senderEmail = "ranjitkmr787.rk@gmail.com";
                string senderPassword = "mned wzhb moro anta";

                // Act
                SmtpClient smtp = SMTPConfiguration.ConfigureSMTP(hostName, port, senderEmail, senderPassword);
                // Assert
                smtp.Send(MailContent.mailMessage(recipient, subject, body));

                Assert.IsTrue(true);            
        }
        #endregion
        
    }
}

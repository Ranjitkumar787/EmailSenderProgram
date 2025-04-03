using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmailServer.BusinessLayer.HelperClass;
using System.Net.Mail;
using EmailServer.DataModels;
using EmailServer.BusinessLayer.Utility;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        //private EmailSender _emailSender;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            SMTPConfigurationFields.SenderEmail = "ranjitkmr787.rk@gmail.com";
        }

        [TestInitialize]
        public void Setup()
        {
            //_mockSmtpClient = new Mock<IMessageService>();
            //_emailSender = new EmailSender(_mockSmtpClient.Object);
        }

        [TestMethod]
        public void SendTestEmail_Should_Call_SmtpClient_Return_True_OnSuccess()
        {
            try
            {
                // Arrange
                //Static variables no validations are made
                string recipient = "ranjitkmr787@gmail.com";
                string subject = "Test Subject";
                string body = "Test Body";

                //Change the below credentials and check
                string HostName = "smtp.gmail1.com";
                int Port = 587;
                string SenderEmail = "ranjitkmr787.rk@gmail.com";
                string SenderPassword = "mned wzhb moro anta";

                // Act

                SmtpClient smtp = SMTPConfiguration.ConfigureSMTP(HostName, Port, SenderEmail, SenderPassword);
                // Assert

                smtp.Send(CreateMailContent.mailMessage(recipient, subject, body));
                
                Assert.IsTrue(true);
            }
            catch(Exception e)
            { Logger.ExceptionLog("UnitTest1", "SendTestEmail_Should_Call_SmtpClient_Return_True_OnSuccess", e);
                Assert.IsFalse(true);
            }
        }

        [TestMethod]
        public void Check_Customer_TypeBased_Email_Templates_Return_True()
        {
            //Arrange
            int CustomerType = 1;  //1 for Welcome; 2 for ComeBack;
            //Act
            string Message = CustomerType == 1 ? CustomerEmailTemplate.GetWelcomeMailSubject() : CustomerEmailTemplate.GetComeBackMailSubject();
            //Assert
            Assert.AreSame(Message, CustomerType == 1 ? "Welcome as a new customer at EO!": "We miss you as a customer");
        }
    }
}

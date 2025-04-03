using EmailServer.BusinessLayer.Interface.IMail.IMailService;

namespace EmailServer.BusinessLayer.HelperClass
{
    #region MailService

    /// <summary>
    /// Dependency Injection Helper Class
    /// </summary>
    public class MailService
    {
        private IMailService _mail;


        public MailService(IMailService mail)
        {
            _mail = mail;
        }

        public bool ProcessMailService()
        {
            return _mail.sendMail();
        }
    }

    #endregion
}

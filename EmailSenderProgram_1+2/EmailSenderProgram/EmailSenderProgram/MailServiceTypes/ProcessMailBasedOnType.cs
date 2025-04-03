using EmailSenderProgram.IMailServiceTypes;

namespace EmailSenderProgram.MailServiceTypes
{
    public class ProcessMailBasedOnType
    {
        private IMailService _mail;


         public ProcessMailBasedOnType(IMailService mail)
        {
            _mail = mail;
        }

        public bool ProcessMailService()
        {
           return _mail.sendMail();
        }
    }
}

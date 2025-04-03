using EmailServer.BusinessLayer.Interface.IMail.IMailService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailServer.BusinessLayer.HelperClass
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

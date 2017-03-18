using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Gmail.v1;

namespace Listener.Sender
{
    public class ReportSender
    {
        private GmailService emailService;

        public ReportSender()
        {
            this.emailService = GmailHelper.GetEmaiService();

        }
    }
}

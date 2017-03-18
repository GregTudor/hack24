using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;

namespace Listener.Sender
{
   public class FakeMessageSender
    {
        private GmailService service;

        public FakeMessageSender()
        {
            this.service = GmailHelper.GetEmaiService();
        }

        public void Send(string to, string subject, string message, string from = "engageatron@gmail.com")
        {
            var msg = new AE.Net.Mail.MailMessage
            {
                Subject = subject,
                Body = message,
                From = new MailAddress(from)
            };
            msg.To.Add(new MailAddress(to));
            
            msg.ReplyTo.Add(msg.From); // Bounces without this!!
            var msgStr = new StringWriter();
            msg.Save(msgStr);

           var result = service.Users.Messages.Send(new Message
            {
                Raw = GmailHelper.Base64UrlEncode(msgStr.ToString())
            }, GmailHelper.UserId).Execute();
       
        }
    }
}

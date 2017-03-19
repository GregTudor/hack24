using System;

namespace Common
{
    public sealed class SimpleMessage
    {
        public SimpleMessage(string emailAddress, string subject, string body, DateTime timestamp)
        {
            this.EmailAddress = emailAddress;
            this.Subject = subject;
            Timestamp = timestamp;

            var footerStart = body.IndexOf("--");
            if (footerStart != -1)
                this.Body = body.Substring(0, footerStart);
            else
            {
                this.Body = body;
            }
        }

        public string EmailAddress { get; private set; }
        public string Body { get; private set; }
        public string Subject { get; private set; }
        public DateTime Timestamp { get; set; }
    }
}
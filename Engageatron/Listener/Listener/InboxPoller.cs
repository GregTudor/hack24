using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;

namespace Listener.Listener
{
    public class InboxPoller
    {
        private List<string> seenAlready;
        private GmailService service;

        public InboxPoller()
        {
            this.seenAlready = new List<string>();
            this.service = GmailHelper.GetEmaiService();
        }

        public List<SimpleMessage> Poll()
        {
            var messages = GetMessages(this.service);
            return messages;
        }

        private List<SimpleMessage> GetMessages(GmailService service)
        {
            var messages = new List<Message>();

            var request = service.Users.Messages.List(GmailHelper.UserId);
            request.Q = "is:unread";

            ListMessagesResponse response = request.Execute();
            messages.AddRange(response.Messages);

            //  Console.WriteLine("Received {0} new messages", messages.Count);
            var returnList = new List<SimpleMessage>();
            foreach (var message in messages)
            {
                if (this.seenAlready.Contains(message.Id))
                    continue;

                seenAlready.Add(message.Id);

                var getMessageRequest = service.Users.Messages.Get(GmailHelper.UserId, message.Id);
                getMessageRequest.Format = UsersResource.MessagesResource.GetRequest.FormatEnum.Full;
                var messageResponse = getMessageRequest.Execute();
                if (messageResponse.Payload.MimeType == "text/plain")
                {
                    var body = GmailHelper.Base64UrlDecode(messageResponse.Payload.Body.Data);
                    var emailAddress = messageResponse.Payload.Headers.First(x => x.Name == "Reply-To").Value;
                    var subject = messageResponse.Payload.Headers.First(x => x.Name == "Subject").Value;
                    returnList.Add(new SimpleMessage(emailAddress, subject, body));
                }
                else
                {
                    var emailAddress = messageResponse.Payload.Headers.First(x => x.Name == "Return-Path").Value;
                    var subject = messageResponse.Payload.Headers.First(x => x.Name == "Subject").Value;
                    var body = GmailHelper.Base64UrlDecode(messageResponse.Payload.Parts[0].Body.Data);
                    returnList.Add(new SimpleMessage(emailAddress, subject, body));
                }
                //				var markAsReadRequest = service.Users.Messages.Trash(userId, message.Id);
                //				markAsReadRequest.Execute();
            }

            return returnList;
        }
    }
}
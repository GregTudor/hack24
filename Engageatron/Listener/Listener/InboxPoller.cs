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
        const string userId = "engageatron@gmail.com";

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

            var request = service.Users.Messages.List(userId);
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

                var getMessageRequest = service.Users.Messages.Get(userId, message.Id);
                getMessageRequest.Format = UsersResource.MessagesResource.GetRequest.FormatEnum.Full;
                var messageResponse = getMessageRequest.Execute();

                var bodyData = messageResponse.Payload.Parts[0].Body.Data;
                bodyData = bodyData.Replace('-', '+');
                bodyData = bodyData.Replace('_', '/');
                var data = Convert.FromBase64String(bodyData);
                var decodedString = Encoding.UTF8.GetString(data);
                //  Console.WriteLine("{0}: {1}", message.Id, decodedString);


                returnList.Add(new SimpleMessage()
                {
                    EmailAddress = messageResponse.Payload.Headers.First(x => x.Name == "Return-Path").Value,
                    Subject = messageResponse.Payload.Headers.First(x => x.Name == "Subject").Value,
                    Body = decodedString
                });

                //				var markAsReadRequest = service.Users.Messages.Trash(userId, message.Id);
                //				markAsReadRequest.Execute();
            }

            return returnList;
        }
    }
}
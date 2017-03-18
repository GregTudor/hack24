using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace Listener
{
	class Program
	{
		const string userId = "engageatron@gmail.com";
		static string[] Scopes = { GmailService.Scope.GmailReadonly, GmailService.Scope.GmailModify };
		static string ApplicationName = "Gmail API .NET Quickstart";

		static void Main(string[] args)
		{
			UserCredential credential;

			using (var stream =
				new FileStream("client_secret_906321460956-j2lhkrh8gtr7v00kihn8lpi4pq16hf1l.apps.googleusercontent.com.json", FileMode.Open, FileAccess.Read))
			{
				string credPath = System.Environment.GetFolderPath(
					System.Environment.SpecialFolder.Personal);
				credPath = Path.Combine(credPath, ".credentials/gmail-engageatron.json");

				credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
					GoogleClientSecrets.Load(stream).Secrets,
					Scopes,
					"user",
					CancellationToken.None,
					new FileDataStore(credPath, true)).Result;
				Console.WriteLine("Credential file saved to: " + credPath);
			}

			var service = new GmailService(new BaseClientService.Initializer
			{
				HttpClientInitializer = credential,
				ApplicationName = ApplicationName,
			});

			var messages = new List<Message>();
			var request = service.Users.Messages.List(userId);
			request.Q = "is:unread";

			ListMessagesResponse response = request.Execute();
			messages.AddRange(response.Messages);

			Console.WriteLine("Received {0} new messages", messages.Count);

			foreach (var message in messages)
			{
				var getMessageRequest = service.Users.Messages.Get(userId, message.Id);
				getMessageRequest.Format = UsersResource.MessagesResource.GetRequest.FormatEnum.Full;
				var messageResponse = getMessageRequest.Execute();

				var bodyData = messageResponse.Payload.Parts[0].Body.Data;
				bodyData = bodyData.Replace('-', '+');
				bodyData = bodyData.Replace('_', '/');
				byte[] data = Convert.FromBase64String(bodyData);
				string decodedString = Encoding.UTF8.GetString(data);
				Console.WriteLine("{0}: {1}", message.Id, decodedString);

//				var markAsReadRequest = service.Users.Messages.Trash(userId, message.Id);
//				markAsReadRequest.Execute();
			}
			Console.ReadKey();
		}
	}
}

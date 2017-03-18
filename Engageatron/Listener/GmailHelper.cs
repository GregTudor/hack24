using System;
using System.IO;
using System.Threading;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace Listener
{
    public static class GmailHelper
    {
        static string[] Scopes = { GmailService.Scope.GmailReadonly, GmailService.Scope.GmailModify };
        static string ApplicationName = "Gmail API .NET Quickstart";
        public static GmailService GetEmaiService()
        {
            UserCredential credential;

            using (var stream =
                new FileStream("client_secret_906321460956-j2lhkrh8gtr7v00kihn8lpi4pq16hf1l.apps.googleusercontent.com.json",
                    FileMode.Open, FileAccess.Read))
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
            return service;
        }
    }
}

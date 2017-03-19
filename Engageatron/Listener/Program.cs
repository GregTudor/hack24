using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Common;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Listener.Listener;
using Listener.Sender;
using Listener.Sentiment;
using Thread = System.Threading.Thread;

namespace Listener
{
    class Program
    {
        private static List<string> seenAlready;
        private static FakeMessageSender sender;

        static void Main(string[] args)
        {
            var inboxPoller = new InboxPoller();
            var sentimentService = new TextAnalyticsService();
            var report = new Report();
            sender = new FakeMessageSender();
            var i = 0;

            while (true)
            {
                var newMessages = inboxPoller.Poll();
                foreach (var simpleMessage in newMessages)
                {
                    var payload = new SentimentRequest
                    {
                        Documents = new[]
                        {
                            new DocumentText(Guid.NewGuid().ToString(), simpleMessage.Body),
                        }
                    };
                    var result = sentimentService.Analyse(payload);

                    report.Record(simpleMessage, result.AsMood());

                }

                if (i%59 == 0)
                {
                    SendFake();
                }
                i++;
                Thread.Sleep(1000);
                report.SerializeToDisk(@"d:\hack24data\dump.json");
                WriteReport(report);
            }

            Console.ReadKey();
                
        }

        private static void WriteReport(Report report)
        {
            Console.Clear();
            Console.WriteLine("Overall Mood is");
            Console.WriteLine(report.OverallMood());
            Console.WriteLine();

            foreach (var email in report.ByEmailAddress)
            {
                Console.WriteLine(email.Key);
                foreach (var result in email.Value)
                {
                    Console.WriteLine($"{result.TimeStamp} - {result.Mood}");
                }
               Console.WriteLine("--------------------------------");
            }
            
        }


        private static void SendFake()
        {
            var r = new Random();
            var message = fakeMessages.ElementAt(r.Next(fakeMessages.Length));
            Thread.Sleep
                (100);
            var from = froms.ElementAt(r.Next(froms.Length));

            sender.Send
            ("engageatron@gmail.com", "about my day",
                message
                ,
                from
            );
        }

        private static
            string
            []
            froms =
                new
                    []
                    {
                        "Paula.besson@myunidays.com",
                        "Matt.Holland@myunidays.com",
                        "greg@myunidays.com"
                    }
            ;

        private static
            string
            []
            fakeMessages =
                new
                    []
                    {
                        "This day has been the best day of my life. It was so good, I almost evolved into pure energy, but managed to tame the awesome. Go Me!"
                        ,
                        "AGhhhhhhhhhhhhhhhhhhh!!",
                        "Resharper made me cry. Why does it do that",
                        "One day, I'm gonna by a gun, a kitten and 6 rolls of clingfilm",
                        "Stevie told me about his bins, that was nice of him",
                    }
            ;
    }
}
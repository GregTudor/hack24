using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Listener.Listener;
using Thread = System.Threading.Thread;

namespace Listener
{
    class Program
    {
      
        private static List<string> seenAlready;

        static void Main(string[] args)
        {
           var inboxPoller = new InboxPoller();
            

            while (true)
            {
                var newMessages = inboxPoller.Poll();
               foreach (var simpleMessage in newMessages)
                {
                    Console.WriteLine(simpleMessage.EmailAddress);
                    Console.WriteLine(simpleMessage.Body);
                    Console.WriteLine();
                }

                Thread.Sleep(1000);
            }

            Console.ReadKey();
        }

    }
}

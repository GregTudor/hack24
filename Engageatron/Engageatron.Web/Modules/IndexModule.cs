using System;
using System.IO;
using System.Linq;
using System.Text;
using Common;
using Cronofy;
using Nancy;
using Nancy.Responses;
using Newtonsoft.Json;

namespace Engageatron.Web.Modules
{
    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            Get["/"] = parameters =>
            {
                Report rpt;
                using (var sr = new StreamReader(@"d:\hack24data\dump.json"))
                {
                   rpt =  JsonConvert.DeserializeObject<Report>(sr.ReadToEnd());
                }

                
                return View["index", new IndexResource(rpt)];
            };

            

            Post["/availability"] = _ =>
            {
                var _cronofyAccountClient = new CronofyAccountClient(@"35Qbwo2T_oLpf6DRxvuL5KMd4RJOJdN4");

                var tomorrow = DateTime.UtcNow.AddDays(1);
                var engageatron = new AvailabilityMemberBuilder()
                    .Sub("acc_58cdacd5f619c513de000e5d")
                    .CalendarIds(new[]
                        {"cal_WM2wuvYZxR9BAAtp_J3sPt@hnXsxyW0lN31PHdw", "cal_WM3OWTnUCE39AAuf_mpW7pMuqjME1jF8OqQKqhg"})
                    .Build();



                var participantGroup = new ParticipantGroupBuilder()
                    .AddMember(engageatron)
                    .AllRequired()
                    .Build();

                var availabilityRequest = new AvailabilityRequestBuilder()
                    .AddParticipantGroup(participantGroup)
                    .AddAvailablePeriod(
                        new DateTime(tomorrow.Year, tomorrow.Month, tomorrow.Day, 9, 0, 0, DateTimeKind.Utc),
                        new DateTime(tomorrow.Year, tomorrow.Month, tomorrow.Day, 17, 30, 0, DateTimeKind.Utc))
                    .RequiredDuration(60)
                    .Build();

                var availability = Enumerable.Empty<AvailablePeriod>();
                try
                {
                    availability = _cronofyAccountClient.GetAvailability(availabilityRequest);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                return Response.AsJson(availability);
            };
        }
    }
}
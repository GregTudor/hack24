using System.IO;
using Common;
using Nancy;
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
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Common
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Report
    {
        [JsonProperty]
        public Dictionary<string, List<Result>> ByEmailAddress;
        [JsonProperty]
        public List<decimal> DataForOverallMood;

        public Report()
        {
            this.ByEmailAddress = new Dictionary<string, List<Result>>();
            DataForOverallMood = new List<decimal>();
        }


        public void Record(SimpleMessage simpleMessage, MoodResult asMood)
        {
            if (!this.ByEmailAddress.ContainsKey(simpleMessage.EmailAddress))
                this.ByEmailAddress.Add(simpleMessage.EmailAddress, new List<Result>());

            this.ByEmailAddress[simpleMessage.EmailAddress].Add(new Result
            {
                TimeStamp = simpleMessage.Timestamp,
                Mood = asMood.Mood
            });
            DataForOverallMood.Add(asMood.Score);
        }

        public Mood OverallMood()
        {
            return new MoodResult(DataForOverallMood.Average()).Mood;
        }

        public void SerializeToDisk(string savePath)
        {
            var f = new FileInfo(savePath);
            if (!Directory.Exists(f.Directory.FullName))
                Directory.CreateDirectory(f.DirectoryName);
            using (var sw = new StreamWriter(savePath))
            {
                sw.Write(JsonConvert.SerializeObject(this));
                sw.Flush();
            }
        }
    }

    public class Result
    {
        public DateTime TimeStamp { get; set; }
        public Mood Mood { get; set; }
    }
}
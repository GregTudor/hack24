using System;
using System.Linq;
using Common;

namespace Listener.Sentiment
{
    public static partial class SentimentExtensions
    {
        public static MoodResult AsMood(this SentimentResponse response)
        {
            var averageSentiment = response.Documents.Average(x => x.Score);

            return new MoodResult(averageSentiment);
           
        }
    }
}
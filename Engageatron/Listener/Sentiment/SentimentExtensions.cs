using System;
using System.Linq;

namespace Listener.Sentiment
{
    public static partial class SentimentExtensions
    {
        public static Mood AsMood(this SentimentResponse response)
        {
            var averageSentiment = response.Documents.Average(x => x.Score);

            if (averageSentiment <= 0.2M)
                return Mood.VeryNegative;
            else if (averageSentiment <= 0.4M)
                return Mood.Negative;
            else if (averageSentiment <= 0.6M)
                return Mood.Neutral;
            else if (averageSentiment <= 0.8M)
                return Mood.Positive;
            else
                return Mood.VeryPositive;
        }
    }
}
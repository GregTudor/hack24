namespace Common
{
    public class MoodResult
    {
        public Mood Mood { get; }
        public decimal Score { get; }

        public MoodResult( decimal score)
        {
            Mood = this.GetMood(score);
            Score = score;
        }

        private  Mood GetMood(decimal averageSentiment)
        {
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
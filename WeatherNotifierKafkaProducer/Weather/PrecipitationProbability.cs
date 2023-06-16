namespace WeatherNotifierKafkaProducer.Weather
{
    public class PrecipitationProbability
    {
        public DateTime timestamp { get; set; }
        public int probability { get; set; }

        public PrecipitationProbability(string timestamp, int probability)
        {
            this.timestamp = DateTime.Parse(timestamp);
            this.probability = probability;
        }
    }
}

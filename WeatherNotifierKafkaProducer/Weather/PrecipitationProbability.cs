using System.Text.Json;

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

        public override string? ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}

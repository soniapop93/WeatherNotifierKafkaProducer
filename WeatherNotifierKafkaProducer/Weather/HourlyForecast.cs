namespace WeatherNotifierKafkaProducer.Weather
{
    public class HourlyForecast
    {
        public List<string> time { get; set; }
        public List<int> precipitation_probability { get; set; }
    }
}

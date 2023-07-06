using WeatherNotifierKafkaProducer.Decisions;
using WeatherNotifierKafkaProducer.IP;
using WeatherNotifierKafkaProducer.Kafka;
using WeatherNotifierKafkaProducer.Weather;
using System.Text.Json;

public class Program
{
    public static async Task Main(string[] args)
    {
        /*
           =============================================================
           =============================================================
              The API endoints used in this script are free to use.
              https://ipinfo.io/ip
              https://api.techniknews.net/ipgeo/ + ipAddress
              https://api.open-meteo.com/

            Kafka Producer:
                - uses this weather free API: 
                https://api.open-meteo.com/v1/forecast?latitude=$value&longitude=$value&hourly=precipitation_probability&current_weather=true
                - it makes requests on the API every 5 mins to get new data
                - checks the weather for the current hour
                - if the precipitation probability changed for the current hour will creates a message to be sent to Kafka

           =============================================================
           =============================================================
        */

        Config kafkaConfig = JsonSerializer.Deserialize<Config>(File.ReadAllText("kafka_config.json"));

        RequestsIP requestsIP = new RequestsIP();
        Producer producer = new Producer(kafkaConfig);
        RequestsWeather requestsWeather = new RequestsWeather();

        InfoIP infoIp = requestsIP.getIP();

        ForecastAnalyser forecastAnalyser = new ForecastAnalyser(producer);

        DateTime lastTimeChecked = DateTime.Now.AddMinutes(-5);

        while (true)
        {
            if (lastTimeChecked.AddMinutes(5) < DateTime.Now)
            {
                List<PrecipitationProbability> precipitationProbabilities = requestsWeather.getWeatherInfo(infoIp);

                forecastAnalyser.checkForecast(precipitationProbabilities);

                lastTimeChecked = DateTime.Now;
            }
        }
    }
}
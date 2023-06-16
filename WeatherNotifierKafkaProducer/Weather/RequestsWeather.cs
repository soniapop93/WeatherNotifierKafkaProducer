using System.Text.Json;
using WeatherNotifierKafkaProducer.IP;
using WeatherNotifierKafkaProducer.Utilities;

namespace WeatherNotifierKafkaProducer.Weather
{
    public class RequestsWeather
    {
        public List<PrecipitationProbability> getWeatherInfo(InfoIP infoIp)
        {
            Weather weather = new Weather();
            string endpoint = "https://api.open-meteo.com/v1/forecast?latitude=" + infoIp.lat + "&longitude=" + infoIp.lon + "&hourly=precipitation_probability&current_weather=true";
            weather = JsonSerializer.Deserialize<Weather>(RequestManager.getRequest(endpoint));

            List<PrecipitationProbability> precipitationProbabilities = new List<PrecipitationProbability>();

            for (int i = 0; i < weather.hourly.time.Count; i++)
            {
                PrecipitationProbability precipitationProbability = new PrecipitationProbability(weather.hourly.time[i], weather.hourly.precipitation_probability[i]);

                precipitationProbabilities.Add(precipitationProbability);
            }

            return precipitationProbabilities;
        }

    }
}

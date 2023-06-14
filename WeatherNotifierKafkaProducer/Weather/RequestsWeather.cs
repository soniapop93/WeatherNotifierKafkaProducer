using WeatherNotifierKafkaProducer.Utilities;

namespace WeatherNotifierKafkaProducer.Weather
{
    public class RequestsWeather
    {
        public void weatherInfo()
        {
            getWeatherInfo();
        }

        private void getWeatherInfo(string latitutude, string longitude)
        {
            string endpoint = "https://api.open-meteo.com/v1/forecast?latitude=" + latitutude + "&longitude=" + longitude + "&hourly=precipitation_probability&current_weather=true";
            RequestManager.getRequest(endpoint);
        }

    }
}

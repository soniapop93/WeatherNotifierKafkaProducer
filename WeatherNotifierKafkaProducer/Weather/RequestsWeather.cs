﻿using System.Text.Json;
using WeatherNotifierKafkaProducer.IP;
using WeatherNotifierKafkaProducer.Utilities;

namespace WeatherNotifierKafkaProducer.Weather
{
    public class RequestsWeather
    {
        public void getWeatherInfo(InfoIP infoIp)
        {
            Weather weather = new Weather();
            string endpoint = "https://api.open-meteo.com/v1/forecast?latitude=" + infoIp.lat + "&longitude=" + infoIp.lon + "&hourly=precipitation_probability&current_weather=true";
            weather = JsonSerializer.Deserialize<Weather>(RequestManager.getRequest(endpoint));

        }

    }
}

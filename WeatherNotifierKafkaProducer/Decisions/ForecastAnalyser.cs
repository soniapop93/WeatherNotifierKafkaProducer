using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherNotifierKafkaProducer.Weather;

namespace WeatherNotifierKafkaProducer.Decisions
{
    public class ForecastAnalyser
    {
        List<PrecipitationProbability> precipitationProbabilitiesChecked = new List<PrecipitationProbability>();
        public void checkForecast(List<PrecipitationProbability> precipitationProbabilities)
        {
            for (int i = 0; i < precipitationProbabilities.Count; i++)
            {
                PrecipitationProbability precipitationProbability = precipitationProbabilities[i];

                if (precipitationProbability.timestamp.Hour == DateTime.Now.Hour)
                {

                }
                


        } 
    }
}

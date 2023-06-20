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
                    PrecipitationProbability found = checkIfForecastExists(precipitationProbabilities[i]);
                    if (found == null) 
                    {
                        precipitationProbabilitiesChecked.Add(precipitationProbability);

                        //TODO: implement to send message
                    }
                    else
                    {
                        //TODO:
                        if (found.probability != precipitationProbability.probability)
                        {
                            //TODO: implement to send message
                            precipitationProbabilitiesChecked.Remove(found);
                            precipitationProbabilitiesChecked.Add(precipitationProbability);
                        }
                    }
                }

            }

        }

        private PrecipitationProbability checkIfForecastExists(PrecipitationProbability precipitationProbability)
        {
            for (int i = 0; i < precipitationProbabilitiesChecked.Count; i++)
            {
                if (precipitationProbability.timestamp == precipitationProbabilitiesChecked[i].timestamp)
                {
                    return precipitationProbabilitiesChecked[i];
                }
            }
            return null;
        }
    }
}

using WeatherNotifierKafkaProducer.Kafka;
using WeatherNotifierKafkaProducer.Weather;

namespace WeatherNotifierKafkaProducer.Decisions
{
    public class ForecastAnalyser
    {
        private List<PrecipitationProbability> precipitationProbabilitiesChecked = new List<PrecipitationProbability>();

        private Producer producer;

        public ForecastAnalyser(Producer producer)
        {
            this.producer = producer;
        }

        public void checkForecast(List<PrecipitationProbability> precipitationProbabilities)
        {
            for (int i = 0; i < precipitationProbabilities.Count; i++)
            {
                PrecipitationProbability precipitationProbability = precipitationProbabilities[i];

                if ((precipitationProbability.timestamp.Year == DateTime.Now.Year) && 
                    (precipitationProbability.timestamp.Month == DateTime.Now.Month) && 
                    (precipitationProbability.timestamp.Day == DateTime.Now.Day) && 
                    (precipitationProbability.timestamp.Hour == DateTime.Now.Hour))
                {
                    PrecipitationProbability found = checkIfForecastExists(precipitationProbabilities[i]);
                    if (found == null) 
                    {
                        precipitationProbabilitiesChecked.Add(precipitationProbability);
                        producer.sendMessages(precipitationProbability.ToString());
                        break;
                    }
                    else
                    {
                        if (found.probability != precipitationProbability.probability)
                        {
                            precipitationProbabilitiesChecked.Remove(found);
                            precipitationProbabilitiesChecked.Add(precipitationProbability);
                            producer.sendMessages(precipitationProbability.ToString());
                            break;
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

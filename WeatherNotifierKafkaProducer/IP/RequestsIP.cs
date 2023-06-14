using System.Text.Json;
using WeatherNotifierKafkaProducer.Utilities;

namespace WeatherNotifierKafkaProducer.IP
{
    public class RequestsIP
    {
        private const string endpointIP = "https://ipinfo.io/ip";
        private const string endpointInfoIP = "https://api.techniknews.net/ipgeo/";

        public InfoIP getIP()
        {
            return getInfoIP();
        }

        private InfoIP getInfoIP()
        {
            InfoIP infoIP = new InfoIP();
            infoIP.ip = RequestManager.getRequest(endpointIP);

            infoIP = JsonSerializer.Deserialize<InfoIP>(RequestManager.getRequest(endpointInfoIP + infoIP.ip));

            return infoIP;
        }
    }
}

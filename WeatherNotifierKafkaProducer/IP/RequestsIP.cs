using WeatherNotifierKafkaProducer.Utilities;

namespace WeatherNotifierKafkaProducer.IP
{
    public class RequestsIP
    {
        private const string endpointIP = "https://ipinfo.io/ip";

        public void getIP()
        {
            getInfoIP();
        }

        private void getInfoIP()
        {
            InfoIP infoIP = new InfoIP();
            infoIP.ip = RequestManager.getRequest(endpointIP);

        }
    }
}

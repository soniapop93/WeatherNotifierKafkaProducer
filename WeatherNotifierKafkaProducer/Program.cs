using WeatherNotifierKafkaProducer.IP;

public class Program
{
    public static void Main(string[] args)
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

        RequestsIP requestsIP = new RequestsIP();

        requestsIP.getIP();

    }
}
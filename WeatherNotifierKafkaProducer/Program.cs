using WeatherNotifierKafkaProducer.IP;

public class Program
{
    public static void Main(string[] args)
    {
        /*
           =============================================================
           =============================================================
              The API endoint used in this script is free to use.
              https://api.techniknews.net/ipgeo/ + ipAddress
              https://ipinfo.io/ip
              https://api.open-meteo.com/

           =============================================================
           =============================================================
        */

        RequestsIP requestsIP = new RequestsIP();

        requestsIP.getIP();

    }
}
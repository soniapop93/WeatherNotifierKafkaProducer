using RestSharp;
using System.Net;

namespace WeatherNotifierKafkaProducer.Utilities
{
    public class RequestManager
    {
        public static string getRequest(string endpoint)
        {
            Console.WriteLine("Will request response from endpoint: {0}", endpoint);
            string responseContent = "";
            RestClient client = new RestClient(endpoint);

            RestRequest request = new RestRequest()
            {
                Method = Method.Get
            };
            RestResponse<string> response = client.Execute<string>(request);

            if (response.Content != null)
            {
                responseContent = response.Content;
            }
            return responseContent;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Confluent.Kafka;
using System.Net;
using System.ComponentModel;

namespace WeatherNotifierKafkaProducer.Kafka
{
    public class Producer
    {
        ProducerConfig config = new ProducerConfig
        {
            BootstrapServers = "localhost:9092"
        };


        private const string topicName = "test";

        public Producer()
        {
        }

        public async Task<string> sendMessages (string message)
        {
            try
            {
                var producer = new ProducerBuilder<Null, string>(config).Build();

                DeliveryResult<Null, string> sendMessage = await producer.ProduceAsync(topicName, new Message<Null, string> { Value = message });
                Console.WriteLine("Message sent '{sendMessage.Value}' to '{sendMessage.TopicPartitionOffset}'");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return "sdsd";
        }
        
    }
}

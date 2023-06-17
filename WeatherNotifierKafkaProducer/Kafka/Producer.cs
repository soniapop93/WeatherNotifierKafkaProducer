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
            BootstrapServers = ""
        };

        private const string topicName = "";

        public async void sendMessages (string message)
        {
            IProducer<string, string> producer = new ProducerBuilder<string, string>(config).Build();

            DeliveryResult<string, string> sendMessage = await producer.ProduceAsync(topicName, new Message<string, string> { Key = "", Value = message });
            Console.WriteLine("Message sent '{sendMessage.Value}' to '{sendMessage.TopicPartitionOffset}'");
        }
        
    }
}

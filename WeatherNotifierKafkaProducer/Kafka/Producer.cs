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

        private IProducer<Null, string> producer;
        private const string topicName = "test";

        public Producer()
        {
            producer = new ProducerBuilder<Null, string>(config).Build();
        }

        public async Task sendMessages (string message)
        {
            DeliveryResult<Null, string> sendMessage = await producer.ProduceAsync(topicName, new Message<Null, string> { Value = message });
            Console.WriteLine("Message sent '{sendMessage.Value}' to '{sendMessage.TopicPartitionOffset}'");
        }
    }
}

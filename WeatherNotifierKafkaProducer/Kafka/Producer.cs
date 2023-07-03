using Confluent.Kafka;

namespace WeatherNotifierKafkaProducer.Kafka
{
    public class Producer
    {


        private IProducer<Null, string> producer;
        private string topicName;
        
        public Producer(Config kafkaConfig)
        {

            ProducerConfig config = new ProducerConfig
            {
                BootstrapServers = kafkaConfig.server
            };
            producer = new ProducerBuilder<Null, string>(config).Build();
            topicName = kafkaConfig.topic;
        }

        public async Task sendMessages (string message)
        {
            DeliveryResult<Null, string> sendMessage = await producer.ProduceAsync(topicName, new Message<Null, string> { Value = message });
            Console.WriteLine("Message sent '{sendMessage.Value}' to '{sendMessage.TopicPartitionOffset}'");
        }
    }
}

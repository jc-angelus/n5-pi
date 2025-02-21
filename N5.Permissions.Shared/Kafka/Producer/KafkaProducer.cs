using System;
using System.Threading.Tasks;
using Confluent.Kafka;
using Microsoft.Extensions.Options;

namespace N5.Permissions.Shared.Kafka.Producer
{

    /// <summary>
    /// Developer: Johans Cuellar
    /// Date: 02/19/2025
    /// </summary>
    public class KafkaProducer<Tk, Tv> : IDisposable
    {
        private readonly IProducer<Tk, Tv> _producer;
        private readonly string _topic;

        public KafkaProducer(IOptions<KafkaProducerConfig<Tk, Tv>> topicOptions, IProducer<Tk, Tv> producer)
        {
            _topic = topicOptions.Value.Topic;
            _producer = producer;
        }

        public async Task ProduceAsync(Tk key, Tv value)
        {
            await _producer.ProduceAsync(_topic, new Message<Tk, Tv> { Key = key, Value = value });
        }

        public void Dispose()
        {
            _producer.Dispose();
        }
    }
}
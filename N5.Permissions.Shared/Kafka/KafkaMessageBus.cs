using System.Threading.Tasks;
using N5.Permissions.Shared.Kafka.Producer;

namespace N5.Permissions.Shared.Kafka
{

    /// <summary>
    /// Developer: Johans Cuellar
    /// Date: 02/19/2025
    /// </summary>
    public class KafkaMessageBus<Tk, Tv> : IKafkaMessageBus<Tk, Tv>
    {
        public readonly KafkaProducer<Tk, Tv> _producer;
        public KafkaMessageBus(KafkaProducer<Tk, Tv> producer)
        {
            _producer = producer;
        }
        public async Task PublishAsync(Tk key, Tv message)
        {
            await _producer.ProduceAsync(key, message);
        }
    }
}
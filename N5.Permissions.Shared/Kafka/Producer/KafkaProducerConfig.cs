using Confluent.Kafka;

namespace N5.Permissions.Shared.Kafka.Producer
{

    /// <summary>
    /// Developer: Johans Cuellar
    /// Date: 02/19/2025
    /// </summary>

    public class KafkaProducerConfig<Tk, Tv> : ProducerConfig
    {
        public string Topic { get; set; }
    }
}
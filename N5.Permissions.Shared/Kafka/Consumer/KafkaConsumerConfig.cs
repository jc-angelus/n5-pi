using Confluent.Kafka;

namespace N5.Permissions.Shared.Kafka.Consumer
{

    /// <summary>
    /// Developer: Johans Cuellar
    /// Date: 02/19/2025
    /// </summary>
    public class KafkaConsumerConfig<Tk, Tv> : ConsumerConfig
    {
        public string Topic { get; set; }
        public KafkaConsumerConfig()
        {
            AutoOffsetReset = Confluent.Kafka.AutoOffsetReset.Earliest;
            EnableAutoOffsetStore = false;
        }
    }
}
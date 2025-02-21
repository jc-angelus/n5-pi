using System.Threading.Tasks;

namespace N5.Permissions.Shared.Kafka
{

    /// <summary>
    /// Developer: Johans Cuellar
    /// Date: 02/19/2025
    /// </summary>
    public interface IKafkaMessageBus<Tk, Tv>
    {
        Task PublishAsync(Tk key, Tv message);
    }
}
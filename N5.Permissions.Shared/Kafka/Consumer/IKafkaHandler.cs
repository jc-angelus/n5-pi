using System.Threading.Tasks;

namespace N5.Permissions.Shared.Kafka.Consumer
{

    /// <summary>
    /// Developer: Johans Cuellar
    /// Date: 02/19/2025
    /// </summary>
    public interface IKafkaHandler<Tk, Tv>
    {
        Task HandleAsync(Tk key, Tv value);
    }
}
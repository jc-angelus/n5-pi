using N5.Permissions.Domain.Entities;
using N5.Permissions.Shared.Kafka;

namespace N5.Permissions.Presentation
{
    /// <summary>
    /// Developer: Johans Cuellar
    /// Date: 02/19/2025
    /// </summary>
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(
            this IServiceCollection services,
            ConfigurationManager configuration)
        {
            services.AddControllers();                

            services.AddEndpointsApiExplorer();
            services.AddAutoMapper(typeof(Program));

            services.AddKafkaMessageBus();
            services.AddKafkaProducer<string, Operation>(p =>
               {
                   p.Topic = "operations";
                   p.BootstrapServers = "localhost:9092";
               });
            
            services.AddCors(opt =>
            {
                opt.AddDefaultPolicy(builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            return services;
        }
    }
}

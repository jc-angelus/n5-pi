using Microsoft.EntityFrameworkCore;
using N5.Permissions.Application;
using N5.Permissions.Infrastructure;
using N5.Permissions.Infrastructure.Persistence;
using N5.Permissions.Shared.Kafka;
using N5.Permissions.Domain.Entities;

namespace N5.Permissions.Presentation
{
    /// <summary>
    /// Developer: Johans Cuellar
    /// Date: 02/19/2025
    /// </summary>
    public static class Program
    {
        private static async Task Main(string[] args)
        {            
            var builder = WebApplication.CreateBuilder(args);
            builder.Services
                .AddApplication()
                .AddInfrastructure(builder.Configuration)
                .AddPresentation(builder.Configuration)
                .AddDbContext<PermissionDbContext>(options =>
                {
                    options.UseSqlServer();
                })
               .AddKafkaMessageBus()
               .AddKafkaProducer<string, Operation>(p =>
                {
                    p.Topic = "operations";
                    p.BootstrapServers = "localhost:9092";
                })
                .AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            var serviceScope = app.Services.CreateScope();
            var dataContext = serviceScope.ServiceProvider.GetService<PermissionDbContext>();
            dataContext?.Database.EnsureCreated();

            app.UseHttpsRedirection();
            app.UseCors();
            app.UseAuthorization();
            app.MapControllers();

            await app.RunAsync();
        }
    }
}
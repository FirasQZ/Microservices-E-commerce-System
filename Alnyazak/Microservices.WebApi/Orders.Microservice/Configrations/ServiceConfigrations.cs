using MassTransit;
using Microsoft.EntityFrameworkCore;
using Orders.Microservice.DataContext;
using Orders.Microservice.OrderRepository;
using Orders.Microservice.OrderSupervisor;

namespace Orders.Microservice.Configrations
{
    public static class ServiceConfigrations
    {
        public static IServiceCollection ConfigureSupervisor(this IServiceCollection services)
        {
            services.AddScoped<IOrderSupervisor, OrderSuperv>();
            return services;
        }
        public static IServiceCollection ConfigureRepository(this IServiceCollection services)
        {
            services.AddScoped<IOrderRepo, OrderRepo>();
            return services;
        }
        public static IServiceCollection ConfigureSQLDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ContextDatabase>(opts => opts.UseSqlServer(configuration["ConnectionStrings:E_commerceSystem"]));
            return services;
        }

    }
}

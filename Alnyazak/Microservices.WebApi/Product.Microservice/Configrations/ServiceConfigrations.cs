using AutoMapper;
using Product.Microservice.Data;
using Product.Microservice.Entity.ViewModels;
using Product.Microservice.Models;
using Microsoft.EntityFrameworkCore;
using Product.Microservice.ServiceSupervisor;
using Product.Microservice.ServiceRepository;

namespace Product.Microservice.Configrations
{
    public static class ServiceConfigrations
    {
        public static IServiceCollection ConfigureMapper(this IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {

                cfg.CreateMap<ProductDetailsVM, ProductDetails>().ReverseMap();
               

            });
            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
            return services;
        }
        public static IServiceCollection ConfigureSupervisor(this IServiceCollection services)
        {
            services.AddScoped<IProductServiceSupervisor, ProductServiceSupervisor>();
            return services;
        }
        public static IServiceCollection ConfigureRepository(this IServiceCollection services)
        {
            services.AddScoped<IProductServicesRepo, ProductServiceRepo>();
            return services;
        }
        public static IServiceCollection ConfigureSQLDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DatabaseContext>(opts => opts.UseSqlServer(configuration["ConnectionStrings:E_commerceSystem"]));
            return services;
        }
    }
}

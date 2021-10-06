using Microsoft.Extensions.DependencyInjection;
using Refactor.WebApi.Interface;
using Refactor.WebApi.Validators;

namespace Refactor.WebApi.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddTransient<IValidator, KenyaNationalIdValidator>();
            services.AddTransient<IValidator, KenyaInternationalPassportValidator>();
            services.AddTransient<IValidator, RwandaNationalIdValidator>();
            services.AddTransient<IValidator, UgandaNationalIdValidator>();

            // Assembly.GetExecutingAssembly().GetTypes()
            //     .Where(t => t.IsAssignableTo(typeof(IValidator)) && !t.IsAbstract).ToList()
            //     .ForEach(t =>
            //     {
            //         services.AddTransient(typeof(IValidator), t);
            //     });
            return services;
        }
    }
}
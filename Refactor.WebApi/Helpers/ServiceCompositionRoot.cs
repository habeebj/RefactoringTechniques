using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace Refactor.WebApi.Helpers
{
    public static class ServiceCompositionRoot
    {
        private static IServiceCollection _services;
        private static IServiceCollection _serviceDescriptors;

        public static void Set(IServiceCollection services)
        {
            _services = services;
        }
        public static T GetService<T>(string name)
        {
            using (var scope = BeginLifetimeScope())
            {
                var services = scope.ServiceProvider.GetServices<T>();

                var type = services.FirstOrDefault(
                                   c => c.GetType().Name.ToLowerInvariant() == name.ToLowerInvariant() ||
                                   c.GetType().Name.ToLowerInvariant().StartsWith(name.ToLowerInvariant()));
                return type;
            }


        }
        public static T GetService<T>(Func<T, bool> predicate)
        {
            using (var scope = BeginLifetimeScope())
            {

                var services = scope.ServiceProvider.GetServices<T>();

                var type = services.FirstOrDefault(predicate);

                return type;
            }
        }

        public static IServiceScope BeginLifetimeScope()
        {
            var provider = _services.BuildServiceProvider(new ServiceProviderOptions() { ValidateScopes = true, ValidateOnBuild = true });
            return provider.CreateScope();
        }
    }
}
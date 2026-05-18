using Microsoft.Extensions.DependencyInjection;
using PS.StringOpsService.Application.Factories;
using PS.StringOpsService.Application.Services;

namespace PS.StringOpsService.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddSingleton<StringProcessor>();
            services.AddSingleton<OperationFactory>();

            return services;
        }
    }
}

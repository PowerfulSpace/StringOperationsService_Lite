using Microsoft.Extensions.DependencyInjection;
using PS.StringOpsService.Application.Factories;
using PS.StringOpsService.Application.Middleware;
using PS.StringOpsService.Application.Middleware.Implementations;
using PS.StringOpsService.Application.Middleware.Interfaces;
using PS.StringOpsService.Application.Services;

namespace PS.StringOpsService.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddSingleton<StringProcessor>();
            services.AddSingleton<OperationFactory>();

            services.AddSingleton<IProcessMiddleware, LoggingMiddleware>();
            services.AddSingleton<IProcessMiddleware, TimingMiddleware>();

            services.AddSingleton<MiddlewarePipelineBuilder>();


            return services;
        }
    }
}

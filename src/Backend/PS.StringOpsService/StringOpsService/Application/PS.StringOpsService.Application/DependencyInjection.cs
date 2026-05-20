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
            services
                .AddApplicationMediatR();

            services.AddSingleton<StringProcessor>();
            services.AddSingleton<OperationFactory>();

            services.AddSingleton<IProcessMiddleware, LoggingMiddleware>();
            services.AddSingleton<IProcessMiddleware, TimingMiddleware>();

            services.AddSingleton<MiddlewarePipelineBuilder>();


            return services;
        }

        private static IServiceCollection AddApplicationMediatR(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
            });

            return services;
        }
    }
}

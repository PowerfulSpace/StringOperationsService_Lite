using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PS.StringOpsService.Application.Behaviors;
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
                .AddApplicationMediatR()
                .AddApplicationValidation()
                .AddCoreProcessing()
                .AddProcessMiddleware();

            return services;
        }

        private static IServiceCollection AddApplicationValidation(this IServiceCollection services)
        {
            // Регистрируем все валидаторы из Application сборки
            services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

            // Добавляем pipeline behavior для MediatR
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

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

        private static IServiceCollection AddProcessMiddleware(this IServiceCollection services)
        {
            services.AddSingleton<IProcessMiddleware, LoggingMiddleware>();
            services.AddSingleton<IProcessMiddleware, TimingMiddleware>();
            return services;
        }

        private static IServiceCollection AddCoreProcessing(this IServiceCollection services)
        {
            services.AddSingleton<StringProcessor>();
            services.AddSingleton<OperationFactory>();
            services.AddSingleton<MiddlewarePipelineBuilder>();
            return services;
        }
    }
}

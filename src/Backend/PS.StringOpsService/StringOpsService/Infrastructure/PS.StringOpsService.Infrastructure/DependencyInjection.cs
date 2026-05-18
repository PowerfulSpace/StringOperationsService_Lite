using Microsoft.Extensions.DependencyInjection;
using PS.StringOpsService.Application.OperationCatalog;
using PS.StringOpsService.Infrastructure.Catalog;

namespace PS.StringOpsService.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IOperationCatalog, OperationCatalog>();

            return services;
        }
    }
}

using PS.StringOpsService.Application.OperationCatalog;
using PS.StringOpsService.Infrastructure.Descriptors;

namespace PS.StringOpsService.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddOpenApi();

            return services;
        }

        public static WebApplication UsePresentation(this WebApplication app)
        {

            var registry = app.Services.GetRequiredService<IOperationCatalog>();

            registry.Add("trim", new TrimOperationDescriptor());
            registry.Add("upper", new UpperOperationDescriptor());
            registry.Add("reverse", new ReverseOperationDescriptor());

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.MapControllers();

            return app;
        }
    }
}

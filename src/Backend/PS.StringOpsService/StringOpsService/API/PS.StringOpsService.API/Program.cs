using PS.StringOpsService.Application.Catalog;
using PS.StringOpsService.Application.Factories;
using PS.StringOpsService.Application.Services;
using PS.StringOpsService.Infrastructure.Catalog;
using PS.StringOpsService.Infrastructure.Registrations;

var builder = WebApplication.CreateBuilder(args);




builder.Services.AddSingleton<StringProcessor>();
builder.Services.AddSingleton<OperationFactory>();

builder.Services.AddSingleton<IOperationCatalog, OperationCatalog>();




builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();



var registry = app.Services.GetRequiredService<IOperationCatalog>();

registry.Add("trim", new TrimOperationRegistration());
registry.Add("upper", new UpperOperationRegistration());
registry.Add("reverse", new ReverseOperationRegistration());



if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();


app.Run();

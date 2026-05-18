using PS.StringOpsService.Application.Factories;
using PS.StringOpsService.Application.OperationCatalog;
using PS.StringOpsService.Application.Services;
using PS.StringOpsService.Infrastructure.Descriptors;
using PS.StringOpsService.Infrastructure.OperationCatalog;

var builder = WebApplication.CreateBuilder(args);




builder.Services.AddSingleton<StringProcessor>();
builder.Services.AddSingleton<OperationFactory>();

builder.Services.AddSingleton<IOperationCatalog, OperationCatalog>();




builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();



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


app.Run();

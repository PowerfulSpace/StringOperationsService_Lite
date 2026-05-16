using PS.StringOpsService.Application.Factories;
using PS.StringOpsService.Application.Registry.Interfaces;
using PS.StringOpsService.Application.Services;
using PS.StringOpsService.Infrastructure.Registrations;
using PS.StringOpsService.Infrastructure.Registry;

var builder = WebApplication.CreateBuilder(args);




builder.Services.AddSingleton<StringProcessor>();
builder.Services.AddSingleton<OperationFactory>();

builder.Services.AddSingleton<IOperationRegistry, OperationRegistry>();




builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();



var registry = app.Services.GetRequiredService<IOperationRegistry>();

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

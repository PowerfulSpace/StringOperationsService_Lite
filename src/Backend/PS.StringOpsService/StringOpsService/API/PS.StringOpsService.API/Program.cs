using PS.StringOpsService.API;
using PS.StringOpsService.Application;
using PS.StringOpsService.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddPresentation()
    .AddApplication()
    .AddInfrastructure();


var app = builder.Build();

app.UsePresentation();

app.Run();

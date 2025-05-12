using Tutorial9.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddOpenApi();

builder.Services.AddScoped<IVisitService, VisitService>();
builder.Services.AddScoped<IClientService, VisitService.ClientService>();
builder.Services.AddScoped<IMechanicService, VisitService.MechanicService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
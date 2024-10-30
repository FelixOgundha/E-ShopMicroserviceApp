using BuildingBlocks.Behaviors;
using Microsoft.AspNetCore.Hosting;

var builder = WebApplication.CreateBuilder(args);

var assembly = typeof(Program).Assembly;
// Add services to the container.
builder.Services.AddMediatR( cfg =>
    {
        cfg.RegisterServicesFromAssembly(assembly);
        cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
    }
);
builder.Services.AddValidatorsFromAssembly(assembly);
builder.Services.AddCarter();
builder.Services.AddMarten(opt =>
{
    opt.Connection(builder.Configuration.GetConnectionString("database")!);
}).UseLightweightSessions();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.MapCarter();

app.Run();



using Microsoft.AspNetCore.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
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



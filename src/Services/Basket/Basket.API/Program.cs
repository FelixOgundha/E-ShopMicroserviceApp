
var builder = WebApplication.CreateBuilder(args);

//Services
var assembly = typeof(Program).Assembly;

// Add services to the container.
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(assembly);
    cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
    cfg.AddOpenBehavior(typeof(LoggingBehavior<,>));
}
);
builder.Services.AddValidatorsFromAssembly(assembly);
builder.Services.AddCarter();



var app = builder.Build();

//Configuration for HTTP Request Pipeline

app.Run();

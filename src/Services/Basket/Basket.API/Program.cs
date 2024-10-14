var builder = WebApplication.CreateBuilder(args);

//Services

var app = builder.Build();

//Configuration for HTTP Request Pipeline

app.Run();

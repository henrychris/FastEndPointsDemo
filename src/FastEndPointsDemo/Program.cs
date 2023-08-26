using FastEndpoints;
using FastEndpoints.Swagger;
using FastEndPointsDemo;

var builder = WebApplication.CreateBuilder();
builder.Services.AddFastEndpoints().SwaggerDocument();
builder.Services.AddScoped<IAuthService, AuthService>();

var app = builder.Build();
app.UseFastEndpoints().UseSwaggerGen().UseDefaultExceptionHandler();

app.Run();
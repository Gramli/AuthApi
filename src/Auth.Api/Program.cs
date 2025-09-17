using Auth.Api.Configuration;
using Auth.Api.EndpointBuilders;
using Auth.Api.Midllewares;
using Auth.Core.Configuration;
using Auth.Infrastructure.Configuration;
using SmallApiToolkit.Extensions;
using SmallApiToolkit.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureSwagger();
builder.Services.ConfigureAuthentication(builder.Configuration);
builder.Services.ConfigureAuthorization();

builder.Services
    .AddApi()
    .AddCore()
    .AddInfrastructure(builder.Configuration);

var corsPolicyName = builder.Services.AddCorsByConfiguration(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(corsPolicyName);

app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();

app.UseMiddleware<ExceptionMiddleware>();
app.UseMiddleware<LoggingMiddleware>();
app.UseMiddleware<ClaimsMiddleware>();

app.BuildAuthEndpoints();
app.BuildUserEndpoints();
app.BuildServiceEndpoints();

await app.Services.AddDefaultRoles();
await app.Services.AddDefaultUsers();

app.Run();

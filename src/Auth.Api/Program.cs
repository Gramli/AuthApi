using Auth.Api.Configuration;
using Auth.Api.EndpointBuilders;
using Auth.Api.Midllewares;
using Auth.Core.Configuration;
using Auth.Infrastructure.Configuration;
using SmallApiToolkit.Extensions;
using SmallApiToolkit.Middleware;
using System.Security.Principal;

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

app.MapVersionGroup(1)
   .BuildAuthEndpoints();
app.MapVersionGroup(1)
   .BuildUserEndpoints();
app.MapVersionGroup(1)
   .BuildServiceEndpoints();

await app.Services.AddDefaultRoles();
await app.Services.AddDefaultUsers();

app.Run();

using Auth.Api.Configuration;
using Auth.Api.EndpointBuilders;
using Auth.Api.Midlewares;
using Auth.Core.Configuration;
using Auth.Infrastructure.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureSwagger();
builder.Services.ConfigureAuthentication(builder.Configuration);
builder.Services.ConfigureAuthorization();

builder.Services
    .AddCore()
    .AddInfrastructure(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();

app.UseMiddleware<ExceptionMiddleware>();

app.BuildUserEndpoints()
   .BuildServiceEndpoints();

await app.Services.AddDefaultRoles();
await app.Services.AddDefaultUsers();

app.Run();

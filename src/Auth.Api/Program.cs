using Auth.Api.Configuration;
using Auth.Api.EndpointBuilders;
using Auth.Api.Midllewares;
using Auth.Core.Configuration;
using Auth.Infrastructure.Configuration;
using SmallApiToolkit.Extensions;
using SmallApiToolkit.Middleware;

try
{
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
    app.UseMiddleware<LoggingMiddleware>();
    app.UseMiddleware<ClaimsMiddleware>();

    app.MapVersionGroup(1)
       .BuildUserEndpoints()
       .BuildServiceEndpoints();

    await app.Services.AddDefaultRoles();
    await app.Services.AddDefaultUsers();

    app.Run();
}
catch(Exception ex)
{

}

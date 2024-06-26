using api.Data;
using api.Extensions;
using api.Middleware;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplicationSerices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();



var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();
app.UseCors(builder =>builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200"));

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
var  services = scope.ServiceProvider;
try 
{
    var context = services.GetRequiredService<DataContext>();
    await context.Database.MigrateAsync();
    await Seed.SeedUser(context);
}
catch(Exception ex)
{
    var logger  = services.GetService<ILogger<Program>>();
    logger.LogError(ex,"An error occured during migration");
}


app.Run();

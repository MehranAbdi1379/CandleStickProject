using CandleStick.Infranstructure;
using CandleStick.Infranstructure.Repository;
using CandleStick.Service;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace CandleStick.API.Extentions
{
    public static class Extensions
    {
        public static void AddDBContext(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<CandleStickDBContext>(option
    => option.UseSqlServer(builder.Configuration.GetConnectionString("SQLConnectionString")));
        }

        public static void AddMediatR(this WebApplicationBuilder builder)
        {
            builder.Services.AddMediatR(x => x.RegisterServicesFromAssemblies(typeof(MediatREntryPointClass).Assembly));
        }

        public static void AddDIForServices(this IServiceCollection service)
        {
            service.AddScoped<CandleStickModelService>();
        }

        public static void AddDIForRepositories(this IServiceCollection service)
        {
            service.AddScoped<CandleStickRepository>();
        }

        public static void AddHostedServices(this IServiceCollection service)
        {
            service.AddHostedService<CandleStickAverageBackgroundService>();
        }

        public static void ConfigureSeriLog(this IServiceCollection services)
        {
            Log.Logger = new LoggerConfiguration()
        .WriteTo.File("LogFile.log")
        .CreateLogger();
        }
    }
}

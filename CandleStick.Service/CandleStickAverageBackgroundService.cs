using CandleStick.Domain.Models;
using CandleStick.Infranstructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandleStick.Service
{
    // Example of a background service
    public class CandleStickAverageBackgroundService : IHostedService
    {
        private readonly ILogger<CandleStickAverageBackgroundService> logger;
        private Timer timer;
        private readonly IServiceScopeFactory scopeFactory;

        public CandleStickAverageBackgroundService(ILogger<CandleStickAverageBackgroundService> logger
            , IServiceScopeFactory scopeFactory)
        {
            this.logger = logger;
            this.scopeFactory = scopeFactory;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            timer = new Timer(CheckAndSetNullAverages, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
            logger.LogInformation("CandleStick Average Background Service is started.");
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            timer.Dispose();
            logger.LogInformation("CandleStick Average Background Service is stopped.");
            return Task.CompletedTask;
        }

        private void CheckAndSetNullAverages(object state)
        {
            using (var scope = scopeFactory.CreateScope())
            {
                var repository = scope.ServiceProvider.GetRequiredService<CandleStickRepository>();
                var candleSticksWithoutAverage = GetCandleSticksWithNullAverage(repository);
                if (candleSticksWithoutAverage.Count != 0)
                {
                    SetCandleStickAverage(repository,candleSticksWithoutAverage);
                    repository.SaveChanges();
                }
            }
        }

        private List<CandleStickModel> GetCandleSticksWithNullAverage(CandleStickRepository repository)
        {
            return repository.GetAll().Where(c => c.AveragePrice is null).ToList();
        }

        private void SetCandleStickAverage(CandleStickRepository repository, List<CandleStickModel> candleSticksWithoutAverage)
        {
            foreach (var candleStick in candleSticksWithoutAverage)
            {
                candleStick.SetAveragePrice();
                repository.Update(candleStick);
                logger.LogInformation($"Average for candleStick with the id of {candleStick.Id} is set to {candleStick.AveragePrice}");
            }
        }
    }

}

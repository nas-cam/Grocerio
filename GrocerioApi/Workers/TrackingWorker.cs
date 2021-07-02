using GrocerioApi.Services.Purchase;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GrocerioApi.Workers
{
    public class TrackingWorker : BackgroundService
    {

        private readonly IPurchaseService _purchaseService;

        public TrackingWorker(IServiceScopeFactory factory)
        {
            _purchaseService = factory.CreateScope().ServiceProvider.GetService<IPurchaseService>();
        }


        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {

                //move tracking items
                _purchaseService.MoveTrackingItems();

                //repeat every day
                await Task.Delay(86400000, stoppingToken);
            }
        }
    }
}

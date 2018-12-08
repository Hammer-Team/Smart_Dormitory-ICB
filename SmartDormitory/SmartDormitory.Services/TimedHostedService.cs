using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SmartDormitory.Data.Models;
using SmartDormitory.Services.External.Contracts;
using SmartDormitory.Services.External.DTOs;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SmartDormitory.Services
{
    public class TimedHostedService : IHostedService, IDisposable
    {
        private readonly IServiceProvider service;
        private Timer timer;
        private IDictionary<string, Sensor> listOfSensors;

        public TimedHostedService( IServiceProvider service)
        {
            this.service = service;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {

            string report = InitialSensorLoad();

            this.timer = new Timer(CheckForNewSensor, null, TimeSpan.Zero, TimeSpan.FromSeconds(10));

            this.timer = new Timer(UpdateSensor, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));

            return Task.CompletedTask;
        }

        private void CheckForNewSensor(object state)
        {
            int number = listOfSensors.Count;

            using (var scope = service.CreateScope())
            {
                var iCBApiService = scope.ServiceProvider.GetRequiredService<IRestClientService>();
                listOfSensors = iCBApiService.CheckForNewSensor(listOfSensors);
            }

            number = listOfSensors.Count - number;
        }

        private string InitialSensorLoad()
        {
            using (var scope = service.CreateScope())
            {
                var service = scope.ServiceProvider.GetRequiredService<IRestClientService>();
                listOfSensors = service.InitialSensorLoad();
            }
            return $"Initial sensor load was completed on {DateTime.Now.Date}";
        }

        private void UpdateSensor(object state)
        {
            using (var scope = service.CreateScope())
            {
                var service = scope.ServiceProvider.GetRequiredService<IRestClientService>();
                listOfSensors = service.UpdateSensors(listOfSensors);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            this.timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            this.timer?.Dispose();
        }
    }
}
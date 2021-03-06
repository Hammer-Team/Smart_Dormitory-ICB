﻿using Microsoft.Extensions.DependencyInjection;
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
        private Timer timerForCheckNewSensor;
        private Timer timerForUpdateSensor;
        private Timer timerForUpdateUserSensor;
        private IDictionary<string, Sensor> listOfSensors;
        private IDictionary<string, SensorsFromUser> listOfSensorsFromUsers;

        public TimedHostedService( IServiceProvider service)
        {
            this.service = service;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            string report = InitialSensorLoad();

            string reportUserSensors = InitialSensorFromUsersLoad();

            this.timerForCheckNewSensor = new Timer(CheckForNewSensor, null, TimeSpan.Zero, TimeSpan.FromSeconds(10));

            this.timerForUpdateSensor = new Timer(UpdateSensorFromUsers, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));

            this.timerForUpdateUserSensor = new Timer(UpdateSensor, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
            
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

        private string InitialSensorFromUsersLoad()
        {
            using (var scope = service.CreateScope())
            {
                var service = scope.ServiceProvider.GetRequiredService<IRestClientService>();
                listOfSensorsFromUsers = service.InitialSensorsFromUsersLoad();
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

        private void UpdateSensorFromUsers(object state)
        {
            using (var scope = service.CreateScope())
            {
                var service = scope.ServiceProvider.GetRequiredService<IRestClientService>();

                listOfSensorsFromUsers = service.UpdateSensorsFromUsers(listOfSensorsFromUsers);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            this.timerForCheckNewSensor?.Change(Timeout.Infinite, 0);
            this.timerForUpdateSensor?.Change(Timeout.Infinite, 0);
            this.timerForUpdateUserSensor?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            this.timerForCheckNewSensor?.Dispose();
            this.timerForUpdateSensor?.Dispose();
            this.timerForUpdateUserSensor?.Dispose();
        }
    }
}
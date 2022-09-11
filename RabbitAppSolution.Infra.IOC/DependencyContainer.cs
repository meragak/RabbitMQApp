using Microsoft.Extensions.DependencyInjection;
using RabbitAppSolution.Infra.Bus;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitAppSolution.Infra.IOC
{
    class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection service)
        {
            //our domai  bus
            service.AddTransient<IEventBus, RabbitMQBus>();
        }
    }
}

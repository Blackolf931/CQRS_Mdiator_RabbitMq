using Bll.RabbitMq;
using BLL.Interfaces;
using BLL.services;
using CQRS_Mediator.RabbitMq;
using DAL.DI;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BLL.DI
{
    public static class BusinessLogicRegister
    {
        public static void AddBusinessLogic(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<IRabbitMqService, RabbitMqService>();
            services.AddMediatR(typeof(BusinessLogicRegister));
            services.AddDataAcces(config);
        }
    }
}

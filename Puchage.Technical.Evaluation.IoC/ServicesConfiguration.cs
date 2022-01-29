
using Microsoft.Extensions.DependencyInjection;
using Puchage.Technical.Evaluation.Application.Interfaces;
using Puchage.Technical.Evaluation.Application.Services;
using Puchage.Technical.Evaluation.Domain.Interfaces.Repositories;
using Puchage.Technical.Evaluation.infrastructure.Context;
using Puchage.Technical.Evaluation.infrastructure.Repositories;
using System;


namespace Puchage.Technical.Evaluation.IoC
{
    public static class ServicesConfiguration
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
           services.AddScoped<IContextDatabase, ContextDatabase> ();
           services.AddScoped<IPurchaseCurrencyRepository, PurchaseCurrencyRepository>();
            services.AddScoped<IPurchaseCurrencyService, PurchaseCurrencyService>();


        }
    }
}

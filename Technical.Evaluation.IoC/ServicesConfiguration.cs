using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Puchage.Technical.Evaluation.infrastructure.Repositories;
using System;
using Technical.Evaluation.Application.Interfaces;
using Technical.Evaluation.Application.Services;
using Technical.Evaluation.Domain.Interfaces;
using Technical.Evaluation.infrastructure.Context;
using Technical.Evaluation.infrastructure.Service;

namespace Technical.Evaluation.IoC
{
    public static class ServicesConfiguration
    {
        public static void AddCustomServices(this IServiceCollection services)
        {

           
   

            services.AddScoped< ICurrencyExchange  , CurrencyExchange> ();
           // services.AddScoped<StrategyConecctionHTTP>();

            using (var serviceProvider = services.BuildServiceProvider())
            {
                var configuration = serviceProvider.GetService<IConfiguration>();
                //  services.AddScoped<StrategyConecctionHTTP>(sp => new StrategyConecctionHTTP(configuration));

                StrategyConecctionHTTP.WSStrategyConecctionHTTPInstance(configuration);

            }

            services.AddScoped<IContextDatabase, ContextDatabase>();
            services.AddScoped<ICurrencyRepository, CurrencyRepository>();

        }
    }
}

using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Technical.Evaluation.infrastructure.Service
{
    public class StrategyConecctionHTTP
    {
        private static IJsonConnectionHttp _JsonConnectionHttp;
        private static IConfiguration _configuration;
        public  StrategyConecctionHTTP(IConfiguration configuration)
        {

            _configuration = configuration;

        }
        public static void WSStrategyConecctionHTTPInstance(IConfiguration configuration)
        {

            _configuration = configuration;
        }
        public enum ListServices
        {
            SERVICE_CURRENCY_EXCHANGE,
            
        }
 

        public static IJsonConnectionHttp ConnectionJson( ListServices listServices)
        {
            
            switch (listServices)
            {
                case ListServices.SERVICE_CURRENCY_EXCHANGE:
                    _JsonConnectionHttp = new jsonConnectionHttp(_configuration["UrlApiCurrencyExchange:WSCurrencyExchange"]);
                break;

            }

            return _JsonConnectionHttp;
        }

    }
}

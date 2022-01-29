using Microsoft.Extensions.Configuration;
using MS.AFORO255.Cross.Proxy.Proxy;
using Newtonsoft.Json;
using Polly;
using Polly.CircuitBreaker;
using Puchage.Technical.Evaluation.Application.DTO;
using Puchage.Technical.Evaluation.Application.Interfaces;
using Puchage.Technical.Evaluation.Domain.Entitites.CurrencyAmount;
using Puchage.Technical.Evaluation.Domain.Interfaces.Repositories;
using Puchage.Technical.Evaluation.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Puchage.Technical.Evaluation.Application.Services
{
    public class PurchaseCurrencyService: IPurchaseCurrencyService
    {
        private readonly IConfiguration _configuration;
        private readonly IPurchaseCurrencyRepository _PurchaseCurrencyRepository;
        private readonly IHttpClient _httpClient;
        private CurrencyExhangeQuoteDTO _currencyExhangeQuoteDTO;
        public PurchaseCurrencyService(IConfiguration configuration, IPurchaseCurrencyRepository PurchaseCurrencyRepository,  IHttpClient httpClient)
        {
            _configuration = configuration;
            _PurchaseCurrencyRepository = PurchaseCurrencyRepository;
            _httpClient = httpClient;
        }

        public async Task<ResulService> ProcessBuyCurrencies(CurrencyRequestDTO currencyRequestDTO)
        {
          
         if(Execute( currencyRequestDTO.originCurrency, currencyRequestDTO.CurrencyChange))
         {
                if (_currencyExhangeQuoteDTO != null && _currencyExhangeQuoteDTO.pricePurchase!=0)
                {
                    currencyRequestDTO.priceDivisa = _currencyExhangeQuoteDTO.pricePurchase;
                    SaveCurrencyAmount(currencyRequestDTO);
                }

         }
            return  new ResulService { messaje = "process success", success = true, data = null, codError = "0" };
        }


        public bool Execute(string originCurrency, string CurrencyChange)
        {
            bool response = false;


            var circuitBreakerPolicy = Policy.Handle<Exception>().
                CircuitBreaker(1, TimeSpan.FromSeconds(15),
                onBreak: (ex, timespan, context) =>
                {
                    Console.WriteLine("El circuito entró en estado de falla");
                }, onReset: (context) =>
                {
                    Console.WriteLine("Circuito dejó estado de falla");
                });

            var retry = Policy.Handle<Exception>()
                           .WaitAndRetryForever(attemp => TimeSpan.FromMilliseconds(300))
                           .Wrap(circuitBreakerPolicy);

            retry.Execute(() =>
            {
                if (circuitBreakerPolicy.CircuitState == CircuitState.Closed)
                {
                    circuitBreakerPolicy.Execute(() =>
                    {
                      
                        response = GetExchangeRate(originCurrency, CurrencyChange).Result;

                        Console.WriteLine("Solicitud realizada con éxito");

                    });
                }

                if (circuitBreakerPolicy.CircuitState != CircuitState.Closed)
                {
                    Console.WriteLine("Solicitud realizada sin exito");
                    response = false;
                }
            });

            return response;

        }

        public async Task<bool> GetExchangeRate(string originCurrency ,string CurrencyChange)
        {
            CurrencyExhangeQuoteDTO currencyExchangeDTO = new();
            string uri = _configuration["proxy:urlCurrencyExchange"];
            var response = await _httpClient.GetStringAsync(uri + "/" + originCurrency + "/"+ CurrencyChange);
            ResulService vResultado = new ResulService();
            vResultado = JsonConvert.DeserializeObject<ResulService>(response);
            if (vResultado.success == true)
            {
                if (vResultado.codError == "0")
                {
                    var json = JsonConvert.SerializeObject(vResultado.data);
                    CurrencyExhangeQuoteDTO test = JsonConvert.DeserializeObject<CurrencyExhangeQuoteDTO>(json);

                    currencyExchangeDTO.pricePurchase = test.pricePurchase;
                    currencyExchangeDTO.priceSale = test.priceSale;
                    currencyExchangeDTO.quote = test.quote;
                    _currencyExhangeQuoteDTO = currencyExchangeDTO;
                }
                else
                {
                    _currencyExhangeQuoteDTO = currencyExchangeDTO;
                }
            }

            return true;
        }

        public async void SaveCurrencyAmount(CurrencyRequestDTO currencyRequestDTO)
        {
            CurrencyAmount currencyAmount = new();
            currencyAmount.Amount = currencyRequestDTO.Amount;
            currencyAmount.priceDivisa = currencyRequestDTO.priceDivisa;
            currencyAmount.AmountExhange = (currencyRequestDTO.Amount / _currencyExhangeQuoteDTO.quote);
            currencyAmount.originCurrency = currencyRequestDTO.originCurrency;
            currencyAmount.CurrencyChange = currencyRequestDTO.CurrencyChange;
            currencyAmount.codUserBuyer = currencyRequestDTO.codUserBuyer;
            currencyAmount.description = "Compra de divisas";
            currencyAmount.created_at = DateTime.Now.Date;
            currencyAmount.transactionType = "C";

       var result=   await  _PurchaseCurrencyRepository.RegisterCurrencyAmount(currencyAmount);
        }

    }
}

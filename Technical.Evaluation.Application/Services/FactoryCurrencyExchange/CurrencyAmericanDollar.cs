using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Technical.Evaluation.Application.DTO;
using Technical.Evaluation.infrastructure.Service;

namespace Technical.Evaluation.Application.Services.FactoryCurrencyExchange
{
    internal class CurrencyAmericanDollar : IFactoryCurrency
    {
        public async Task<CurrencyExchangeDTO> GetExchange()
        {
            string UrlComplementary = "Principal/Dolar";
            HttpResponseMessage response = await StrategyConecctionHTTP.ConnectionJson(StrategyConecctionHTTP.ListServices.SERVICE_CURRENCY_EXCHANGE).httpClientGet(UrlComplementary);
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                if(result != null || result.Length>0)
                {
                    var vResultado = JsonConvert.DeserializeObject<List<dynamic>>(result);
                    return ClassifyCurrencyExhange(vResultado);
                }
            }

            return null;
        }

        private CurrencyExchangeDTO ClassifyCurrencyExhange(List<dynamic> dataServiceCurrency)
        {

            string MontPurchage, MontSale = "";
            var currencyPuchage = dataServiceCurrency[0].Split('.');
            var currencyVeryNotOne = double.Parse(currencyPuchage[1]);
            var currencySale = dataServiceCurrency[1].Split('.');
            var currencySaleVeryNotOne = double.Parse(currencySale[1]);
            if (currencyVeryNotOne > 0) { MontPurchage = currencyPuchage[0] + "," + currencyPuchage[1]; } else { MontPurchage = currencyPuchage[0]; }
            if (currencySaleVeryNotOne > 0) { MontSale = currencySale[0] + "," + currencySale[1]; } else { MontSale = currencySale[0]; }

            CurrencyExchangeDTO objCE = new()
            {
                pricePurchase =decimal.Parse(MontPurchage),
                priceSale = decimal.Parse(MontSale),
            };
               
            return objCE;

        }

    }
}

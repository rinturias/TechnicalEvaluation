using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technical.Evaluation.Application.DTO;
using Technical.Evaluation.Application.Interfaces;
using Technical.Evaluation.Application.Services.FactoryCurrencyExchange;
using Technical.Evaluation.Domain.Entities.Curriency;
using Technical.Evaluation.Domain.Interfaces;
using Technical.Evaluation.Domain.ValueObjects.Curriency;

namespace Technical.Evaluation.Application.Services
{
    public class CurrencyExchange : ICurrencyExchange
    {
        private readonly ICurrencyRepository _currencyRepository;
        public CurrencyExchange(ICurrencyRepository currencyRepository)
        {
            _currencyRepository = currencyRepository;
        }

 

        public async Task<ResulService> GetExchangeRate(string pCurrency)
        {


             IFactoryCurrency objFactory= FactoryCurrency.GetExchange(pCurrency.ToUpper());
            if (objFactory == null) return new ResulService { messaje = "Estimado usuario actualmente no contamos con el servicio para la moneda ingresada", success = true, codError = "204" };
            var result= await  objFactory.GetExchange();
             return new ResulService { messaje = "process success", success = true, data = result, codError = "0" };

        }
      
        public async Task<ResulService> GetCurrencyExchangeRateSale(string originCurrency, string CurrencyChange)
        {
            IFactoryCurrency objFactory = FactoryCurrency.GetExchange(CurrencyChange.ToUpper());
            if (objFactory == null) return new ResulService { messaje = "Estimado usuario actualmente no contamos con el servicio para la moneda ingresada", success = true, codError = "204" };
           
            
            var result = await objFactory.GetExchange();
            CurrencyVO ResulQuote = await _currencyRepository.GetQuoteAmount(CurrencyChange.ToUpper());
            if (ResulQuote == null) return new ResulService { messaje = "Estimado usuario actualmente no contamos con el servicio, estamos trabajando para ampliar nuestra red de monedas.", success = true, codError = "204" };



            CurrencyExhangeQuoteDTO currencyExhangeQuoteDTO = new();
            currencyExhangeQuoteDTO.pricePurchase = result.pricePurchase;
            currencyExhangeQuoteDTO.priceSale = result.priceSale;
            currencyExhangeQuoteDTO.Quote = ResulQuote.quote;

            return new ResulService { messaje = "process success", success = true, data = currencyExhangeQuoteDTO, codError = "0" };
        }

    }
}

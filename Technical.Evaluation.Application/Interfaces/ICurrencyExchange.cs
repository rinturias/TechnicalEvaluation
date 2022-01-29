using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technical.Evaluation.Application.DTO;

namespace Technical.Evaluation.Application.Interfaces
{
  public  interface ICurrencyExchange
    {
        Task<ResulService> GetExchangeRate(string pCurrency);
        Task<ResulService> GetCurrencyExchangeRateSale(string originCurrency, string CurrencyChange);
    }
}

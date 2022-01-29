using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technical.Evaluation.Application.DTO;

namespace Technical.Evaluation.Application.Services.FactoryCurrencyExchange
{
    public interface IFactoryCurrency
    {
        Task<CurrencyExchangeDTO> GetExchange();
    }
}

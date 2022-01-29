using Puchage.Technical.Evaluation.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puchage.Technical.Evaluation.Application.Interfaces
{
    public interface IPurchaseCurrencyService
    {
        Task<ResulService> ProcessBuyCurrencies(CurrencyRequestDTO currencyRequestDTO);
    }
}

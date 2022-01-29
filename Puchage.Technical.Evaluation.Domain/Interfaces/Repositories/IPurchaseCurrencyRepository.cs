using Puchage.Technical.Evaluation.Domain.Entitites.CurrencyAmount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puchage.Technical.Evaluation.Domain.Interfaces.Repositories
{
    public interface IPurchaseCurrencyRepository
    {

        Task<bool> RegisterCurrencyAmount(CurrencyAmount currencyAmount);
    }
}

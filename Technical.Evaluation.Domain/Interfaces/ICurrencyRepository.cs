using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technical.Evaluation.Domain.ValueObjects.Curriency;

namespace Technical.Evaluation.Domain.Interfaces
{
    public interface ICurrencyRepository
    {
        Task<CurrencyVO> GetQuoteAmount(String currency);

    }
}

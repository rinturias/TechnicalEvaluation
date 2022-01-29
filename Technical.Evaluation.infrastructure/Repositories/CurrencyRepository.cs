

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technical.Evaluation.Domain.Interfaces;
using Technical.Evaluation.Domain.ValueObjects.Curriency;
using Technical.Evaluation.infrastructure.Context;

namespace Puchage.Technical.Evaluation.infrastructure.Repositories
{
    public class CurrencyRepository: ICurrencyRepository
    {
        private readonly IContextDatabase _context;
        public CurrencyRepository(IContextDatabase contextDatabase)
        {
            this._context = contextDatabase;
        }

        public async Task<CurrencyVO> GetQuoteAmount(string currency)
        {
            try
            {
              var RESUL=  _context._Currency.FirstOrDefault(c => c.IsoCurrency.Equals(currency));
                if (RESUL == null) return null;
                CurrencyVO CurrencyVO = new();
                CurrencyVO.quote = RESUL.quote;
                return CurrencyVO;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

   
    }
}

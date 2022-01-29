using Puchage.Technical.Evaluation.Domain.Entitites.CurrencyAmount;
using Puchage.Technical.Evaluation.Domain.Interfaces.Repositories;
using Puchage.Technical.Evaluation.infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puchage.Technical.Evaluation.infrastructure.Repositories
{
    public class PurchaseCurrencyRepository: IPurchaseCurrencyRepository
    {
        private readonly IContextDatabase _context;
        public PurchaseCurrencyRepository(IContextDatabase contextDatabase)
        {
            this._context = contextDatabase;
        }
        public async Task<bool> RegisterCurrencyAmount(CurrencyAmount currencyAmount)
        {
            try
            {

                //  _logger.LogWarning("R-registrarTarjeta_Cas_Kiosco_Sesion: codPKnextSession: " + codPKnextSession.ToString());
  
              _context._CurrencyAmount.Add(currencyAmount);
               _context.SaveChanges();
        
            }
            catch (Exception ex)
            {

            }
            return true;
        }
    }
}

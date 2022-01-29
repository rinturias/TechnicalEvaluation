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
  
              _context._CurrencyAmount.Add(currencyAmount);
               _context.SaveChanges();
        
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        //public async Task<bool> ValidateLimitByUser(CurrencyAmount currencyAmount)
        //{
        //    try
        //    {
        //        //Por cuestiones de tiempo se puso los limites hard code: recomendable poner en BD para ser parametrizado
        //        decimal LimitMaxUSDMonth = 200;
        //        decimal LimitMaxBRLMonth = 300;

        //        var comprasDelMes = _context._CurrencyAmount.Where(
        //        c => c.codUserBuyer== currencyAmount.codUserBuyer 
        //        && c.created_at.Month== DateTime.Now.Month 
        //        && c.created_at.Year== DateTime.Now.Year && c.CurrencyChange== currencyAmount.CurrencyChange).ToList();


              
           
        //        _context.SaveChanges();

        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //    return true;
        //}

    }
}

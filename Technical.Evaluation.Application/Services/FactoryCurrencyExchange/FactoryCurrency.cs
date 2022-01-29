using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Technical.Evaluation.Application.Services.FactoryCurrencyExchange
{
    public class FactoryCurrency
    {
        public static class TypeCurrency
        {
            public const string
             AmericanDollar = "USD",
             BrazilianReal = "BRL";
        }


        public static IFactoryCurrency GetExchange(string typeCurrency)
        {


            switch (typeCurrency)
            {
                case TypeCurrency.AmericanDollar: return new CurrencyAmericanDollar();
               

                case TypeCurrency.BrazilianReal: return new CurrencyBrazilianReal();

                default:  return null;

            }
           

        }

    }
}

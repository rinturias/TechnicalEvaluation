using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puchage.Technical.Evaluation.Application.DTO
{
    public class CurrencyRequestDTO
    {
        public decimal Amount { get; set; }
        //public decimal priceDivisa { get; set; }
        public string originCurrency { get; set; }
        public string CurrencyChange { get; set; }
        public int codUserBuyer { get; set; }
        //public string transactionType { get; set; }
    }
}

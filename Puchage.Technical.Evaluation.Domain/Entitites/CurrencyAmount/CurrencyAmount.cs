using Puchage.Technical.Evaluation.Domain.ClassUtils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puchage.Technical.Evaluation.Domain.Entitites.CurrencyAmount
{
    [Table("CurrencyAmount")]
    public class CurrencyAmount: ManageGeneralstates
    {
        [Key]
        public int CodCurrencyAmount { get; set; }
        public decimal Amount { get; set; }
        public decimal priceDivisa { get; set; }
        public decimal AmountExhange { get; set; }
        public string originCurrency { get; set; }
        public string CurrencyChange { get; set; }
        public int codUserBuyer { get; set; }
        public string description { get; set; }
        public string transactionType { get; set; }
    }
}

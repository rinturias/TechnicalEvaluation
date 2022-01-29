using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Technical.Evaluation.Domain.ValueObjects.Curriency
{

    public class CurrencyVO
    {



        public int CodCurrency { get; set; }
        public string Description { get; set; }
        public string IsoCurrency { get; set; }
        public decimal quote { get; set; }
     

    }
    }


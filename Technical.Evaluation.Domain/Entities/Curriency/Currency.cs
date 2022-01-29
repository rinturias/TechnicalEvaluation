using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Technical.Evaluation.Domain.Entities.Curriency
{
    [Table("Currency")]
    public class Currency
    {

    
            [Key]
            public int CodCurrency { get; set; }
            public string Description { get; set; }
            public string IsoCurrency { get; set; }
            public decimal quote { get; set; }
            public int Active { get; set; }

        }
    }


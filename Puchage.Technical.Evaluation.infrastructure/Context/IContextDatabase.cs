using Microsoft.EntityFrameworkCore;
using Puchage.Technical.Evaluation.Domain.Entitites.CurrencyAmount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puchage.Technical.Evaluation.infrastructure.Context
{
    public interface IContextDatabase
    {
        public DbSet<CurrencyAmount> _CurrencyAmount { get; set; }
        int SaveChanges();
    }
}

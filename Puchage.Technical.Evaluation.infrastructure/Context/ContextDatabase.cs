using Microsoft.EntityFrameworkCore;
using Puchage.Technical.Evaluation.Domain.Entitites.CurrencyAmount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puchage.Technical.Evaluation.infrastructure.Context
{
    public class ContextDatabase : DbContext, IContextDatabase
    {
        public ContextDatabase(DbContextOptions<ContextDatabase> options) : base(options)
        {

        }
        public DbSet<CurrencyAmount> _CurrencyAmount { get; set; }
        public DbContext Instance => this;

    }
}

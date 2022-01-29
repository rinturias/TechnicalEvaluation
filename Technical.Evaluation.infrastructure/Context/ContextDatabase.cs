using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technical.Evaluation.Domain.Entities.Curriency;

namespace Technical.Evaluation.infrastructure.Context
{
    public class ContextDatabase : DbContext, IContextDatabase
    {
        public ContextDatabase(DbContextOptions<ContextDatabase> options) : base(options)
        {

        }
        public DbSet<Currency> _Currency { get; set; }
        public DbContext Instance => this;

    }
}

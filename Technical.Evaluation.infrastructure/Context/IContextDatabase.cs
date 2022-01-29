using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technical.Evaluation.Domain.Entities.Curriency;

namespace Technical.Evaluation.infrastructure.Context
{
    public interface IContextDatabase
    {
        public DbSet<Currency> _Currency { get; set; }
        int SaveChanges();
    }
}

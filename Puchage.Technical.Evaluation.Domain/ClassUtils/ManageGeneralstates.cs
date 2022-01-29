using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puchage.Technical.Evaluation.Domain.ClassUtils
{
    public class ManageGeneralstates
    {
        public DateTime created_at { get; set; }
        public DateTime update_at { get; set; }
        public int active { get; set; } = 0;
    }
}

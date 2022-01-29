using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Technical.Evaluation.Application.DTO
{
   public class ResulService
    {
        public bool success { get; set; }
        public dynamic data { get; set; }
        public string messaje { get; set; }
        public string error { get; set; } = "";
        public string codError { get; set; }
    }
}

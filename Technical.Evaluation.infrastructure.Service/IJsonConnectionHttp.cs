using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Technical.Evaluation.infrastructure.Service
{
    public interface IJsonConnectionHttp { 
        Task<HttpResponseMessage> httpClientPost(string urlComplementario, object input = null);
        Task<HttpResponseMessage> httpClientGet(string urlComplementario);
    }
}

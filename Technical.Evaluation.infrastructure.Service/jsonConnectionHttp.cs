using System;
using System.Threading.Tasks;
using System.Text;
using Newtonsoft.Json;
using Nancy.Json;
using System.Net.Http;

namespace Technical.Evaluation.infrastructure.Service
{
    public class jsonConnectionHttp : IJsonConnectionHttp
    {
        private readonly string _urlBase = "";
        public jsonConnectionHttp(string urlBase)
        {
            this._urlBase = urlBase;
        }


        public async Task<HttpResponseMessage> httpClientGet(string urlComplementario)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(_urlBase + "/" + urlComplementario);
            return response;
        }

        public async Task<HttpResponseMessage> httpClientPost(string urlComplementario, object input = null)
        {
            string inputJson = (new JavaScriptSerializer()).Serialize(input);
            HttpClient client = new HttpClient();
            HttpContent inputContent = new StringContent(inputJson, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(_urlBase + "/" + urlComplementario, inputContent);
            return response;
        }
    }
}

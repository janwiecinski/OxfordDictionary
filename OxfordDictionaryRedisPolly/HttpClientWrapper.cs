using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OxfordDictionaryRedisPolly
{
    public class HttpClientWrapper
    {
        private readonly HttpClient _httpClient;
        public HttpClientWrapper()
        {
            _httpClient = new HttpClient();
        }

        public  HttpResponseMessage GetAsync (string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url)
            {
                Headers =
                {
                }
            };

            var result =  _httpClient.SendAsync(request).Result;
            var e = result.Content.ReadAsStringAsync().Result;

            var deser = JsonConvert.DeserializeObject<OxfordDictionaryResultJSON>(e);
            var rrrr = deser.Results[0].LexicalEntries[0].Entries[0].Senses[0].Definitions[0];
            return result;
        }

    }
}

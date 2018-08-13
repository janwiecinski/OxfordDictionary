using System.Collections.Generic;
using System.Net.Http;
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

        public  Task<List<string>> GetAsync (string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url)
            {
                Headers =
                {
                }
            };
            Task<string> response;
            var result = _httpClient.SendAsync(request).ContinueWith<List<string>>
                (
                 responseTask => {
                     response = responseTask.Result.Content.ReadAsStringAsync();
                     return DeserializeProvider.GetStringsFromJson(response.Result);
                 }
                );
            return result;
            
        }

    }
}

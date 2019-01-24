using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreWebAPIs.Core
{
    public class APICaller
    {
        public async Task<T> PostAsync<T>(string apiUrl, object messageValue, string token = "")
        {
            using (var client = new HttpClient())
            {
                if (!string.IsNullOrWhiteSpace(token))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }
                var messageJSON = JsonConvert.SerializeObject(messageValue);
                var content = new StringContent(messageJSON, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(apiUrl, content);
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(json);
            }
        }

        public async Task<T> GetAsync<T>(string apiUrl, string token = "")
        {
            using (var client = new HttpClient())
            {
                if (!string.IsNullOrWhiteSpace(token))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }
                client.DefaultRequestHeaders.Add("Get", "application/json");
                var json = await client.GetStringAsync(apiUrl);
                return JsonConvert.DeserializeObject<T>(json);
            }
        }
    }
}

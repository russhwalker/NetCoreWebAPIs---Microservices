using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreWebAPIs.Core
{
    public class APICaller
    {
        public async Task<T> PostAsync<T>(string apiUrl, object messageValue)
        {
            using (var client = new HttpClient())
            {
                var messageJSON = JsonConvert.SerializeObject(messageValue);
                var content = new StringContent(messageJSON, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(apiUrl, content);
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(json);
            }
        }

        public T Post<T>(string apiUrl, object messageValue)
        {
            using (var client = new HttpClient())
            {
                var messageJSON = JsonConvert.SerializeObject(messageValue);
                var content = new StringContent(messageJSON, Encoding.UTF8, "application/json");
                var response = client.PostAsync(apiUrl, content).Result.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<T>(response);
            }
        }
    }
}

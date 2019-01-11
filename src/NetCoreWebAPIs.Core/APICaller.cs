using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreWebAPIs.Core
{
    public class APICaller
    {
        public APICaller()
        {
            //this.baseHostUrl = baseHostUrl;
            //this.credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(
            //    string.Format("{0}:{1}", userName, password)));

            //System.Net.ServicePointManager.ServerCertificateValidationCallback =
            //    ((sender, certificate, chain, sslPolicyErrors) => true);
        }

        public async Task<T> PostAsync<T>(string apiUrl, object messageValue)
        {
            using (var client = new HttpClient())
            {
                var messageJSON = JsonConvert.SerializeObject(messageValue);
                var content = new StringContent(messageJSON, Encoding.UTF8, "application/json");
                //client.BaseAddress = baseUri;
                //client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", this.credentials);
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
                //client.BaseAddress = baseUri;
                //client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", this.credentials);
                var response = client.PostAsync(apiUrl, content).Result.Content.ReadAsStringAsync().Result;                
                return JsonConvert.DeserializeObject<T>(response);
            }
        }
    }
}

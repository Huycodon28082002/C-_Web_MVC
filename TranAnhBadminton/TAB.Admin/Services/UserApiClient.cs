using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Serialization;
using TAB.ViewModels.System.Users;

namespace TAB.Admin.Services
{
    public class UserApiClient : InterfaceUserApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public UserApiClient(IHttpClientFactory httpClientFactory) 
        {
            _httpClientFactory= httpClientFactory;
        }
        public async Task<string> Authenticate(LoginRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:7777");
            var respone = await client.PostAsync("/api/users/authenticate", httpContent);
            var token = await respone.Content.ReadAsStringAsync();
            return token;
        }
    }
}

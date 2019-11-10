using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;

namespace Heimdall.IdentityServer.Clients
{
    public class MimirClient : IMimirClient
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _configuration;

        public MimirClient(IHttpClientFactory clientFactory, IConfiguration configuration)
        {
            _clientFactory = clientFactory;
            _configuration = configuration;
        }

        public async Task<bool> CreateUserAsync(string authId, string name)
        {
            using (var client = _clientFactory.CreateClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Put, $"{_configuration["Security:ApiUrl"]}/api/user/create");
                request.Content = new StringContent(
                    JObject.FromObject(new { authId, name }).ToString(),
                    Encoding.UTF8,
                    "application/json");
                var response = await client.SendAsync(request);

                return response.IsSuccessStatusCode;
            }
        }
    }
}

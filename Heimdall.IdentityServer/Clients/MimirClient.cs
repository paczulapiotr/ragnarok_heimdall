using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Linq;

namespace Heimdall.IdentityServer.Clients
{
    public class MimirClient : IMimirClient
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;

        public MimirClient(IHttpClientFactory clientFactory, IConfiguration configuration, IWebHostEnvironment environment)
        {
            _clientFactory = clientFactory;
            _configuration = configuration;
            _environment = environment;
        }

        public async Task<bool> CreateUserAsync(string authId, string name)
        {
            using (var client = _clientFactory.CreateClient())
            {
                var urlRoot = _environment.IsDevelopment()
                    ? _configuration["Security:Local:ApiUrl"]
                    : _configuration["Security:Azure:ApiUrl"];
                var request = new HttpRequestMessage(HttpMethod.Put, $"{urlRoot}/api/user/create");
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

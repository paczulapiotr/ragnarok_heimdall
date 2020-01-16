using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heimdall.IdentityServer
{
    public static class Settings
    {
        public static Security Security { get; private set; }
        public static void Setup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Security = new Security(configuration, environment);
        }
    }

    public struct Security
    {
        private readonly IWebHostEnvironment _environment;

        public Security(IConfiguration configuration, IWebHostEnvironment environment)
        {
            ApiUrl = configuration[$"{nameof(Security)}:{nameof(ApiUrl)}"];
            ClientUrl = configuration[$"{nameof(Security)}:{nameof(ClientUrl)}"];
            _environment = environment;
        }
        public string ClientUrl { get; private set; }
        public string ApiUrl { get; private set; }
    }
}

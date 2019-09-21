using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heimdall.IdentityServer
{
    public static class Settings
    {
        public static Security Security { get; private set; }
        public static void Setup(IConfiguration configuration)
        {
            Security = new Security(configuration);
        }
    }

    public struct Security
    {
        public Security(IConfiguration configuration)
        {
            ApiUrl = configuration[$"{nameof(Security)}:{nameof(ApiUrl)}"];
            ClientUrl = configuration[$"{nameof(Security)}:{nameof(ClientUrl)}"];
        }
        public string ClientUrl { get; private set; }
        public string ApiUrl { get; private set; }
    }
}

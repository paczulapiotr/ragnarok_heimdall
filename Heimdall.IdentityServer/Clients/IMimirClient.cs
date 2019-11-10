using System.Threading.Tasks;

namespace Heimdall.IdentityServer.Clients
{
    public interface IMimirClient
    {
        Task<bool> CreateUserAsync(string authId, string name);
    }
}

using Pro.Entities.identity;
using System.Threading.Tasks;

namespace Pro.Services.Api.Contract
{
    public interface IjwtService
    {
        Task<string> GenerateTokenAsync(User User);
    }
}

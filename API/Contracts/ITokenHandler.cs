using System.Security.Claims;

namespace API.Contracts
{
    public interface ITokenHandler
    {
        string Generate(IEnumerable<Claim> claims);
    }
}

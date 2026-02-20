using System.Security.Claims;

namespace template_clean_arq_api.Application.Abstraction
{
    public interface IJwtService
    {
        string Generate(IReadOnlyList<Claim> claims);
    }
}

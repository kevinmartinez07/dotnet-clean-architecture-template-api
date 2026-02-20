using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using template_clean_arq_api.Application.Abstraction;
using template_clean_arq_api.Infrastructure.Commons;

namespace template_clean_arq_api.Infrastructure.Services.Security
{
    public sealed class JwtService(IOptions<JwtSettings> jwtSettings) : IJwtService
    {
        private readonly JwtSettings _JwtSettings = jwtSettings.Value ?? throw new ArgumentNullException(nameof(jwtSettings));

        public string Generate(IReadOnlyList<Claim> claims)
        {
            SymmetricSecurityKey symmetricKey = new(Encoding.UTF8.GetBytes(_JwtSettings.SecretKey));
            SigningCredentials signingCredentials = new(symmetricKey, SecurityAlgorithms.HmacSha256);

            JwtHeader header = new(signingCredentials)
            {
                ["kid"] = GenerateKeyId(_JwtSettings.SecretKey)
            };

            var payload = new JwtPayload(issuer: _JwtSettings.Issuer, audience: _JwtSettings.Audience, claims: claims, notBefore: DateTime.UtcNow, expires: DateTime.UtcNow.AddMonths(1));

            JwtSecurityToken jwtToken = new(header, payload);
            JwtSecurityTokenHandler tokenHandler = new();

            return tokenHandler.WriteToken(jwtToken);
        }

        private static string GenerateKeyId(string secretKey)
        {
            var hash = SHA256.HashData(Encoding.UTF8.GetBytes(secretKey));
            return Base64UrlEncoder.Encode(hash)[..8];
        }
    }
}

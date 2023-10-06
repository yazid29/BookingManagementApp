using API.Contracts;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Utilities.Handler
{
    public class TokenHandlers : ITokenHandler
    {
        private readonly IConfiguration _configuration;

        public TokenHandlers(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Generate(IEnumerable<Claim> claim)
        {
            // 
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWTService:SecretKey"]));
            var signingCredential = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokenOptions = new JwtSecurityToken(
                issuer: _configuration["JWTService:Issuer"],
                audience: _configuration["JWTService:Audience"],
                claims: claim,
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: signingCredential);

            var encodedToken = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return encodedToken;
        }
    }
}

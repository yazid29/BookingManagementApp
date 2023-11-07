using API.Contracts;
using API.DTO.Accounts;
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

        public string GetEmailfromToken(string authorizationHeader)
        {
            string emailClaim = "";
            if (!string.IsNullOrEmpty(authorizationHeader) && authorizationHeader.StartsWith("Bearer "))
            {
                // Token ada dalam format "Bearer {token}"
                string token = authorizationHeader.Substring("Bearer ".Length);
                var tokenHandler = new JwtSecurityTokenHandler();
                var data = (JwtSecurityToken)tokenHandler.ReadToken(token);
                var claims = data.Claims;

                // Mencari klaim dengan tipe Email seperti ketika create token
                emailClaim = claims.FirstOrDefault(c => c.Type == "Email").Value;
            }
            return emailClaim;
        }
        public ClaimsDTO ExtractClaimsFromJwt(string token)
        {
            if (token.IsNullOrEmpty()) return new ClaimsDTO(); // If the JWT token is empty, return an empty dictionary

            try
            {
                // Configure the token validation parameters
                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = true,
                    ValidAudience = _configuration["JWTService:Audience"],
                    ValidateIssuer = true,
                    ValidIssuer = _configuration["JWTService:Issuer"],
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWTService:SecretKey"]))
                };

                // Parse and validate the JWT token
                var tokenHandler = new JwtSecurityTokenHandler();
                var claimsPrincipal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var securityToken);

                // Extract the claims from the JWT token
                if (securityToken != null && claimsPrincipal.Identity is ClaimsIdentity identity)
                {
                    var claims = new ClaimsDTO
                    {
                        //NameIdentifier = identity.FindFirst(ClaimTypes.NameIdentifier)!.Value,
                        Name = identity.FindFirst(ClaimTypes.Name)!.Value,
                        Email = identity.FindFirst(ClaimTypes.Email)!.Value
                    };

                    var roles = identity.Claims.Where(c => c.Type == ClaimTypes.Role).Select(claim => claim.Value).ToList();
                    claims.Role = roles;

                    return claims;
                }
            }
            catch
            {
                // If an error occurs while parsing the JWT token, return an empty dictionary
                return new ClaimsDTO();
            }

            return new ClaimsDTO();
        }
    }
}

using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RnD.API.Infrastructures.Auth
{
    public class JwtProvider : IJwtProvider
    {
        public string GenerateToken(string Email)
        {
            var claims = new Claim[] 
            {
                new Claim(JwtRegisteredClaimNames.Email, Email),
            };

            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(
                    //Convert.FromBase64String("my_secret_key_1234567890")),
                    Encoding.UTF8.GetBytes("myBdsecret.Key$%#)@*%)@#*%I)@#I%)*#)")),
                SecurityAlgorithms.HmacSha256
                );
            var token = new JwtSecurityToken(
                "issuer",
                "audience",
                claims,
                null,
                DateTime.UtcNow.AddMinutes(10),
                signingCredentials);

            string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenValue;
        }
    }
}

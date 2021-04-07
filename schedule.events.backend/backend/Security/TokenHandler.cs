using backend.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace backend.Security
{
    public class TokenHandler : ITokenHandler
	{
		private IConfiguration _configuration { get; }
		public TokenHandler(IConfiguration configuration)
		{
			_configuration = configuration;
		}
		public async Task<string> GenerateToken(string role, string email, string userid)
		{
			var mySecret = _configuration["Tokens:TokenPrivateKey"];
			var myIssuer = _configuration["Tokens:TokenIssuer"];
			var myAudience = _configuration["Tokens:TokenAudience"];
			var mySecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(mySecret));

			var tokenHandler = new JwtSecurityTokenHandler();

			var claims = new Dictionary<string, object>
			{
				{ ClaimTypes.Role, role },
				{ ClaimTypes.Name, email },
				{ ClaimTypes.Actor, userid }
			};

			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Expires = DateTime.UtcNow.AddDays(30), //30 Days Expiration time
				Issuer = myIssuer,
				Audience = myAudience,
				Claims = claims,
				SigningCredentials = new SigningCredentials(mySecurityKey, SecurityAlgorithms.HmacSha256Signature)
			};

			var token = await Task.FromResult(tokenHandler.CreateToken(tokenDescriptor));
			return tokenHandler.WriteToken(token);
		}
	}
}

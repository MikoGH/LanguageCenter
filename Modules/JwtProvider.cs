using LanguageCenter.Models.Entity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LanguageCenter.Modules
{
	public class JwtProvider : IJwtProvider
	{
		private readonly JwtOptions options;
        public JwtProvider(IOptions<JwtOptions> options)
        {
			this.options = options.Value;
        }
        public string GenerateToken(PersonEntity person)
		{
			List<Claim> claims = new List<Claim>
			{
				new Claim(ClaimTypes.NameIdentifier, person.Id.ToString()),
				new Claim(ClaimTypes.Role, person.Role.ToString())
			};  

			var signingCredentials = new SigningCredentials(
				new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.SecretKey)),
				SecurityAlgorithms.HmacSha256);

			var token = new JwtSecurityToken(
				claims: claims,
				signingCredentials: signingCredentials,
				expires: DateTime.UtcNow.AddDays(options.ExpiresDays));

			var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

			return tokenValue;
		}
	}
}

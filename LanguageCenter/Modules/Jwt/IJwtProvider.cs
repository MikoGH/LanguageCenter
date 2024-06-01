using LanguageCenter.Models;

namespace LanguageCenter.Modules.Jwt
{
	public interface IJwtProvider
	{
		public string GenerateToken(PersonEntity person);
	}
}

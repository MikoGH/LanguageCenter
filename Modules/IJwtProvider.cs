using LanguageCenter.Models.Entity;

namespace LanguageCenter.Modules
{
	public interface IJwtProvider
	{
		public string GenerateToken(PersonEntity person);
	}
}

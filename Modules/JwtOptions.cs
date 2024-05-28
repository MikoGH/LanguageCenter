namespace LanguageCenter.Modules
{
	public class JwtOptions
	{
		public string SecretKey { get; set; } = String.Empty;
		public int ExpiresDays { get; set; }
	}
}

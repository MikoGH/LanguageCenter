namespace LanguageCenter.Models.Dto
{
	public class InsertPersonDto
	{
		public int Role { get; set; }
		public string Login { get; set; }
		public string Password { get; set; }
		public string FirstName { get; set; }
		public string SecondName { get; set; }
		public string LastName { get; set; }
	}
}

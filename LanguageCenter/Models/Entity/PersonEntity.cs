using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanguageCenter.Models.Entity
{
	public class PersonEntity
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		[Required]
		public int Role {  get; set; }
		[Required]
		public string Login { get; set; }
		[Required]
		public string Password { get; set; }
		[Required]
		[Column("First_name")]
		public string FirstName { get; set; }
		[Required]
		[Column("Second_name")]
		public string SecondName { get; set; }
		[Required]
		[Column("Last_name")]
		public string LastName { get; set; }

		public static class Roles
		{
			public const string Admin = "0";
			public const string Tutor = "1";
			public const string Client = "2";
		}
	}
}

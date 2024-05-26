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
		public string First_name { get; set; }
		[Required]
		public string Second_name { get; set; }
		[Required]
		public string Last_name { get; set; }


		public static int ROLE_ADMIN = 0;
		public static int ROLE_TUTOR = 1;
		public static int ROLE_CLIENT = 2;
	}
}

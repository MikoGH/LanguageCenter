using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanguageCenter.Models
{
	/// <summary>
	/// Модель, представляющая человека
	/// </summary>
	public class PersonEntity
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		/// <summary>
		/// Роль в системе
		/// </summary>
		[Required]
		public int Role { get; set; }
		/// <summary>
		/// Логин
		/// </summary>
		[Required]
		public string Login { get; set; }
		/// <summary>
		/// Пароль
		/// </summary>
		[Required]
		public string Password { get; set; }
		/// <summary>
		/// Имя
		/// </summary>
		[Required]
		[Column("First_name")]
		public string FirstName { get; set; }
		/// <summary>
		/// Отчество
		/// </summary>
		[Required]
		[Column("Second_name")]
		public string SecondName { get; set; }
		/// <summary>
		/// Фамилия
		/// </summary>
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

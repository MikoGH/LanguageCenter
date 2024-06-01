using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanguageCenter.Models
{
	/// <summary>
	/// Модель, представляющая уровень владения языком
	/// </summary>
	public class LevelEntity
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		/// <summary>
		/// Название уровня владения языком
		/// </summary>
		[Required]
		public string Name { get; set; }
	}
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanguageCenter.Models
{
	/// <summary>
	/// Модель, представляющая язык
	/// </summary>
	public class LanguageEntity
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		/// <summary>
		/// Название языка
		/// </summary>
		[Required]
		public string Name { get; set; }
	}
}

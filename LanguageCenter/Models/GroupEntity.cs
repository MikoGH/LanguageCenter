using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LanguageCenter.Models
{
	/// <summary>
	/// Модель, представляющая группу
	/// </summary>
	public class GroupEntity
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		[Required]
		[ForeignKey(nameof(CourseEntity))]
		public int CourseId { get; set; }
		/// <summary>
		/// Идентификатор преподавателя
		/// </summary>
		[Required]
		[ForeignKey(nameof(PersonEntity))]
		public int PersonId { get; set; }
	}
}

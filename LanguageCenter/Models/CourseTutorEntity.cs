using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LanguageCenter.Models
{
	/// <summary>
	/// Модель, представляющая связь курса и преподавателя
	/// </summary>
	public class CourseTutorEntity
	{
		[Required]
		[ForeignKey(nameof(CourseEntity))]
		public int CourseId { get; set; }
		[Required]
		[ForeignKey(nameof(PersonEntity))]
		public int PersonId { get; set; }
	}
}

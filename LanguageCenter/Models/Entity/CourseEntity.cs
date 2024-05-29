using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace LanguageCenter.Models.Entity
{
	public class CourseEntity
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		[Required]
		[ForeignKey(nameof(LanguageEntity))]
		public int LanguageId { get; set; }
		[Required]
		[ForeignKey(nameof(LevelEntity))]
		public int LevelId { get; set; }
		[Required]
		[Column("Count_lessons")]
		public int CountLessons { get; set; }
	}
}

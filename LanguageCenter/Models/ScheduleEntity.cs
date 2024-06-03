using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LanguageCenter.Models
{
	/// <summary>
	/// Модель, представляющая расписание занятия
	/// </summary>
	public class ScheduleEntity
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		[Required]
		[ForeignKey(nameof(GroupEntity))]
		public int GroupId { get; set; }
		[Required]
		[ForeignKey(nameof(ClassroomEntity))]
		public int ClassroomId { get; set; }
		/// <summary>
		/// Дата и время занятия
		/// </summary>
		[Required]
		public DateTime Date { get; set; }
	}
}

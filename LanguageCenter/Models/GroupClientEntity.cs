using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LanguageCenter.Models
{
	/// <summary>
	/// Модель, представляющая связь группы и клиента
	/// </summary>
	public class GroupClientEntity
	{
		[Key]
		[Required]
		[ForeignKey(nameof(GroupEntity))]
		public int GroupId { get; set; }
		[Key]
		[Required]
		[ForeignKey(nameof(PersonEntity))]
		public int PersonId { get; set; }
	}
}

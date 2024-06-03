using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LanguageCenter.Models
{
	/// <summary>
	/// Модель, представляющая связь группы и клиента
	/// </summary>
	public class GroupClientEntity
	{
		[Required]
		[ForeignKey(nameof(GroupEntity))]
		public int GroupId { get; set; }
		[Required]
		[ForeignKey(nameof(PersonEntity))]
		public int PersonId { get; set; }
	}
}

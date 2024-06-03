using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LanguageCenter.Models
{
	/// <summary>
	/// Модель, представляющая кабинет
	/// </summary>
	public class ClassroomEntity
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		[Required]
		[ForeignKey(nameof(AddressEntity))]
		public int AddressId { get; set; }
		/// <summary>
		/// Название кабинета
		/// </summary>
		[Required]
		public string Classroom {  get; set; }
	}
}

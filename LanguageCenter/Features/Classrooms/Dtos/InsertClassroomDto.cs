using System.ComponentModel.DataAnnotations;

namespace LanguageCenter.Features.Classrooms.Dtos
{
	public class InsertClassroomDto
	{
		public int AddressId { get; set; }
		public string Classroom { get; set; }
	}
}

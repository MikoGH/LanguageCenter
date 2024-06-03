using LanguageCenter.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LanguageCenter.Features.Groups.Dtos
{
	public class UpdateGroupDto
	{
		public int CourseId { get; set; }
		public int PersonId { get; set; }
	}
}

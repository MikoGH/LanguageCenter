using LanguageCenter.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LanguageCenter.Features.Schedules.Dtos
{
	public class InsertScheduleDto
	{
		public int GroupId { get; set; }
		public int ClassroomId { get; set; }
		public DateTime Date { get; set; }
	}
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanguageCenter.Models
{
    public class CourseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int LanguageId { get; set; } 
        [Required]
        public int LevelId { get; set; }
        [Required]
        public int Count_lessons { get; set; }


		//public Language Language { get; set; }
		//public Level Level { get; set; }
	}
}

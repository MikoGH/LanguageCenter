using LanguageCenter.Models.Dto;
using LanguageCenter.Models.Entity;
using LanguageCenter.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LanguageCenter.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class CoursesController : ControllerBase
	{
		private readonly ICourseRepository courseRepository;
		private readonly ILanguageRepository languageRepository;
		private readonly ILevelRepository levelRepository;
		public CoursesController(ICourseRepository courseRepository, ILanguageRepository languageRepository, ILevelRepository levelRepository)
		{
			this.courseRepository = courseRepository;
			this.languageRepository = languageRepository;
			this.levelRepository = levelRepository;
		}

		[HttpGet("")]
		public IActionResult Index()
		{
			IEnumerable<CourseEntity> courses = courseRepository.GetAll();
			if (courses == null)
				return NotFound();
			return Ok(courses);
		}

		[HttpGet("{id:int}")]
		public IActionResult Get([FromRoute] int id)
		{
			CourseEntity course = courseRepository.GetById(id);
			if (course == null)
				return NotFound();
			return Ok(course);
		}

		[HttpPost("")]
		public IActionResult Create([FromQuery] InsertCourseDto courseDto)
		{
			CourseEntity course = new CourseEntity
			{
				LanguageId = courseDto.LanguageId,
				LevelId = courseDto.LevelId,
				Count_lessons = courseDto.Count_lessons
			};
			courseRepository.Insert(course);
			return Ok();
		}

		[HttpPut("{id:int}")]
		public IActionResult Update([FromRoute] int id, [FromQuery] UpdateCourseDto courseDto)
		{
			CourseEntity course = courseRepository.GetById(id);
			if (course == null)	
				return NotFound();

			if (!languageRepository.ExistById(courseDto.LanguageId))
				return NotFound();
			if (!levelRepository.ExistById(courseDto.LevelId))
				return NotFound();

			course.LanguageId = courseDto.LanguageId;
			course.LevelId = courseDto.LevelId;
			course.Count_lessons = courseDto.Count_lessons;

			courseRepository.Update(course);
			return Ok();
		}

		[HttpDelete("{id:int}")]
		public IActionResult Delete([FromRoute] int id)
		{
			CourseEntity course = courseRepository.GetById(id);
			if (course == null) return NotFound();
			courseRepository.Delete(course);
			return Ok();
		}
	}
}

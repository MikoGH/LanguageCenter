using LanguageCenter.Models;
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
		public CoursesController(ICourseRepository _courseRepository)
		{
			courseRepository = _courseRepository;
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
		public IActionResult Create([FromBody] CourseEntity course)
		{
			courseRepository.Insert(course);
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

		//// POST: CoursesController/Create
		//[HttpPost]
		//[ValidateAntiForgeryToken]
		//public ActionResult Create(IFormCollection collection)
		//{
		//	try
		//	{
		//		return RedirectToAction(nameof(Index));
		//	}
		//	catch
		//	{
		//		return View();
		//	}
		//}

		//// GET: CoursesController/Edit/5
		//public ActionResult Edit(int id)
		//{
		//	return View();
		//}

		//// POST: CoursesController/Edit/5
		//[HttpPost]
		//[ValidateAntiForgeryToken]
		//public ActionResult Edit(int id, IFormCollection collection)
		//{
		//	try
		//	{
		//		return RedirectToAction(nameof(Index));
		//	}
		//	catch
		//	{
		//		return View();
		//	}
		//}

		//// GET: CoursesController/Delete/5
		//public ActionResult Delete(int id)
		//{
		//	return View();
		//}

	}
}

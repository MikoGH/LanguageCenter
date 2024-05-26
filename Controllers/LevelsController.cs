using LanguageCenter.Models.Entity;
using LanguageCenter.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LanguageCenter.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class LevelsController : ControllerBase
	{
		private readonly ILevelRepository levelRepository;
        public LevelsController(ILevelRepository _levelRepository)
        {
			levelRepository = _levelRepository;   
        }

		// GET: LevelsController
		[HttpGet]
		public IActionResult Index()
		{
			IEnumerable<LevelEntity> levels = levelRepository.GetAll();
			if (levels == null)
				return NotFound();
			return Ok(levels);
		}

		// GET: LevelsController/Details/5
		//public ActionResult Details(int id)
		//{
		//	return View();
		//}

		//// GET: LevelsController/Create
		//public ActionResult Create()
		//{
		//	return View();
		//}

		//// POST: LevelsController/Create
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

		//// GET: LevelsController/Edit/5
		//public ActionResult Edit(int id)
		//{
		//	return View();
		//}

		//// POST: LevelsController/Edit/5
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

		//// GET: LevelsController/Delete/5
		//public ActionResult Delete(int id)
		//{
		//	return View();
		//}

		//// POST: LevelsController/Delete/5
		//[HttpPost]
		//[ValidateAntiForgeryToken]
		//public ActionResult Delete(int id, IFormCollection collection)
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
	}
}

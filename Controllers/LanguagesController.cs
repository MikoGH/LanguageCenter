using LanguageCenter.Data;
using LanguageCenter.Models.Entity;
using LanguageCenter.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LanguageCenter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Produces("application/json")]
    public class LanguagesController : ControllerBase
    {
        private readonly ILanguageRepository languageRepository;
        public LanguagesController(ILanguageRepository _languageRepository) 
        {
            languageRepository = _languageRepository;
        }

        // GET: LanguagesController
        [HttpGet]
        //[Route("LanguageView")]
        public IActionResult Index()
        {
            IEnumerable<LanguageEntity> languages = languageRepository.GetAll();
            if (languages == null)
                return NotFound();
            return Ok(languages);
        }

        // GET: LanguagesController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: LanguagesController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: LanguagesController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: LanguagesController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: LanguagesController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: LanguagesController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: LanguagesController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}

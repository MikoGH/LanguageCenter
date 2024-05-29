using LanguageCenter.Data;
using LanguageCenter.Models.Entity;
using LanguageCenter.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LanguageCenter.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LanguagesController : ControllerBase
	{
		private readonly ILanguageRepository languageRepository;
		public LanguagesController(ILanguageRepository languageRepository) 
		{
			this.languageRepository = languageRepository;
		}

		[HttpGet("")]
		public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
		{
			IEnumerable<LanguageEntity> languages = await languageRepository.GetAllAsync(cancellationToken);
			if (languages == null)
				return NotFound();
			return Ok(languages);
		}
	}
}

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
		public LevelsController(ILevelRepository levelRepository)
		{
			this.levelRepository = levelRepository;   
		}

		[HttpGet("")]
		public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
		{
			IEnumerable<LevelEntity> levels = await levelRepository.GetAllAsync(cancellationToken);
			if (levels == null)
				return NotFound();
			return Ok(levels);
		}
	}
}

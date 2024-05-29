using LanguageCenter.Models.Dto;
using LanguageCenter.Models.Entity;
using LanguageCenter.Modules;
using LanguageCenter.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LanguageCenter.Controllers
{
	[AllowAnonymous]
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IPersonRepository personRepository;
		private readonly IPasswordHasher passwordHasher;
		private readonly IJwtProvider jwtProvider;

		public AuthController(IPersonRepository personRepository, IPasswordHasher passwordHasher, IJwtProvider jwtProvider)
		{
			this.personRepository = personRepository;
			this.passwordHasher = passwordHasher;
			this.jwtProvider = jwtProvider;
		}

		[HttpPost("login")]
		public async Task<IActionResult> LogIn([FromQuery] LogInPersonDto personDto, CancellationToken cancellationToken)
		{
			PersonEntity person = await personRepository.GetByLoginAsync(personDto.Login, cancellationToken);
			if (person == null)
				return NotFound();
			if (!passwordHasher.Verify(personDto.Password, person.Password))
				return NotFound();
			string token = jwtProvider.GenerateToken(person);
			return Ok(token);
		}
	}
}

using LanguageCenter.Features.Persons.Dtos;
using LanguageCenter.Features.Persons.Queries.GetPersonByLogin;
using LanguageCenter.Models;
using LanguageCenter.Modules.Jwt;
using LanguageCenter.Modules.PasswordHasher;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LanguageCenter.Controllers
{
	[AllowAnonymous]
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IPasswordHasher passwordHasher;
		private readonly IJwtProvider jwtProvider;
		private readonly IMediator mediator;

		public AuthController(IPasswordHasher passwordHasher, IJwtProvider jwtProvider, IMediator mediator)
		{
			this.passwordHasher = passwordHasher;
			this.jwtProvider = jwtProvider;
			this.mediator = mediator;
		}

		[HttpPost("login")]
		public async Task<IActionResult> LogIn([FromQuery] LogInPersonDto personDto, CancellationToken cancellationToken)
		{
			PersonEntity person = await mediator.Send(new GetPersonByLoginQuery(personDto.Login), cancellationToken);
			if (person == null)
				return NotFound();
			if (!passwordHasher.Verify(personDto.Password, person.Password))
				return NotFound();
			string token = jwtProvider.GenerateToken(person);
			return Ok(token);
		}
	}
}

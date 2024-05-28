using LanguageCenter.Models.Dto;
using LanguageCenter.Models.Entity;
using LanguageCenter.Modules;
using LanguageCenter.Repositories.Implementations;
using LanguageCenter.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
		private readonly IHttpContextAccessor httpContext;

		public AuthController(IPersonRepository personRepository, IPasswordHasher passwordHasher, IJwtProvider jwtProvider, IHttpContextAccessor httpContext)
		{
			this.personRepository = personRepository;
			this.passwordHasher = passwordHasher;
			this.jwtProvider = jwtProvider;
			this.httpContext = httpContext;
		}

		[HttpPost("login")]
		public IActionResult LogIn([FromQuery] LogInPersonDto personDto)
		{
			PersonEntity person = personRepository.GetByLogin(personDto.Login);
			if (person == null)
				return NotFound();
			if (!passwordHasher.Verify(personDto.Password, person.Password))
				return NotFound();
			string token = jwtProvider.GenerateToken(person);
			//httpContext.HttpContext.Response.Cookies.Append("cookies", token);
			return Ok(token);
		}

		//[HttpPost("logout")]
		//public IActionResult LogOut()
		//{
		//	//httpContext.HttpContext.Session.Clear();
		//	return Ok();
		//}
	}
}

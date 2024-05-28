using LanguageCenter.Models.Dto;
using LanguageCenter.Models.Entity;
using LanguageCenter.Modules;
using LanguageCenter.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LanguageCenter.Controllers
{
	[Authorize(Roles = PersonEntity.ROLE_ADMIN)]
	[Route("api/[controller]")]
	[ApiController]
	public class PersonsController : ControllerBase
	{
		private readonly IPersonRepository personRepository;
		private readonly IPasswordHasher passwordHasher;
		public PersonsController(IPersonRepository personRepository, IPasswordHasher passwordHasher)
		{
			this.personRepository = personRepository;
			this.passwordHasher = passwordHasher;
		}

		[HttpGet("")]
		public IActionResult Index()
		{
			IEnumerable<PersonEntity> persons = personRepository.GetAll();
			if (persons == null)
				return NotFound();
			return Ok(persons);
		}

		[HttpGet("{id:int}")]
		public IActionResult Get([FromRoute] int id)
		{
			PersonEntity person = personRepository.GetById(id);
			if (person == null)
				return NotFound();
			return Ok(person);
		}

		[HttpPost("")]
		public IActionResult Create([FromQuery] InsertPersonDto personDto)
		{
			if (personRepository.ExistByLogin(personDto.Login))
				return NotFound();

			string hashedPassword = passwordHasher.Generate(personDto.Password);
			PersonEntity person = new PersonEntity
			{
				Role = personDto.Role,
				Login = personDto.Login,
				Password = hashedPassword,
				First_name = personDto.First_name,
				Second_name = personDto.Second_name,
				Last_name = personDto.Last_name
			};
			personRepository.Insert(person);
			return Ok();
		}

		[HttpPut("{id:int}")]
		public IActionResult Update([FromRoute] int id, [FromQuery] UpdatePersonDto personDto)
		{
			PersonEntity person = personRepository.GetById(id);
			if (person == null)
				return NotFound();

			string hashedPassword = passwordHasher.Generate(personDto.Password);
			person.Role = personDto.Role;
			person.Login = personDto.Login;
			person.Password = hashedPassword;
			person.First_name = personDto.First_name;
			person.Second_name = personDto.Second_name;
			person.Last_name = personDto.Last_name;

			personRepository.Update(person);
			return Ok();
		}

		[HttpDelete("{id:int}")]
		public IActionResult Delete([FromRoute] int id)
		{
			PersonEntity person = personRepository.GetById(id);
			if (person == null) return NotFound();
			personRepository.Delete(person);
			return Ok();
		}
	}
}

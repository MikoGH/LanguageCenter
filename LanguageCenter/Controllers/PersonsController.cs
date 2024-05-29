using AutoMapper;
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
	[Authorize(Roles = PersonEntity.Roles.Admin)]
	[Route("api/[controller]")]
	[ApiController]
	public class PersonsController : ControllerBase
	{
		private readonly IPersonRepository personRepository;
		private readonly IPasswordHasher passwordHasher;
		private readonly IMapper mapper;
		public PersonsController(IPersonRepository personRepository, IPasswordHasher passwordHasher, IMapper mapper)
		{
			this.personRepository = personRepository;
			this.passwordHasher = passwordHasher;
			this.mapper = mapper;
		}

		[HttpGet("")]
		public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
		{
			IEnumerable<PersonEntity> persons = await personRepository.GetAllAsync(cancellationToken);
			if (persons == null)
				return NotFound();
			IEnumerable<GetPersonDto> personsDto = mapper.Map<IEnumerable<GetPersonDto>>(persons);
			return Ok(personsDto);
		}

		[HttpGet("{id:int}")]
		public async Task<IActionResult> Get([FromRoute] int id, CancellationToken cancellationToken)
		{
			PersonEntity person = await personRepository.GetByIdAsync(id, cancellationToken);
			if (person == null)
				return NotFound();
			GetPersonDto personDto = mapper.Map<GetPersonDto>(person);
			return Ok(personDto);
		}

		[HttpPost("")]
		public async Task<IActionResult> Create(InsertPersonDto personDto, CancellationToken cancellationToken)
		{
			if (await personRepository.ExistsByLoginAsync(personDto.Login, cancellationToken))
				return NotFound();

			personDto.Password = passwordHasher.Generate(personDto.Password);
			PersonEntity person = mapper.Map<PersonEntity>(personDto);

			await personRepository.InsertAsync(person, cancellationToken);
			GetPersonDto getPersonDto = mapper.Map<GetPersonDto>(person);
			return Ok(getPersonDto);
		}

		[HttpPut("{id:int}")]
		public async Task<IActionResult> Update([FromRoute] int id, UpdatePersonDto personDto, CancellationToken cancellationToken)
		{
			PersonEntity person = await personRepository.GetByIdAsync(id, cancellationToken);
			if (person == null)
				return NotFound();

			personDto.Password = passwordHasher.Generate(personDto.Password);
			person = mapper.Map<PersonEntity>(personDto);

			await personRepository.UpdateAsync(person, cancellationToken);
			GetPersonDto getPersonDto = mapper.Map<GetPersonDto>(person);
			return Ok(getPersonDto);
		}

		[HttpDelete("{id:int}")]
		public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken cancellationToken)
		{
			bool result = await personRepository.DeleteByIdAsync(id, cancellationToken);
			if (!result) return NotFound();
            return Ok();
		}
	}
}

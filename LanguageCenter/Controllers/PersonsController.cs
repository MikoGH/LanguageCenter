using AutoMapper;
using LanguageCenter.Features.Persons.Commands.DeletePersonById;
using LanguageCenter.Features.Persons.Commands.InsertPerson;
using LanguageCenter.Features.Persons.Commands.UpdatePerson;
using LanguageCenter.Features.Persons.Dtos;
using LanguageCenter.Features.Persons.Queries.ExistsPersonByLogin;
using LanguageCenter.Features.Persons.Queries.GetAllPersons;
using LanguageCenter.Features.Persons.Queries.GetPersonById;
using LanguageCenter.Models;
using LanguageCenter.Modules.PasswordHasher;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LanguageCenter.Controllers
{
	[Authorize(Roles = PersonEntity.Roles.Admin)]
	[Route("api/[controller]")]
	[ApiController]
	public class PersonsController : ControllerBase
	{
		private readonly IPasswordHasher passwordHasher;
		private readonly IMapper mapper;
		private readonly IMediator mediator;
		public PersonsController(IPasswordHasher passwordHasher, IMapper mapper, IMediator mediator)
		{
			this.passwordHasher = passwordHasher;
			this.mapper = mapper;
			this.mediator = mediator;
		}

		[HttpGet("")]
		public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
		{
			IEnumerable<PersonEntity> persons = await mediator.Send(new GetAllPersonsQuery(), cancellationToken);
			if (persons == null)
				return NotFound();
			IEnumerable<GetPersonDto> personsDto = mapper.Map<IEnumerable<GetPersonDto>>(persons);
			return Ok(personsDto);
		}

		[HttpGet("{id:int}")]
		public async Task<IActionResult> Get([FromRoute] int id, CancellationToken cancellationToken)
		{
			PersonEntity person = await mediator.Send(new GetPersonByIdQuery(id), cancellationToken);
			if (person == null)
				return NotFound();
			GetPersonDto personDto = mapper.Map<GetPersonDto>(person);
			return Ok(personDto);
		}

		[HttpPost("")]
		public async Task<IActionResult> Create(InsertPersonDto personDto, CancellationToken cancellationToken)
		{
			if (await mediator.Send(new ExistsPersonByLoginQuery(personDto.Login), cancellationToken))
				return NotFound();

			personDto.Password = passwordHasher.Generate(personDto.Password);
			PersonEntity person = mapper.Map<PersonEntity>(personDto);

			await mediator.Send(new InsertPersonCommand(person), cancellationToken);
			GetPersonDto getPersonDto = mapper.Map<GetPersonDto>(person);
			return Ok(getPersonDto);
		}

		[HttpPut("{id:int}")]
		public async Task<IActionResult> Update([FromRoute] int id, UpdatePersonDto personDto, CancellationToken cancellationToken)
		{
			PersonEntity person = await mediator.Send(new GetPersonByIdQuery(id), cancellationToken);
			if (person == null)
				return NotFound();

			personDto.Password = passwordHasher.Generate(personDto.Password);
			person = mapper.Map<PersonEntity>(personDto);

			await mediator.Send(new UpdatePersonCommand(person), cancellationToken);
			GetPersonDto getPersonDto = mapper.Map<GetPersonDto>(person);
			return Ok(getPersonDto);
		}

		[HttpDelete("{id:int}")]
		public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken cancellationToken)
		{
			bool result = await mediator.Send(new DeletePersonByIdCommand(id), cancellationToken);
			if (!result) return NotFound();
			return Ok();
		}
	}
}
